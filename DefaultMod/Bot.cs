using DefaultMod;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;


namespace TwitchBot
{ 
    class Bot
    {
        TwitchClient client;
        TaskManager taskManager;

        public Bot()
        {
            ConnectionCredentials credentials = new ConnectionCredentials("MrJunior717", "oauth:ht283ag0ven4n687mco9ehag9sa92v");

            client = new TwitchClient();
            client.Initialize(credentials, "MrJunior717");

            client.OnMessageReceived += Client_OnMessageReceived;
            client.OnNewSubscriber += Client_OnNewSubscriber;
            client.OnUserJoined += Client_OnUserJoined;

            client.Connect();
            taskManager = TaskManager.get();
        }
        
        private void Client_OnUserJoined(object sender, OnUserJoinedArgs e)
        {
            taskManager.addTask(TASK.HELLO,e.Username);
        }

        private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            taskManager.addTask(TASK.HELLO, e.ChatMessage.DisplayName);
            if (e.ChatMessage.Message.Contains("DICKS"))
            {
                taskManager.addTask(TASK.DICKS,null);
            }
            if (e.ChatMessage.Message.Contains("spin"))
            {
                taskManager.addTask(TASK.SPIN, null);
            }
        }

        private void Client_OnNewSubscriber(object sender, OnNewSubscriberArgs e)
        {
           
        }
    }
}
