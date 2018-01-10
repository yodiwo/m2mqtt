using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using uPLibrary.Networking.M2MqttClient;
using TraceLevel = uPLibrary.Networking.M2MqttClient.Utility.TraceLevel;


namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));

            uPLibrary.Networking.M2MqttClient.Utility.Trace.TraceListener = Console.WriteLine;
            uPLibrary.Networking.M2MqttClient.Utility.Trace.TraceLevel = TraceLevel.Error
                                                                 | TraceLevel.Warning
                                                                 | TraceLevel.Information
                                                                 | TraceLevel.Verbose
                                                                 | TraceLevel.Frame;
            System.Diagnostics.Debug.AutoFlush = false;

            var cli = new MqttClient("activetrac.activategroup.co.za");

            cli.ConnectionClosed += Cli_ConnectionClosed;

            cli.MqttMsgPublished += Cli_MqttMsgPublished;
            cli.MqttMsgSubscribed += Cli_MqttMsgSubscribed;
            cli.MqttMsgUnsubscribed += Cli_MqttMsgUnsubscribed;
            cli.MqttMsgPublishReceived += Cli_MqttMsgPublishReceived;

            var rc = cli.Connect("cli1", "u1", "p1");


            Console.WriteLine("connected: " + rc);
            while (true)
                Thread.Sleep(1000);
        }

        private static void Cli_MqttMsgUnsubscribed(object sender, uPLibrary.Networking.M2MqttClient.Messages.MqttMsgUnsubscribedEventArgs e)
        {
            Console.WriteLine("Cli_MqttMsgUnsubscribed");
        }

        private static void Cli_MqttMsgSubscribed(object sender, uPLibrary.Networking.M2MqttClient.Messages.MqttMsgSubscribedEventArgs e)
        {
            Console.WriteLine("Cli_MqttMsgSubscribed");
        }

        private static void Cli_MqttMsgPublishReceived(object sender, uPLibrary.Networking.M2MqttClient.Messages.MqttMsgPublishEventArgs e)
        {
            Console.WriteLine("Cli_MqttMsgPublishReceived");
        }

        private static void Cli_MqttMsgPublished(object sender, uPLibrary.Networking.M2MqttClient.Messages.MqttMsgPublishedEventArgs e)
        {
            Console.WriteLine("Cli_MqttMsgPublished");
        }

        private static void Cli_ConnectionClosed(object sender, EventArgs e)
        {
            Console.WriteLine("Cli_ConnectionClosed");
        }
    }
}
