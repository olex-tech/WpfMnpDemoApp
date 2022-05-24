using System;


namespace MC.AlphaMotionMnp
{
    public interface IIoExecutor {
        bool GetDI(int ioNumber, bool dafaultVal);
        bool GetDO(int ioNumber, bool dafaultVal);
        int SetDO(int ioNumber, bool dafaultVal);
    }

    public struct Axis
    {
        public string Name { get; set; }
        public int Channel { get; set; }
    }

    public interface IMotionExecutor : IIoExecutor
    {
        ConnectionStates ConnectionState { get; }

        int OpenDevice();
        int CloseDevice();

        int Start();
        int Stop();

        int StartJog(Axis axis, bool plusVal);
        int StopJog(Axis axis);

        int AbsMove(Axis axis, int absPosition);
        int StopMove(Axis axis);

        event EventHandler ValuesRefreshed;

        double GetCommandPos(int index);
        double GetActualPos(int index);
        double GetRuntimeVelocity(int index);
    }
}
