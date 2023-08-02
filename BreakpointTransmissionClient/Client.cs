using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BreakpointTransmissionClient
{
    public class Client
    {
        public event EventHandler<ProgressChangedEventArgs> ProgressChanged;

        private const int Port = 8888;
        private const string ServerAddress = "127.0.0.1";
        private const string FilePath = @"D:\DDDPath\File.bin"; // 要传输的文件路径

        public void SendFile()
        {
            TcpClient clientSocket = new TcpClient();
            clientSocket.Connect(ServerAddress, Port);
            UIMessageBox.ShowInfo("已连接到服务器");
           
            using (clientSocket)
            {
                using (NetworkStream networkStream = clientSocket.GetStream())
                {
                    using (FileStream fileStream = new FileStream(FilePath, FileMode.Open))
                    {
                        long totalFileSize = fileStream.Length;
                        byte[] totalFileSizeBytes = Encoding.ASCII.GetBytes(totalFileSize.ToString());
                        networkStream.Write(totalFileSizeBytes, 0, totalFileSizeBytes.Length);

                        byte[] buffer = new byte[1024];
                        int bytesRead;
                        long totalBytesSent = 0;

                        while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            networkStream.Write(buffer, 0, bytesRead);
                            totalBytesSent += bytesRead;

                            // 触发事件，更新进度条
                            OnProgressChanged(totalBytesSent, totalFileSize);
                        }

                        //byte[] buffer = new byte[1024];
                        //int bytesRead;

                        //while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                        //{
                        //    networkStream.Write(buffer, 0, bytesRead);
                        //}
                    }
                }
            }
            UIMessageBox.ShowInfo("文件已发送");
            // 文件发送完成时，触发事件以更新进度条
            OnProgressChanged(100, 100);
        }
        private void OnProgressChanged(long bytesSent, long totalFileSize)
        {
            double progressPercentage = (double)bytesSent / totalFileSize * 100;
            ProgressChanged?.Invoke(this, new ProgressChangedEventArgs(progressPercentage));
        }
        public class ProgressChangedEventArgs : EventArgs
        {
            public double ProgressPercentage { get; }

            public ProgressChangedEventArgs(double progressPercentage)
            {
                ProgressPercentage = progressPercentage;
            }
        }
    }
}
