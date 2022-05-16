using MC.AlphaMotionMnp;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Windows.Input;

namespace WpfMnpDemoApp.ViewModels
{
    class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel() {
            _mc = new McAlphaMotionMnp();

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

        //public ICommand SysComBeginCommand { get; private set; }
        //public ICommand SysComResetCommand { get; private set; }
        public ICommand CycleBeginCommand { get; private set; }
        public ICommand CycleEndCommand { get; private set; }


        private McAlphaMotionMnp _mc;

        private void OnValuesRefreshed(object sender, EventArgs e) {
            CyclicState = _mc.CyclicState;
            CyclicStateOn = CyclicState == CyclicStates.Running;
        }

        private void CycleBegin() {
            _mc.Start();
        }
        private void CycleEnd() {
            _mc.Stop();
        }
    }
}
