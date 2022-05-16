using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.AlphaMotionMnp
{
    public enum CyclicStates
    {
        // Use nmiGetCyclicStatus to get
        Terminate=0,
        Running,
        Error,
        Communication
    }
}
