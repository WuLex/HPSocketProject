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
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void uibtnSendFile_Click(object sender, EventArgs e)
        {
            client.SendFile();
        }

        private void Client_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // �ڽ������ĸ��·����н�ProgressChangedEventArgs.ProgressPercentage��ֵ����������Value����
            uiProcessBar1.Value = (int)e.ProgressPercentage;
        }
    }
}