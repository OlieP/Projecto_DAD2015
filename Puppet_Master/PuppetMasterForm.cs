using System;
using System.Windows.Forms;
using Reference_DLL;


namespace Projecto_DAD
{
    public partial class MasterForm : Form
    {
        public MasterForm()
        {
            PMService.form = this;
            InitializeComponent();
        }

        public void sendMessageToLog1(string message)
        {
            this.LogBox.AppendText("\r\n" + message);
        }

        public void sendMessageToLog2(string message)
        {
            this.slavesInfoLog.AppendText("\r\n" + message);
        }

        private void showSlavesInfo(object sender, EventArgs e)
        {
            PMService.showSlavesInfo();
        }

        private void sendMessageToSlave(object sender, EventArgs e)
        {
            string sitePort = portBox.Text;

            string url = PMService.getSlaveUrlByPort(sitePort);

            if(url != null)
            {
                // Get the PMServerInterface instance that is registerd at port 8086
                PSlavesInterface slave = (PSlavesInterface)Activator.GetObject(
                    typeof(PSlavesInterface),
                    "tcp://localhost:" + sitePort + "/Slave");

                slave.MsgToSlave(messageBox.Text);
            }
           
        }


        private void runScriptButton_Click(object sender, EventArgs e)
        {
            string name = runScriptText.Text;
            PMService.parseScript(name);
        }
    }
}
