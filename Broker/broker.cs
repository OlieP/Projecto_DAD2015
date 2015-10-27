using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reference_DLL;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;


namespace Broker
{
    class Broker
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Active " + args[0] + " " + args[1]);
            //char[] delimiters = { ':', '/' };
            BrokerService.brokerData.Name = args[0];
            BrokerService.brokerData.Port = args[1];
            string port = BrokerService.brokerData.Port;
            int porto = Int32.Parse(port);


            TcpChannel chan = new TcpChannel(porto);
            ChannelServices.RegisterChannel(chan, false);

            RemotingConfiguration.RegisterWellKnownServiceType(
             typeof(BrokerService), "Broker",
                WellKnownObjectMode.Singleton);
            // Get the PSlaveInterface instance that is registerd at port 8086
            PSlavesInterface slave = (PSlavesInterface)Activator.GetObject(typeof(PSlavesInterface),
                "tcp://localhost:"+args[2]+"/Slave");

            Console.WriteLine("Connected to slave: " + "tcp://localhost:" + args[2] + "/Slave");
            BrokerService.slave = slave;
            BrokerService.slave.RegisterBroker(args[1],args[0]);
            Console.ReadLine();

        }
    }

   

    public class BrokerService : MarshalByRefObject, BrokerInterface
    {
        public static PSlavesInterface slave;
        public static Data brokerData;
        private static List<PublisherInterface> publishers;
        private static Dictionary<string, string> publishersRegistry;
        private static List<SubscriberInterface> subscriber;
        private static Dictionary<string, string> subscribersRegistry;

        public BrokerService()
        {
            publishers = new List<PublisherInterface>();
            publishersRegistry = new Dictionary<string, string>();
            subscriber = new List<SubscriberInterface>();
            subscribersRegistry= new Dictionary<string, string>();
            brokerData = new Data();
        }
        public Data getBrokerData()
        {
            return brokerData;
        }

        public void RegisterPublisher(string newPublisherUrl, string newPublisherName)
        {

            PublisherInterface newPublisher = (PublisherInterface)Activator.GetObject(typeof(PublisherInterface),
                    newPublisherUrl);
            publishers.Add(newPublisher);
            publishersRegistry.Add(newPublisherName, newPublisherUrl);
            Console.WriteLine("New Publisher: " + newPublisherUrl);
        }

        public void RegisterSubscriber(string newSubscriberUrl, string newSubscriberName)
        {

            SubscriberInterface newSubscriber = (SubscriberInterface)Activator.GetObject(typeof(SubscriberInterface),
                    newSubscriberUrl);
            subscriber.Add(newSubscriber);
            subscribersRegistry.Add(newSubscriberName, newSubscriberUrl);
            Console.WriteLine("New Subscriber: " + newSubscriberUrl);
        }
    }
}
