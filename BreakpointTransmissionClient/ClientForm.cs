using Sunny.UI;
using static BreakpointTransmissionClient.Client;

namespace BreakpointTransmissionClient
{
    public partial class ClientForm : UIForm
    {
        private Client client;

        public ClientForm()
        {
            InitializeComponent();
            client = new Client();
            client.ProgressChanged += Client_ProgressChanged;
            // 设置文件选择按钮的点击事件处理程序
            uibtnSelectFile.Click += uibtnSelectFile_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void uibtnSendFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(uiTxtFilePath.Text))
                {
                    client.SendFile();
                }
                else
                {
                    // 调用文件选择按钮的点击事件处理程序，选择要上传的文件
                    uibtnSelectFile_Click(sender, e);
                    client.SendFile();
                }
            }
            catch (Exception ex)
            {
                UIMessageBox.ShowInfo(ex.Message);
            }
        }

        private void Client_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // 在进度条的更新方法中将ProgressChangedEventArgs.ProgressPercentage赋值给进度条的Value属性
            uiProcessBar1.Value = (int)e.ProgressPercentage;
        }

        private void uibtnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                // 将选择的文件路径存储到成员变量中
                client.FilePath = filePath;
                uiTxtFilePath.Text = filePath;
            }
        }
    }
}