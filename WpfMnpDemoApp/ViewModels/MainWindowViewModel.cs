using MC.AlphaMotionMnp;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
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
        string paramName;
        public string ParamName {
            get { return paramName; }
            set { SetProperty(ref paramName, value); }
        }
        public List<DoubleValue> Items { get; } =
            Enumerable.Range(0, 8).Select(i => new DoubleValue()).ToList();
    }
    public class AxisRuntime : BindableBase
    {
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
        public string AxisName {
            get { return axisName; }
            set { SetProperty(ref axisName, value); }
        }

        public double CommandPos {
            get { return commandPos; }
            set { SetProperty(ref commandPos, value); }
        }
        public double FeedbackPos {
            get { return feedbackPos; }
            set { SetProperty(ref feedbackPos, value); }
        }
        public double Speed {
            get { return speed; }
            set { SetProperty(ref speed, value); }
        }
    }

    public class DIcell : BindableBase
    {
        private bool isOn;
        public bool IsOn {
            get { return isOn; }
            set { SetProperty(ref isOn, value); }
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

            OnValuesRefreshed(null, null);
            _mc.ValuesRefreshed += OnValuesRefreshed;

            AxesTranspose[0].ParamName = "CommandPos";
            AxesTranspose[1].ParamName = "ActualPos";
            AxesTranspose[2].ParamName = "Velocity";
        }

        public bool CyclicStateOn {
            get { return _cyclicStateOn; }
            set { SetProperty(ref _cyclicStateOn, value); }
        }
        private bool _cyclicStateOn;

        public CyclicStates CyclicState {
            get { return _cyclicState; }
            set { SetProperty(ref _cyclicState, value); }
        }
        private CyclicStates _cyclicState;

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


        private McAlphaMotionMnp _mc;

        private void OnValuesRefreshed(object sender, EventArgs e) {
            CyclicState = _mc.CyclicState;
            CyclicStateOn = CyclicState == CyclicStates.Running;

            for (int i = 0; i < 16; i++) {
                DigitalInputs[i].IsOn = _mc.DigitalInputs[i];
            }

            for (int i = 0; i < 8; i++) {
                Axes[i].CommandPos = _mc.Axes[i].CommandPos;
                Axes[i].FeedbackPos = _mc.Axes[i].FeedbackPos;
                Axes[i].Speed = _mc.Axes[i].Speed;
            }

            // Prepare data for transposing view
            for (int i = 0; i < 8; i++) {
                AxesTranspose[0].Items[i].Value = Axes[i].CommandPos;
                AxesTranspose[1].Items[i].Value = Axes[i].FeedbackPos;
                AxesTranspose[2].Items[i].Value = Axes[i].Speed;
            }
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
