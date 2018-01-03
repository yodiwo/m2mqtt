using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2MqttClient;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var cli = new MqttClient("localhost");

            cli.ConnectionClosed += Cli_ConnectionClosed;

            cli.MqttMsgPublished += Cli_MqttMsgPublished;
            cli.MqttMsgSubscribed += Cli_MqttMsgSubscribed;
            cli.MqttMsgUnsubscribed += Cli_MqttMsgUnsubscribed;
            cli.MqttMsgPublishReceived += Cli_MqttMsgPublishReceived;
            var rc = cli.Connect("test", "YodiPlegmaClient", "5839a85e-dde8-429a-90bf-e9793c0b181bA");

            Console.WriteLine("connected: " + rc);
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
