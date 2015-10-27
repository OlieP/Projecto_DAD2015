using System;
using System.IO;
using System.Linq;

namespace Reference_DLL
{
    public interface PMServerInterface
    {
        void RegisterSlaves(string newSlavePort, string name, string father);
        void MsgToSlaves(string message);  
        void MsgToMaster(string message);
        
    }
    public interface PSlavesInterface
    {
       // void SetSlaveData(object source, EventArgs e);
        void MsgToSlave(string message);
        string getName();
        void startProcess(string type, string nome, string url);
        void RegisterBroker(string newBrokerUrl, string nome);
    }

    public interface BrokerInterface
    {
        Data getBrokerData();
    }

    public interface PublisherInterface
    {

    }

    public interface SubscriberInterface
    {

    }

    [Serializable]
    public static class BuildPaths
    {
        public static string processPath;

       public static string PPath
        {
            get { return processPath; }
            set { processPath = getPath() + value; }    
        }
         public static string getPath()
        {
            string path_ini = Directory.GetCurrentDirectory();
            string path_1 = Directory.GetParent(path_ini).ToString();
            string path_2 = Directory.GetParent(path_1).ToString();
            processPath = Directory.GetParent(path_2).ToString();
            return processPath;
        }


    }

    [Serializable]
    public struct Data
    {
        public string port;
        public string name;

        public string Port
        {
            get
            {
                string[] brokerURLSplit = port.Split(':');
                string[] brokerURLSplit2 = brokerURLSplit[2].Split('/');
                return brokerURLSplit2[0];
            }
            set
            {

                port = value;
            }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


    }

}
