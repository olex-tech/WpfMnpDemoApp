using MC.AlphaMotionMnp;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace WpfMnpDemoApp.ViewModels
{
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
