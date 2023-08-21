using Sunny.UI;

namespace BreakpointTransmissionServer
{
    public partial class ServerForm : UIForm
    {
        //public event EventHandler<FileReceivedEventArgs> FileReceived;

        //private const int Port = 8888;
        //private const string SavePath = @"C:\Temp\ReceivedFile.bin"; // 接收到的文件保存路径
        //private bool isReceiving = false;
        //private long receivedFileSize = 0;
        //private long totalFileSize = 0;
        private Server server;

        public ServerForm()
        {
            InitializeComponent();
            server = new Server();
           

        }

        //private void Server_FileReceived(object sender, FileReceivedEventArgs e)
        //{
        //    if (e.IsCompleted)
        //    {
        //        lblStatus.Text = "File received and saved.";
        //        progressBar.Value = 100;
        //    }
        //    else
        //    {
        //        lblStatus.Text = $"Receiving file: {e.ReceivedFileSize} bytes received.";
        //        progressBar.Value = (int)((double)e.ReceivedFileSize / e.TotalFileSize * 100);
        //    }
        //}

        private void uibtnStartServer_Click(object sender, EventArgs e)
        {
            uibtnStartServer.Enabled = false;
            server.Start();
        }
    }
}