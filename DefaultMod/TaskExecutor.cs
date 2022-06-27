using GooseShared;
using System;
using System.Drawing;


namespace DefaultMod
{
    class TaskExecutor
    {
        
        public bool done = true;
        private DateTime duration;        

        private void setDuration(int seconds)
        {
            if (done)
                duration = DateTime.Now.AddSeconds(seconds);
        }
        private void setDone()
        {
            if (DateTime.Now.CompareTo(duration) < 1)
                done = false;
            else
                done = true;
        }

        public void spin(GooseEntity goose, int seconds = 15)
        {
            setDuration(seconds);

            if (done)
                SpinExecutor.spinDirection = 0;

                SpinExecutor.run(goose);

            setDone();            
        }
        public void hello(GooseEntity goose, Graphics graphics, string name, int seconds = 15)
        {
            setDuration(seconds);
            if(!done)
            HelloExecutor.render(goose, graphics, name);

            setDone();
        }
    }    
}
