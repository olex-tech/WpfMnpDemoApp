using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using EasyLogger;

namespace MC.AlphaMotionMnp
{
    public class AxisRuntime {
        string axisName;
        double commandPos;
        double feedbackPos;
        double speed;

        public AxisRuntime(int index) {
            axisName = "Axis" + index.ToString();
            commandPos = 0;
            feedbackPos = 0;
            speed = 0;
        }
        public string AxisName { get; set; }
        public double CommandPos { get; set; }
        public double FeedbackPos { get; set; }
        public double Speed { get; set; }

    };
    public class McAlphaMotionMnp : McBase
    {
        public McAlphaMotionMnp() {
            Logger = Log.Get<McAlphaMotionMnp>();

            _timerStatusCheck = new System.Timers.Timer();
            _timerStatusCheck.Interval = 1000;
            _timerStatusCheck.Elapsed += OnTimerStatusElapsed;

            _timerDICheck = new System.Timers.Timer();
            _timerDICheck.Interval = 10;
            _timerDICheck.Elapsed += OnTimerDIElapsed;

        }

        public CyclicStates CyclicState { get; private set; }

        public override int OpenDevice() {
            if (_isOpen) {
                Logger.Trace("Already load device");
            }

            Logger.Trace("nmiSysLoad");
            int rc = nmiMNApi.nmiSysLoad(nmiMNApiDefs.emAUTO, ref _boardNum);
            ProcessError(rc, "nmiSysLoad");

            _isOpen = rc == nmiMNApiDefs.TMC_RV_OK;
            if (_isOpen) {
                Logger.Debug("Start STATUS_CHECK timer. Interval: " + _timerStatusCheck.Interval.ToString() + "ms");
                _timerStatusCheck.Start();
                Logger.Debug("Start DI_CHECK timer. Interval: " + _timerDICheck.Interval.ToString() + "ms");
                _timerDICheck.Start();
            }

            return rc;
        }
        public override int CloseDevice() {
            int rc = 1;
            if (_isOpen) {
                Logger.Trace("nmiSysUnLoad");
                rc = nmiMNApi.nmiSysUnload();
                if (rc != nmiMNApiDefs.TMC_RV_OK) {
                    Logger.Debug("nmiMNApi.nmiSysUnload failed");
                }
            }
            _isOpen = false;

            return rc;
        }

        public override int Start() {
            Logger.Trace("nmiSysComm");
            int rc = nmiMNApi.nmiSysComm(_conNo);
            ProcessError(rc, "nmiSysComm");

            if (rc == nmiMNApiDefs.TMC_RV_OK) {
                Logger.Trace("nmiCyclicBegin");
                rc = nmiMNApi.nmiCyclicBegin(_conNo);
                ProcessError(rc, "nmiCyclicBegin");
            }

            if (rc == nmiMNApiDefs.TMC_RV_OK) {
                Logger.Trace("nmiConParamLoad");
                rc = nmiMNApi.nmiConParamLoad();
                ProcessError(rc, "nmiConParamLoad");
            }
            return rc;
        }

        public override int Stop() {
            Logger.Trace("nmiCyclicEnd");
            int rc = nmiMNApi.nmiCyclicEnd(_conNo);
            ProcessError(rc, "nmiCyclicEnd");
            CyclicState = CyclicStates.Terminate;

            return rc;
        }

        public override int GetInBit(int diBit, bool defaultVal) { return 0; }
        public override int GetOutBit(int doBit, bool defaultVal) { return 0; }
        public override int SetOutBit(int doBit, bool onVal) { return 0; }

        public override int StartJog(int axisIndex, bool plusVal) { return 0; }
        public override int StopJog(int axisIndex) { return 0; }

        public override int AbsMove(int axisIndex, int absPosition) { return 0; }


        public event EventHandler ValuesRefreshed;

        private Log Logger { get; set; }
        /// <summary>
        /// Default controller number
        /// </summary>
        private readonly int _conNo = 0;
        /// <summary>
        /// Additional default station number
        /// </summary>
        private readonly int _staNo = 1;
        private readonly int _maxDI = 16;

        private int _boardNum = 0;
        private bool _isOpen = false;

        private readonly System.Timers.Timer _timerStatusCheck;
        private readonly System.Timers.Timer _timerDICheck;

        private volatile object _locker = new object();
        private int _lastErrorCode = 0;

        public List<bool> DigitalInputs { get; } =
            Enumerable.Range(0, 16).Select(i => new bool()).ToList();

        public List<AxisRuntime> Axes { get; } =
            Enumerable.Range(0, 8).Select(i => new AxisRuntime(i)).ToList();

