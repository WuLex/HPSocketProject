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
            this.SuspendLayout();
            // 
            // uibtnStartServer
            // 
            this.uibtnStartServer.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uibtnStartServer.Location = new System.Drawing.Point(306, 212);
            this.uibtnStartServer.MinimumSize = new System.Drawing.Size(1, 1);
            this.uibtnStartServer.Name = "uibtnStartServer";
            this.uibtnStartServer.Size = new System.Drawing.Size(165, 59);
            this.uibtnStartServer.TabIndex = 2;
            this.uibtnStartServer.Text = "开启服务";
            this.uibtnStartServer.Click += new System.EventHandler(this.uibtnStartServer_Click);
            // 
            // ServerForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.uibtnStartServer);
            this.Name = "ServerForm";
            this.Text = "服务端";
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 800, 450);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIButton uibtnStartServer;
    }
}