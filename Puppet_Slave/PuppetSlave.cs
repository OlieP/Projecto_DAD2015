using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;
using System.Diagnostics;
using System.IO;
using System.Linq;

using Reference_DLL;

namespace Projecto_DAD
{
    public class PuppetSlave
    {
        public PuppetSlave() { }

        [STAThread]
        static void Main(String[] args)
        {  
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SlaveRegisterForm());
        }

    }

    public delegate void DelAddMsg(string mensagem);

    public struct Data
    {
        public string port;
        public string name;
        public string father;

        public string Port
        {
            get { return port; }
            set { port = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Father
        {
            get { return father; }
            set { father = value; }
        }
    }

    public class PSlaveService : MarshalByRefObject, PSlavesInterface
    {
        public static SlaveRegisterForm form;
        public static PMServerInterface server;
        public static Data ownData;
        private static List<BrokerInterface> brokers;
        private static Dictionary<string, string> brokersRegistry;



        public PSlaveService() {
            brokers = new List<BrokerInterface>();
            brokersRegistry = new Dictionary<string, string>();

        }

        public void MsgToSlave(string mensagem)
        {
            // thread-safe access to form
            form.Invoke(new DelAddMsg(form.AddMsg), mensagem);
        }

        public string getName()
        {
            return ownData.Name;
        }
        public void startProcess(string type, string name, string url)
        {
            string path;
            switch (type)
            {
                case "broker":
                    brokersRegistry.Add(name, url);
                    string args = name + " " + url + " " + ownData.Port;
                    // string path = BuildPaths.getPath();
                    BuildPaths.PPath = "\\Broker\\bin\\Debug\\Broker.exe";
                    path = BuildPaths.PPath;
                    Process.Start(path, args);
                    break;

                case "publisher":
                   foreach (KeyValuePair<string,string> b in brokersRegistry)
                    {
                        string args2 = name + " " + url + " " + b.Value;
                        // string path = BuildPaths.getPath();
                        BuildPaths.PPath = "\\Publisher\\bin\\Debug\\Publisher.exe";
                        path = BuildPaths.PPath;
                        Process.Start(path, args2);
                    }
                    break;

                case "subscriber":
                   foreach (KeyValuePair<string,string> b in brokersRegistry)
                   {
                        string args3 = name + " " + url + " " + b.Value;
                        // string path = BuildPaths.getPath();
                        BuildPaths.PPath = "\\Subscriber\\bin\\Debug\\Subscriber.exe";
                        path = BuildPaths.PPath;
                        Process.Start(path, args3);
                   }
                    break;
            }
        }
        public void RegisterBroker(string newBrokerUrl, string newBrokerName)
        {
            BrokerInterface newBroker = (BrokerInterface)Activator.GetObject(typeof(BrokerInterface),
                    newBrokerUrl);
            brokers.Add(newBroker);
         //   brokersRegistry.Add(newBrokerName, newBrokerUrl);
            form.Invoke(new DelAddMsg(form.AddMsg), "New Broker: " + newBrokerUrl);
        }

    }

}
