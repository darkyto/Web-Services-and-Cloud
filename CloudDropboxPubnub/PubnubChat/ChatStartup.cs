namespace PubnubChat
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class PubnubChat
    {
        public const string PUBLISH_KEY = "pub-c-3be032cf-b44c-49f1-a246-1ff2b3d9172b";
        public const string SUBSCRIBE_KEY = "sub-c-76eab8f0-8be1-11e5-a04a-0619f8945a4f";
        public const string SECRET_KEY = "sec-c-MmM4MTIzZDctYzg3NC00MjAzLWEzMTItZDNkYmE4YWE4YzZj";

        static void Main()
        {
            // Start the HTML5 Pubnub client
            Process.Start("..\\..\\PubnubClient.html");

            System.Threading.Thread.Sleep(2000);

            PubnubAPI pubnub = new PubnubAPI(PUBLISH_KEY, SUBSCRIBE_KEY, SECRET_KEY, true);
            string channel = "chat-channel";

            // Publish a sample message to Pubnub
            List<object> publishResult = pubnub.Publish(channel, "Hello Pubnub!");
            Console.WriteLine(
                "Publish Success: " + publishResult[0].ToString() + "\n" +
                "Publish Info: " + publishResult[1]
            );

            // Show PubNub server time
            object serverTime = pubnub.Time();
            Console.WriteLine("Server Time: " + serverTime.ToString());

            // Subscribe for receiving messages (in a background task to avoid blocking)
            System.Threading.Tasks.Task t = new System.Threading.Tasks.Task(
                () =>
                pubnub.Subscribe(
                    channel,
                    delegate (object message)
                    {
                        Console.WriteLine("Received Message -> '" + message + "'");
                        return true;
                    }
                )
            );
            t.Start();

            // Read messages from the console and publish them to Pubnub
            while (true)
            {
                Console.Write("Enter a message to be sent to Pubnub: ");
                string msg = Console.ReadLine();
                pubnub.Publish(channel, msg);
                Console.WriteLine("Message {0} sent.\n", msg);
            }
        }
    }
}