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

            _timer = new System.Timers.Timer();
            _timer.Interval = 100;
            _timer.Elapsed += OnTimerElapsed;
        }

        public CyclicStates CyclicState { get; private set; }

        public override int OpenDevice() {
            if (_isConnected) {
                Logger.Trace("Already load device");
            }

            Logger.Trace("nmiSysLoad");
            int rc = nmiMNApi.nmiSysLoad(nmiMNApiDefs.emAUTO, ref _boardNum);
            ProcessError(rc, "nmiSysLoad");

            _isConnected = rc == nmiMNApiDefs.TMC_RV_OK;

            return rc;
        }
        public override int CloseDevice() {
            Logger.Trace("nmiSysUnLoad");
            int rc = nmiMNApi.nmiSysUnload();
            if (rc < 1) {
                Logger.Debug("nmiMNApi.nmiSysUnload failed");
            }

            _isConnected = false;

            return rc;
        }

        public override int Start() {
            int rc = OpenDevice();
            if (rc < 0)
                return rc;


            Logger.Trace("nmiSysComm");
            rc = nmiMNApi.nmiSysComm(_conNo);
            ProcessError(rc, "nmiSysComm");

            if (rc == 1) {
                Logger.Trace("nmiCyclicBegin");
                rc = nmiMNApi.nmiCyclicBegin(_conNo);
                ProcessError(rc, "nmiCyclicBegin");
            }

            if (rc == 1) {
                Logger.Trace("nmiConParamLoad");
                rc = nmiMNApi.nmiConParamLoad();
                ProcessError(rc, "nmiConParamLoad");
            }
            return rc;
        }

        public override int Stop() {
            int rc = 0;
            if (_isConnected) {
                Logger.Trace("nmiCyclicEnd");
                rc = nmiMNApi.nmiCyclicEnd(_conNo);
                ProcessError(rc, "nmiCyclicEnd");

                return CloseDevice();
            }

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
        private readonly int _conNo = 0;
        private readonly int _staNo = 1;

        private int _boardNum = 0;
        private bool _isConnected = false;

        private readonly System.Timers.Timer _timer; 
        private volatile object _locker = new object();

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
                _timer.Stop();
                //ScanTime = DateTime.Now - _lastScanTime;
                RefreshValues();
                OnValuesRefreshed();
            }
            finally {
                _timer.Start();
            }
            //_lastScanTime = DateTime.Now;
        }

        private void OnValuesRefreshed() {
            ValuesRefreshed?.Invoke(this, new EventArgs());
        }


        private int UpdateCyclicStatus() {
            uint status = 0;
            int rc = nmiMNApi.nmiGetCyclicStatus(_conNo, ref status);

            CyclicState = (CyclicStates)status;
            return rc;
        }

        private int ProcessError(int errorCode, string funcName)
        {
            if (errorCode != nmiMNApiDefs.TMC_RV_OK) {
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
            }
            return errorCode;
        }

    }
}
