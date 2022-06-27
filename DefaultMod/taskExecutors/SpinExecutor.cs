using GooseShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaultMod
{
    static class SpinExecutor
    {
        public static int spinDirection =0;

        public static void reset()
        {
            spinDirection = 0;
        }
        public static void run(GooseEntity goose)
        {
            spinDirection += 40;
            goose.direction = spinDirection % 360;
        }
    }
}
