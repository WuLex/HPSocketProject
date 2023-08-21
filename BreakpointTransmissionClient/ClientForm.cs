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
            // �����ļ�ѡ��ť�ĵ���¼��������
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
                    // �����ļ�ѡ��ť�ĵ���¼��������ѡ��Ҫ�ϴ����ļ�
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
            // �ڽ������ĸ��·����н�ProgressChangedEventArgs.ProgressPercentage��ֵ����������Value����
            uiProcessBar1.Value = (int)e.ProgressPercentage;
        }

        private void uibtnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                // ��ѡ����ļ�·���洢����Ա������
                client.FilePath = filePath;
                uiTxtFilePath.Text = filePath;
            }
        }
    }
}