        private int Initialize() {
            int rc = 0;
            return rc;
        }

        private void RefreshValues() {
            lock (_locker) {
                UpdateCyclicStatus();
            }
        }

        private void OnTimerStatusElapsed(object sender, ElapsedEventArgs e) {
            try {
                _timerStatusCheck.Stop();

                RefreshValues();
                OnValuesRefreshed();
            }
            finally {
                if (_isOpen)
                    _timerStatusCheck.Start();
            }
        }

        private void OnTimerDIElapsed(object sender, ElapsedEventArgs e) {
            try {
                _timerDICheck.Stop();
                bool isModified = false;
                lock (_locker) {
                    isModified |= UpdateDigitalInputs();
                    isModified |= UpdateAxisMonitor();
                }
                if (isModified) {
                    OnValuesRefreshed();
                }
            }
            finally {
                if (_isOpen)
                    _timerDICheck.Start();
            }
        }

        private void OnValuesRefreshed() {
            ValuesRefreshed?.Invoke(this, new EventArgs());
        }


        private int UpdateCyclicStatus() {
            uint status = 0;
            int rc = nmiMNApi.nmiGetCyclicStatus(_conNo, ref status);
            ProcessError(rc, "nmiGetCyclicStatus");
            if (rc != nmiMNApiDefs.TMC_RV_OK)
                status = (uint)CyclicStates.Terminate;

            if (CyclicState != (CyclicStates)status) {
                CyclicState = (CyclicStates)status;
                Logger.Trace("CyclicState: " + CyclicState.ToString() + "(" + status.ToString() + ")");
            }

            return rc;
        }

        private bool UpdateDigitalInputs() {
            bool isModified = false;
            uint uiData = 0;
            for (int nbit = 0; nbit < _maxDI; nbit++) {
                int rc = nmiMNApi.nmiDiGetBit(_conNo, _staNo, nbit, ref uiData);
                //ProcessError(rc, "nmiDiGetBit");

                bool isOn = uiData == 1;
                if (rc == nmiMNApiDefs.TMC_RV_OK && DigitalInputs[nbit] != isOn)
                    isModified = true;

                DigitalInputs[nbit] = isOn;
            }
            return isModified;
        }

        private bool UpdateAxisMonitor() {
            bool isModified = false;

            int rc = 0;
            double dbbuffer = 0;

            for (int axis = 0; axis < 8; axis++) {
                rc = nmiMNApi.nmiAxGetCmdPos(_conNo, axis, ref dbbuffer);
                if (rc == nmiMNApiDefs.TMC_RV_OK && Axes[axis].CommandPos != dbbuffer) {
                    isModified |= true;
                    Axes[axis].CommandPos = dbbuffer;
                }

                rc = nmiMNApi.nmiAxGetActPos(_conNo, axis, ref dbbuffer);
                if (rc == nmiMNApiDefs.TMC_RV_OK && Axes[axis].FeedbackPos != dbbuffer) {
                    isModified |= true;
                    Axes[axis].FeedbackPos = dbbuffer;
                }

                rc = nmiMNApi.nmiAxGetCmdVel(_conNo, axis, ref dbbuffer);
                if (rc == nmiMNApiDefs.TMC_RV_OK && Axes[axis].Speed != dbbuffer) {
                    isModified |= true;
                    Axes[axis].Speed = dbbuffer;
                }
            }
            return isModified;
        }

        private int ProcessError(int errorCode, string funcName)
        {
            if (errorCode != nmiMNApiDefs.TMC_RV_OK && _lastErrorCode != errorCode) {
                bool isError = true;
                switch (errorCode) {
                // Do not treat as error the following codes:
                case nmiMNApiDefs.TMC_RV_STOP_P_S_END_ERR: // -200 //(SLMT+)
                case nmiMNApiDefs.TMC_RV_STOP_N_S_END_ERR: // -201 //(SLMT-)
                case nmiMNApiDefs.TMC_RV_STOP_P_H_END_ERR: // -205 //(LMT+)
                case nmiMNApiDefs.TMC_RV_STOP_N_H_END_ERR: // -206 //(LMT-)
                    isError = false;
                    break;
                }

                // TODO: Display Error description from external csv file
                if (isError) {
                    Logger.Warning(funcName + " failed with code: " + errorCode.ToString());
                } else {
                    Logger.Debug(funcName + " returns code: " + errorCode.ToString());
                }

                // Save last error code to prevent error flooding  in log
                _lastErrorCode = errorCode;
            }
            return errorCode;
        }

    }
}
