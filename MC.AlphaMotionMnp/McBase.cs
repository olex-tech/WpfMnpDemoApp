using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.AlphaMotionMnp
{
    public abstract class McBase
    {
        public abstract int OpenDevice();
        public abstract int CloseDevice();

        public abstract int Start();
        public abstract int Stop();

        public abstract int GetInBit(int diBit, bool defaultVal);
        public abstract int GetOutBit(int doBit, bool defaultVal);
        public abstract int SetOutBit(int doBit, bool onVal);

        public abstract int StartJog(int axisIndex, bool plusVal);
        public abstract int StopJog(int axisIndex);

        public abstract int AbsMove(int axisIndex, int absPosition);
    }
}
