using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading;
using Reference_DLL;
using System.IO;

namespace Projecto_DAD
{
    class PuppetMaster
    {
        [STAThread]
        static void Main(string[] args)
        {
            TcpChannel channel = new TcpChannel(8086);
            ChannelServices.RegisterChannel(channel, false);

            RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(PMService), "PMServer",
                WellKnownObjectMode.Singleton);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MasterForm());
        }
    }

    public delegate void DelAddMsgToLog(string msg);

    public delegate void DelShowSlavesInfo(string msg);

    public delegate void DelSendMsgToSlaves(string msg);

    public class PMService : MarshalByRefObject, PMServerInterface
    {
        public static MasterForm form;

        private static Dictionary<string, string> slavesRegistry;

        private static List<PSlavesInterface> slaves;
        private List<string> messages;

        public PMService()
        {
            slaves = new List<PSlavesInterface>();
            messages = new List<string>();
            slavesRegistry = new Dictionary<string, string>();

        }

        public void RegisterSlaves(string newPort, string name, string father)
        {
            form.Invoke(new DelAddMsgToLog(form.sendMessageToLog1), "Trying ..." + "tcp://localhost:" + newPort + "/Slave");

            PSlavesInterface newSlave = (PSlavesInterface)Activator.GetObject(typeof(PSlavesInterface),
                     "tcp://localhost:" + newPort + "/Slave");

            // form.Invoke(new DelAddMsgToLog(form.sendMessageToLog1), "Saving Slave: " + name + "in Master");

            slaves.Add(newSlave);

            slavesRegistry.Add(newPort, "tcp://localhost:" + newPort + "/Slave");
        }

        public void MsgToMaster(string message)
        {
            form.Invoke(new DelAddMsgToLog(form.sendMessageToLog1), message);
        }

        public void MsgToSlaves(string message)
        {
            messages.Add(message);

            ThreadStart ts = new ThreadStart(this.BroadcastMessage);
            Thread t = new Thread(ts);
            t.Start();

        }

        public static void showSlavesInfo()
        {
            foreach (string s in slavesRegistry.Values)
            {
                form.Invoke(new DelShowSlavesInfo(form.sendMessageToLog2), s);
            }
        }

        private void BroadcastMessage()
        {
            string MsgToBcast;
            lock (this)
            {
                MsgToBcast = messages[messages.Count - 1];
            }
            for (int i = 0; i < slaves.Count; i++)
            {
                try
                {
                    ((PSlavesInterface)slaves[i]).MsgToSlave(MsgToBcast);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Failed sending message to client. Removing client. " + e.Message);
                    slaves.RemoveAt(i);
                }
            }
        }

        public static string getSlaveUrlByPort(string name)
        {
            if (slavesRegistry.ContainsKey(name))
            {
                return slavesRegistry[name];
            }
            else return null;
        }

        public static void parseScript(string filename)
        {
            string line;
            string[] words;
            System.IO.StreamReader file = new System.IO.StreamReader(filename);
            if (slaves == null)
                form.Invoke(new DelAddMsgToLog(form.sendMessageToLog1), "Slave Missing");
            else
            {
                while ((line = file.ReadLine()) != null && slaves != null)
                {
                    words = line.Split();
                    if (line.Contains("Site"))
                    {
                        bool search = false;
                        foreach (PSlavesInterface s in slaves)
                        {
                            if (words[1].Equals(s.getName()))
                            {
                                search = true;
                                continue;

                            }
                        }
                        if(!search)
                            form.Invoke(new DelAddMsgToLog(form.sendMessageToLog1), "Slave "+words[1]+ "not present");
                        

                    }
                    if (line.Contains("Process"))
                    {
                        foreach (PSlavesInterface s in slaves)
                        {
                            if (words[5].Equals(s.getName()))
                            {
                                s.startProcess(words[3], words[1], words[7]);
                            }
                        }
                    }


                }
            }


        }

    }
}
