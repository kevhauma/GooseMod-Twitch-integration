using GooseShared;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace DefaultMod
{
    public enum TASK
    {
        IDLE,
        SPIN,
        HELLO,
        DICKS,
    }
    class Task
    {
        public TASK task;
        public object arg;
    }
    class TaskManager
    {
        TaskExecutor executor;
        public Task currentTask;
        public List<Task> taskQueue;
        public DateTime nextCoolDown;
        
        private static TaskManager tm;

        private TaskManager()
        {
            taskQueue = new List<Task>();
            executor = new TaskExecutor();
            nextCoolDown = DateTime.Now.AddSeconds(-5);
            setIdle();
        }
        public static TaskManager get()
        {
            if (tm == null)
                tm = new TaskManager();

            return tm;
        }
        public void addTask(TASK t, object arg)
        {
            taskQueue.Add(new Task() {task= t, arg= arg });
        }
        public Task getTask()
        {
            if (isIdle())
            {
                if (taskQueue.Count > 0)
                {
                    currentTask = taskQueue[0];
                    taskQueue.RemoveAt(0);                    
                }                
            }
            if (currentTask == null)
                currentTask = new Task() { task = TASK.IDLE, arg = null };
            return currentTask;
        }
        public bool isIdle()
        {
            if (DateTime.Now.CompareTo(nextCoolDown) < 0) return false;
            if (TASK.IDLE == currentTask.task) return true;
            return false;
        }

        public void doTask(GooseEntity goose)
        {
            
            var ctask = getTask();
            if (ctask == null) return;

            if (ctask.task == TASK.SPIN)
                executor.spin(goose);
            
            if (executor.done)
            {
                setIdle();
                nextCoolDown = DateTime.Now.AddSeconds(15);
            }
        }
        public void doRender(GooseEntity goose, Graphics g)
        {
            var ctask = getTask();

            if (ctask == null) return;
            if (ctask.task == TASK.HELLO)
                executor.hello(goose, g, (string)ctask.arg);
            if (ctask.task == TASK.DICKS)
                executor.hello(goose, g, "DICKS");

            
        }
        public void setIdle()
        {
            currentTask = new Task() { task = TASK.IDLE, arg = null };
        }
    }
}
