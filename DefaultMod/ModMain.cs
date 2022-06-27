using System;
using System.Drawing;
using System.Windows.Forms;
using GooseShared;
using TwitchBot;

namespace DefaultMod
{
    public class ModEntryPoint : IMod
    {
        Bot bot;
        TaskManager TaskManager;
        
        void IMod.Init()
        {
            bot = new Bot();
            TaskManager = TaskManager.get();

            InjectionPoints.PostTickEvent += PostTick;
            InjectionPoints.PreRenderEvent += PreRenderEvent;

        }
        private void PreRenderEvent(GooseEntity goose, Graphics g)
        {  
            TaskManager.doRender(goose,g);            
        }
        public void PostTick(GooseEntity goose)
        {
            TaskManager.doTask(goose);
        }       
    }
}
