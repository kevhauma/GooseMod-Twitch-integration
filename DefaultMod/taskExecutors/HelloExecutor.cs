using GooseShared;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaultMod
{
    static class HelloExecutor
    {
        static Font drawFont = new Font("Arial", 16);
        static SolidBrush drawBrush = new SolidBrush(Color.Red);

        public static void render(GooseEntity goose,Graphics graphics,string name)
        {
            graphics.DrawString("Hello "+name, drawFont, drawBrush, new PointF(goose.position.x - 20, goose.position.y));
        }
    }
}
