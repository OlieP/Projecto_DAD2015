using System.Threading.Tasks;


namespace Projecto_DAD
{
    partial class MasterForm 
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label logboxLabel;


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.logboxLabel = new System.Windows.Forms.Label();
            this.portBox = new System.Windows.Forms.TextBox();
            this.messageBox = new System.Windows.Forms.TextBox();
            this.portLabel = new System.Windows.Forms.Label();
            this.messageBoxLabel = new System.Windows.Forms.Label();
            this.sendButton = new System.Windows.Forms.Button();
            this.slavesInfoLog = new System.Windows.Forms.RichTextBox();
            this.LogBox = new System.Windows.Forms.TextBox();
            this.ShowSlavesInfo = new System.Windows.Forms.Button();
            this.runScript = new System.Windows.Forms.Label();
            this.runScriptText = new System.Windows.Forms.TextBox();
            this.runScriptButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // logboxLabel
            // 
            this.logboxLabel.AutoSize = true;
            this.logboxLabel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.logboxLabel.Location = new System.Drawing.Point(784, 42);
            this.logboxLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.logboxLabel.Name = "logboxLabel";
            this.logboxLabel.Size = new System.Drawing.Size(240, 25);
            this.logboxLabel.TabIndex = 1;
            this.logboxLabel.Text = "Action Log From Slaves";
            // 
            // portBox
            // 
            this.portBox.Location = new System.Drawing.Point(62, 73);
            this.portBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(242, 31);
            this.portBox.TabIndex = 2;
            // 
            // messageBox
            // 
            this.messageBox.Location = new System.Drawing.Point(62, 160);
            this.messageBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(440, 31);
            this.messageBox.TabIndex = 3;
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(56, 42);
            this.portLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(208, 25);
            this.portLabel.TabIndex = 4;
            this.portLabel.Text = "Slave\'s (Site\'s ) port:";
            // 
            // messageBoxLabel
            // 
            this.messageBoxLabel.AutoSize = true;
            this.messageBoxLabel.Location = new System.Drawing.Point(62, 125);
            this.messageBoxLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.messageBoxLabel.Name = "messageBoxLabel";
            this.messageBoxLabel.Size = new System.Drawing.Size(187, 25);
            this.messageBoxLabel.TabIndex = 5;
            this.messageBoxLabel.Text = "Message to slave:";
            // 
            // sendButton
            // 
            this.sendButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.sendButton.FlatAppearance.BorderSize = 3;
            this.sendButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.sendButton.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.sendButton.Location = new System.Drawing.Point(518, 160);
            this.sendButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(150, 44);
            this.sendButton.TabIndex = 6;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendMessageToSlave);
            // 
            // slavesInfoLog
            // 
            this.slavesInfoLog.Location = new System.Drawing.Point(62, 373);
            this.slavesInfoLog.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.slavesInfoLog.Name = "slavesInfoLog";
            this.slavesInfoLog.Size = new System.Drawing.Size(440, 181);
            this.slavesInfoLog.TabIndex = 7;
            this.slavesInfoLog.Text = "";
            // 
            // LogBox
            // 
            this.LogBox.Location = new System.Drawing.Point(714, 90);
            this.LogBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.LogBox.Multiline = true;
            this.LogBox.Name = "LogBox";
            this.LogBox.Size = new System.Drawing.Size(370, 481);
            this.LogBox.TabIndex = 0;
            // 
            // ShowSlavesInfo
            // 
            this.ShowSlavesInfo.Location = new System.Drawing.Point(68, 304);
            this.ShowSlavesInfo.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.ShowSlavesInfo.Name = "ShowSlavesInfo";
            this.ShowSlavesInfo.Size = new System.Drawing.Size(150, 44);
            this.ShowSlavesInfo.TabIndex = 8;
            this.ShowSlavesInfo.Text = "Show Slaves Info";
            this.ShowSlavesInfo.UseVisualStyleBackColor = true;
            this.ShowSlavesInfo.Click += new System.EventHandler(this.showSlavesInfo);
            // 
            // runScript
            // 
            this.runScript.AutoSize = true;
            this.runScript.Location = new System.Drawing.Point(62, 202);
            this.runScript.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.runScript.Name = "runScript";
            this.runScript.Size = new System.Drawing.Size(132, 25);
            this.runScript.TabIndex = 9;
            this.runScript.Text = "Script name:";
            // 
            // runScriptText
            // 
            this.runScriptText.Location = new System.Drawing.Point(62, 240);
            this.runScriptText.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.runScriptText.Name = "runScriptText";
            this.runScriptText.Size = new System.Drawing.Size(440, 31);
            this.runScriptText.TabIndex = 10;
            // 
            // runScriptButton
            // 
            this.runScriptButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.runScriptButton.FlatAppearance.BorderSize = 3;
            this.runScriptButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.runScriptButton.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.runScriptButton.Location = new System.Drawing.Point(518, 240);
            this.runScriptButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.runScriptButton.Name = "runScriptButton";
            this.runScriptButton.Size = new System.Drawing.Size(150, 44);
            this.runScriptButton.TabIndex = 6;
            this.runScriptButton.Text = "Run Script";
            this.runScriptButton.UseVisualStyleBackColor = true;
            this.runScriptButton.Click += new System.EventHandler(this.runScriptButton_Click);
            // 
            // MasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 640);
            this.Controls.Add(this.ShowSlavesInfo);
            this.Controls.Add(this.slavesInfoLog);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.messageBoxLabel);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.messageBox);
            this.Controls.Add(this.portBox);
            this.Controls.Add(this.logboxLabel);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.runScript);
            this.Controls.Add(this.runScriptText);
            this.Controls.Add(this.runScriptButton);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "MasterForm";
            this.Text = "MasterForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.TextBox portBox;
        private System.Windows.Forms.TextBox messageBox;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.Label messageBoxLabel;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.RichTextBox slavesInfoLog;
        private System.Windows.Forms.TextBox LogBox;
        private System.Windows.Forms.Button ShowSlavesInfo;
        private System.Windows.Forms.TextBox runScriptText;
        private System.Windows.Forms.Label runScript;
        private System.Windows.Forms.Button runScriptButton;


    }
}