using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using EasyLogger;

namespace MC.AlphaMotionMnp
{
    public class McAlphaMotionMnp : McBase
    {
        public McAlphaMotionMnp() {
            Logger = Log.Get<McAlphaMotionMnp>();

            _timerStatusCheck = new System.Timers.Timer();
            _timerStatusCheck.Interval = 1000;
            _timerStatusCheck.Elapsed += OnTimerElapsed;
        }

        //~McAlphaMotionMnp() {
        //    CloseDevice();
        //}

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

        private int _boardNum = 0;
        private bool _isOpen = false;

        private readonly System.Timers.Timer _timerStatusCheck; 
        private volatile object _locker = new object();
        private int _lastErrorCode = 0;

        private int Initialize() {
            int rc = 0;
            return rc;
        }

        private void RefreshValues() {
            lock (_locker) {
                UpdateCyclicStatus();
            }
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e) {
            try {
                _timerStatusCheck.Stop();
                //ScanTime = DateTime.Now - _lastScanTime;
                RefreshValues();
                OnValuesRefreshed();
            }
            finally {
                if (_isOpen)
                    _timerStatusCheck.Start();
            }
            //_lastScanTime = DateTime.Now;
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

        private int ProcessError(int errorCode, string funcName)
        {
            if (errorCode != nmiMNApiDefs.TMC_RV_OK && _lastErrorCode != errorCode) {
                bool isError = true;
                switch (errorCode) {
                // Do not treat as error the following codes:
                case nmiMNApiDefs.TMC_RV_STOP_P_S_END_ERR: // -200 //(SLMT+) 방향 소프트웨어 리미트에 의한 정지
                case nmiMNApiDefs.TMC_RV_STOP_N_S_END_ERR: // -201 //(SLMT-) 방향 소프트웨어 리미트에 의한 정지
                case nmiMNApiDefs.TMC_RV_STOP_P_H_END_ERR: // -205 //(LMT+) 방향 하드웨어 리미트에 의한 정지
                case nmiMNApiDefs.TMC_RV_STOP_N_H_END_ERR: // -206 //(LMT-) 방향 하드웨어 리미트에 의한 정지
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
