using MC.AlphaMotionMnp;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace WpfMnpDemoApp.ViewModels
{
    public class DoubleValue : BindableBase
    {
        private double _value;
        public double Value {
            get { return _value; }
            set { SetProperty(ref _value, value); }
        }
    }

    public class AxisItemTranspose : BindableBase
    {
        string _paramName;
        public string ParamName {
            get { return _paramName; }
            set { SetProperty(ref _paramName, value); }
        }
        public List<DoubleValue> Items { get; } =
            Enumerable.Range(0, 8).Select(i => new DoubleValue()).ToList();
    }
    public class AxisRuntime : BindableBase
    {
        string _axisName;
        double _commandPos;
        double _feedbackPos;
        double _speed;

        public AxisRuntime(int index) {
            _axisName = "Axis" + index.ToString();
            _commandPos = 0;
            _feedbackPos = 0;
            _speed = 0;
        }
        public string AxisName {
            get { return _axisName; }
            set { SetProperty(ref _axisName, value); }
        }

        public double CommandPos {
            get { return _commandPos; }
            set { SetProperty(ref _commandPos, value); }
        }
        public double FeedbackPos {
            get { return _feedbackPos; }
            set { SetProperty(ref _feedbackPos, value); }
        }
        public double Speed {
            get { return _speed; }
            set { SetProperty(ref _speed, value); }
        }
    }

    public class DIcell : BindableBase
    {
        private bool _isOn;
        public bool IsOn {
            get { return _isOn; }
            set { SetProperty(ref _isOn, value); }
        }
    }
    class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel() {
            _mc = new McAlphaMotionMnp();

            WindowLoadedCommand = new DelegateCommand(WindowLoaded);
            WindowClosingCommand = new DelegateCommand(WindowClosing);
            CycleBeginCommand = new DelegateCommand(CycleBegin);
            CycleEndCommand = new DelegateCommand(CycleEnd);

            UpdateAxesTransposeParamNames();

            OnValuesRefreshed(null, null);
            _mc.ValuesRefreshed += OnValuesRefreshed;
        }

        private void UpdateAxesTransposeParamNames() {
            var rd = App.Current.Resources.MergedDictionaries[0];
            if (rd != null) {
                AxesTranspose[0].ParamName = rd["mw_CommandPos"].ToString();
                AxesTranspose[1].ParamName = rd["mw_ActualPos"].ToString();
                AxesTranspose[2].ParamName = rd["mw_CurrentVelocity"].ToString();
            } else {
                AxesTranspose[0].ParamName = "CommandPos";
                AxesTranspose[1].ParamName = "ActualPos";
                AxesTranspose[2].ParamName = "Velocity";
            }
        }

        public bool CyclicStateOn {
            get { return _cyclicStateOn; }
            set { SetProperty(ref _cyclicStateOn, value); }
        }
        private bool _cyclicStateOn;

        public ConnectionStates ConnectionState {
            get { return _connectionState; }
            set { SetProperty(ref _connectionState, value); }
        }
        private ConnectionStates _connectionState;

        public List<DIcell> DigitalInputs { get; } =
            Enumerable.Range(0, 16).Select(i => new DIcell()).ToList();

        public List<AxisRuntime> Axes { get; } =
            Enumerable.Range(0, 8).Select(i => new AxisRuntime(i)).ToList();

        public List<AxisItemTranspose> AxesTranspose { get; } =
            Enumerable.Range(0, 3).Select(i => new AxisItemTranspose()).ToList();


        //public ICommand SysComBeginCommand { get; private set; }
        //public ICommand SysComResetCommand { get; private set; }
        public ICommand WindowLoadedCommand { get; private set; }
        public ICommand WindowClosingCommand { get; private set; }
        public ICommand CycleBeginCommand { get; private set; }
        public ICommand CycleEndCommand { get; private set; }


        private readonly IMotionExecutor _mc;

        private void OnValuesRefreshed(object sender, EventArgs e) {
            ConnectionState = _mc.ConnectionState;
            CyclicStateOn = ConnectionState == ConnectionStates.Running;

            for (int i = 0; i < 16; i++) {
                DigitalInputs[i].IsOn = _mc.GetDI(i, false);
            }

            for (int i = 0; i < 8; i++) {
                Axes[i].CommandPos = _mc.GetCommandPos(i);
                Axes[i].FeedbackPos = _mc.GetActualPos(i);
                Axes[i].Speed = _mc.GetRuntimeVelocity(i);
            }

            // Prepare data for transposing view
            for (int i = 0; i < 8; i++) {
                AxesTranspose[0].Items[i].Value = Axes[i].CommandPos;
                AxesTranspose[1].Items[i].Value = Axes[i].FeedbackPos;
                AxesTranspose[2].Items[i].Value = Axes[i].Speed;
            }

            UpdateAxesTransposeParamNames();
        }
        private void WindowLoaded() {
            _mc.OpenDevice();
        }
        private void WindowClosing() {
            _mc.CloseDevice();
        }
        private void CycleBegin() {
            _mc.Start();
        }
        private void CycleEnd() {
            _mc.Stop();
        }
    }
}
