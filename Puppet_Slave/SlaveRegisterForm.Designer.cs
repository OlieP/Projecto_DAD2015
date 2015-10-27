namespace Projecto_DAD
{
    partial class SlaveRegisterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.portBox = new System.Windows.Forms.TextBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.fatherBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.sendInfo = new System.Windows.Forms.Button();
            this.showActions = new System.Windows.Forms.TextBox();
            this.connect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // portBox
            // 
            this.portBox.Location = new System.Drawing.Point(35, 27);
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(90, 20);
            this.portBox.TabIndex = 0;
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(35, 66);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(89, 20);
            this.nameBox.TabIndex = 1;
            // 
            // fatherBox
            // 
            this.fatherBox.Location = new System.Drawing.Point(36, 106);
            this.fatherBox.Name = "fatherBox";
            this.fatherBox.Size = new System.Drawing.Size(88, 20);
            this.fatherBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Port Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Own Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Father's Name";
            // 
            // sendInfo
            // 
            this.sendInfo.Location = new System.Drawing.Point(45, 145);
            this.sendInfo.Name = "sendInfo";
            this.sendInfo.Size = new System.Drawing.Size(70, 20);
            this.sendInfo.TabIndex = 8;
            this.sendInfo.Text = "SetInfo";
            this.sendInfo.UseVisualStyleBackColor = true;
            this.sendInfo.Click += new System.EventHandler(this.register_click);
            // 
            // showActions
            // 
            this.showActions.Location = new System.Drawing.Point(155, 66);
            this.showActions.Multiline = true;
            this.showActions.Name = "showActions";
            this.showActions.Size = new System.Drawing.Size(206, 99);
            this.showActions.TabIndex = 9;
            // 
            // connect
            // 
            this.connect.Location = new System.Drawing.Point(155, 24);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(75, 23);
            this.connect.TabIndex = 10;
            this.connect.Text = "Connect";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // SlaveRegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 187);
            this.Controls.Add(this.connect);
            this.Controls.Add(this.showActions);
            this.Controls.Add(this.sendInfo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fatherBox);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.portBox);
            this.Name = "SlaveRegisterForm";
            this.Text = "Slave Register Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox portBox;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox fatherBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button sendInfo;
        private System.Windows.Forms.TextBox showActions;
        private System.Windows.Forms.Button connect;
    }
}

