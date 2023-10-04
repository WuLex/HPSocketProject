using HPSocket;
using HPSocket.Tcp;
using System.Text;

namespace HPServer.Common
{
    public class HpSocketServer
    {
        private ITcpServer server;

        public HpSocketServer()
        {
            server = new TcpServer();
            //绑定事件
            server.OnAccept += Server_OnAccept;
            server.OnReceive += Server_OnReceive;
            server.OnClose += Server_OnClose;
        }

        public void Start()
        {
            // 缓冲区大小应根据实际业务设置, 并发数和包大小都是考虑条件
            // 都是小包的情况下4K合适, 刚好是一个内存分页(在非托管内存, 相关知识查百度)
            // 大包比较多的情况下, 应根据并发数设置比较大但是又不会爆内存的值
            server.SocketBufferSize = 4096; // 4K

            server.Address = "0.0.0.0"; // 监听所有可用的网络接口
            server.Port = 8888;           // 设置监听端口号 
            server.SocketBufferSize = 8192;
            server.KeepAliveTime = 0;     // 设置为0表示不超时

            if (server.Start())
            {
                Console.WriteLine("HP-Socket 服务器已启动。");
            }
            else
            {
                Console.WriteLine("启动 HP-Socket 服务器失败。");
            }
        }

        private HandleResult Server_OnAccept(IServer sender, IntPtr connId, IntPtr pClient)
        {
            Console.WriteLine($"客户端 {connId} 已连接。");
            return HandleResult.Ok;
        }

        private HandleResult Server_OnReceive(IServer sender, IntPtr connId, byte[] bytes)
        {
            string message = Encoding.UTF8.GetString(bytes);
            Console.WriteLine($"从 {connId} 收到消息：{message}");
            // 在这里处理接收到的消息，可以向客户端发送响应

            return HandleResult.Ok;
        }

        private HandleResult Server_OnClose(IServer sender, IntPtr connId, SocketOperation socketOperation, int errorCode)
        {
            Console.WriteLine($"客户端 {connId} 断开连接。错误代码：{errorCode}");
            return HandleResult.Ok;
        }
    }
}
