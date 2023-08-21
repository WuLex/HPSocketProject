using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Sunny.UI;

namespace BreakpointTransmissionServer
{
    public class Server
    {
        private const int Port = 8888;
        private const string SavePath = @"D:\DDDPath\ReceivedFile.bin"; // 接收到的文件保存路径
        private bool isReceiving = false;
        private long receivedFileSize = 0;

        public void Start()
        {
            TcpListener serverSocket = new TcpListener(IPAddress.Any, Port);
            serverSocket.Start();

            UIMessageBox.Show("服务器已启动，正在等待连接...", "服务端提示");
            while (true)
            {
                TcpClient clientSocket = serverSocket.AcceptTcpClient();
                UIMessageBox.Show("客户端已连接！","服务端提示");
                isReceiving = true;
                receivedFileSize = 0;

                // 多线程处理接收文件
                Thread thread = new Thread(() =>
                {
                    ReceiveFile(clientSocket);
                });
                thread.Start();
            }
        }

        private void ReceiveFile(TcpClient clientSocket)
        {
            using (clientSocket)
            {
                using (NetworkStream networkStream = clientSocket.GetStream())
                {
                    byte[] receivedBuffer = new byte[1024];
                    int bytesRead;

                    //追加文件流,服务器端保存的文件会越来越大
                    //using (FileStream fileStream = new FileStream(SavePath, FileMode.Append))
                    //创建或者覆盖
                    using (FileStream fileStream = new FileStream(SavePath, FileMode.OpenOrCreate))
                    {
                        while (isReceiving && (bytesRead = networkStream.Read(receivedBuffer, 0, receivedBuffer.Length)) > 0)
                        {
                            fileStream.Write(receivedBuffer, 0, bytesRead);
                            receivedFileSize += bytesRead;
                        }
                    }
                }
            }

            UIMessageBox.Show("文件已收到并保存", "服务端提示");
        }
    }
}
