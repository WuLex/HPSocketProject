using HPSocket;
using HPSocket.Sdk;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Collections.Generic;
using HPSocket.Tcp;
using System.Windows;

namespace ClientApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ITcpClient tcpClient;
        /// <summary>
        /// 封包, 用于处理粘包
        /// </summary>
        private readonly List<byte> _packetData = new List<byte>();

        /// <summary>
        /// 最大封包长度
        /// </summary>
        private const int MaxPacketSize = 4096;

        private string serverIP= "127.0.0.1";
        private int serverPort=8888;
        private string message;
        private ObservableCollection<string> chatLog = new ObservableCollection<string>();

        public string ServerIP
        {
            get { return serverIP; }
            set { serverIP = value; OnPropertyChanged("ServerIP"); }
        }

        public int ServerPort
        {
            get { return serverPort; }
            set { serverPort = value; OnPropertyChanged("ServerPort"); }
        }

        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }

        public ObservableCollection<string> ChatLog
        {
            get { return chatLog; }
            set { chatLog = value; OnPropertyChanged("ChatLog"); }
        }

        public ICommand ConnectCommand { get; }
        public ICommand SendCommand { get; }

        public MainViewModel()
        {
            ConnectCommand = new RelayCommand(Connect);
            SendCommand = new RelayCommand(Send);
        }

        private void Connect()
        {
            // 添加连接到服务器的逻辑
            tcpClient = new TcpClient();

            // 设置客户端属性
            // 缓冲区大小
            tcpClient.SocketBufferSize = 4096; // 4K
            // 异步连接
            tcpClient.Async = true;

            // 事件绑定
            tcpClient.OnConnect += TcpClient_OnConnect;

            // 设置服务器的IP地址和端口号
            string serverIP = ServerIP;
            ushort serverPort = (ushort)ServerPort;

            if (tcpClient.Connect(serverIP, serverPort))
            {
                _packetData.Clear();
                // 连接成功
                ChatLog.Add($"已连接到服务器 {serverIP}。");
            }
            else
            {
                // 连接失败
                ChatLog.Add($"无法连接到服务器 {serverIP}。");
            }
        }

        private HandleResult TcpClient_OnConnect(IClient sender)
        {
            // 使用 Dispatcher 在 UI 线程上更新 ObservableCollection
            Application.Current.Dispatcher.Invoke(() =>
            {
                // 在 UI 线程上更新 ObservableCollection
                ChatLog.Add($"已连接到服务器 {serverIP}。");
            });
            return HandleResult.Ok;
        }

        private void Send()
        {
            // 添加发送消息到服务器的逻辑
            if (tcpClient == null || !tcpClient.IsConnected)
            {
                ChatLog.Add("未连接到服务器，请先连接。");
                return;
            }

            string message = Message;
            byte[] bytes = Encoding.UTF8.GetBytes(message);

            if (tcpClient.Send(bytes, bytes.Length))
            {
                ChatLog.Add($"已发送消息：{message}");
            }
            else
            {
                ChatLog.Add("无法发送消息到服务器。");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
