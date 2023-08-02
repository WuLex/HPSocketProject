namespace BreakpointTransmissionServer
{
    partial class ServerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uibtnStartServer = new Sunny.UI.UIButton();
            this.uiProcessBar1 = new Sunny.UI.UIProcessBar();
            this.SuspendLayout();
            // 
            // uibtnStartServer
            // 
            this.uibtnStartServer.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uibtnStartServer.Location = new System.Drawing.Point(313, 161);
            this.uibtnStartServer.MinimumSize = new System.Drawing.Size(1, 1);
            this.uibtnStartServer.Name = "uibtnStartServer";
            this.uibtnStartServer.Size = new System.Drawing.Size(165, 59);
            this.uibtnStartServer.TabIndex = 2;
            this.uibtnStartServer.Text = "开启服务";
            this.uibtnStartServer.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uibtnStartServer.Click += new System.EventHandler(this.uibtnStartServer_Click);
            // 
            // uiProcessBar1
            // 
            this.uiProcessBar1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uiProcessBar1.Location = new System.Drawing.Point(43, 263);
            this.uiProcessBar1.MinimumSize = new System.Drawing.Size(70, 3);
            this.uiProcessBar1.Name = "uiProcessBar1";
            this.uiProcessBar1.Size = new System.Drawing.Size(726, 54);
            this.uiProcessBar1.TabIndex = 3;
            this.uiProcessBar1.Text = "uiProcessBar1";
            // 
            // ServerForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.uiProcessBar1);
            this.Controls.Add(this.uibtnStartServer);
            this.Name = "ServerForm";
            this.Text = "Form1";
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 800, 450);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIButton uibtnStartServer;
        private Sunny.UI.UIProcessBar uiProcessBar1;
    }
}