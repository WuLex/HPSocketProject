namespace BreakpointTransmissionClient
{
    partial class ClientForm
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
            this.uibtnSendFile = new Sunny.UI.UIButton();
            this.uiProcessBar1 = new Sunny.UI.UIProcessBar();
            this.uilblStatusName = new Sunny.UI.UILabel();
            this.uilblStatus = new Sunny.UI.UILabel();
            this.SuspendLayout();
            // 
            // uibtnSendFile
            // 
            this.uibtnSendFile.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uibtnSendFile.Location = new System.Drawing.Point(565, 180);
            this.uibtnSendFile.MinimumSize = new System.Drawing.Size(1, 1);
            this.uibtnSendFile.Name = "uibtnSendFile";
            this.uibtnSendFile.Size = new System.Drawing.Size(196, 62);
            this.uibtnSendFile.TabIndex = 4;
            this.uibtnSendFile.Text = "发送文件";
            this.uibtnSendFile.Click += new System.EventHandler(this.uibtnSendFile_Click);
            // 
            // uiProcessBar1
            // 
            this.uiProcessBar1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uiProcessBar1.Location = new System.Drawing.Point(23, 180);
            this.uiProcessBar1.MinimumSize = new System.Drawing.Size(70, 3);
            this.uiProcessBar1.Name = "uiProcessBar1";
            this.uiProcessBar1.Size = new System.Drawing.Size(524, 62);
            this.uiProcessBar1.TabIndex = 6;
            this.uiProcessBar1.Text = "uiSendProcessBar";
            // 
            // uilblStatusName
            // 
            this.uilblStatusName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uilblStatusName.Location = new System.Drawing.Point(23, 289);
            this.uilblStatusName.Name = "uilblStatusName";
            this.uilblStatusName.Size = new System.Drawing.Size(73, 39);
            this.uilblStatusName.TabIndex = 7;
            this.uilblStatusName.Text = "状态:";
            this.uilblStatusName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uilblStatus
            // 
            this.uilblStatus.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uilblStatus.Location = new System.Drawing.Point(84, 294);
            this.uilblStatus.Name = "uilblStatus";
            this.uilblStatus.Size = new System.Drawing.Size(142, 29);
            this.uilblStatus.TabIndex = 8;
            this.uilblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ClientForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.uilblStatus);
            this.Controls.Add(this.uilblStatusName);
            this.Controls.Add(this.uiProcessBar1);
            this.Controls.Add(this.uibtnSendFile);
            this.Name = "ClientForm";
            this.Text = "Form1";
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 800, 450);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIButton uibtnSendFile;
        private Sunny.UI.UIProcessBar uiProcessBar1;
        private Sunny.UI.UILabel uilblStatusName;
        private Sunny.UI.UILabel uilblStatus;
    }
}