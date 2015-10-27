using System;
using System.Windows.Forms;
using Reference_DLL;
using System.Collections.Generic;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;

namespace Projecto_DAD
{
    public partial class SlaveRegisterForm : Form
    {
       
        public SlaveRegisterForm()
        {
            PSlaveService.form = this;
            InitializeComponent();
        }

        public void AddMsg(string s)
        {
            this.showActions.AppendText("\r\n" + s);
        }


        private void connect_Click(object sender, EventArgs e)
        {

            int port = Int32.Parse(portBox.Text);

            TcpChannel chan = new TcpChannel(port);
            ChannelServices.RegisterChannel(chan, false);

            RemotingConfiguration.RegisterWellKnownServiceType(
             typeof(PSlaveService), "Slave",
                WellKnownObjectMode.Singleton);

            Invoke(new DelAddMsg(AddMsg), "Trying ..." + "tcp://localhost:8086/PMServer");

            // Get the PMServerInterface instance that is registerd at port 8086
            PMServerInterface server = (PMServerInterface)Activator.GetObject(typeof(PMServerInterface),
                "tcp://localhost:8086/PMServer");

            Invoke(new DelAddMsg(AddMsg), "Connected: " + " tcp://localhost:8086/PMServer");

            PSlaveService.server = server;

            PSlaveService.server.MsgToMaster("Estabilished: " + " tcp://localhost:8086/PMServer");

            //foreach (object o in messages)
            //{
            //   AddMsg((string)o);
            //} 
        }

        private void register_click(object sender, EventArgs e)
        {

            PSlaveService.server.RegisterSlaves(portBox.Text, nameBox.Text, fatherBox.Text);

            PSlaveService.server.MsgToMaster("Slave Succesfully createad in port " + portBox.Text);

            PSlaveService.ownData = new Data();

            PSlaveService.ownData.Port = portBox.Text;
            PSlaveService.ownData.Name = nameBox.Text;
            PSlaveService.ownData.Father = fatherBox.Text;

            PSlaveService.server.MsgToMaster("Slave info saved !!! ");

            PSlaveService.server.MsgToSlaves("You have been created !!!");
       

            PSlaveService.server.MsgToMaster("Thank You master !!! ");


        }
    }
}
