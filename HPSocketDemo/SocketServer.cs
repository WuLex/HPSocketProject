using Autofac.Annotation;
using HPSocket;
using HPSocket.Tcp;
using Microsoft.Extensions.Logging;

namespace HPSocketDemo
{
    [Component("SocketClient", AutofacScope = AutofacScope.SingleInstance, AutoActivate = true, InitMethod = nameof(SocketClient.Start))]
    public class SocketClient
    {
        [Autowired]
        private ILogger<SocketClient> logger;

        public void Start()
        {
            ITcpClient tcpClient = new TcpClient
            {
                // 缓冲区大小,4kb
                SocketBufferSize = 4096,
                Async = true,
                Address = "172.16.9.75",
                Port = 5013,
                KeepAliveInterval = 3000,
                KeepAliveTime = 3000
            };
            tcpClient.Async = true;
            tcpClient.Connect();
            tcpClient.OnConnect += TcpClient_OnConnect; ;
            tcpClient.OnClose += TcpClient_OnClose; ;
            tcpClient.OnReceive += TcpClient_OnReceive; ;
          
        }

        private HandleResult TcpClient_OnReceive(IClient sender, byte[] data)
        {
            logger.LogDebug("TcpClient_OnReceive");
            return HandleResult.Ok;
        }

        private HandleResult TcpClient_OnClose(IClient sender, SocketOperation socketOperation, int errorCode)
        {
            logger.LogDebug($"TcpClient_OnClose#socketOperation:{socketOperation}");
            return HandleResult.Ok;
        }

        private HandleResult TcpClient_OnConnect(IClient sender)
        {
            logger.LogDebug("TcpClient_OnConnect");
            return HandleResult.Ok;
        }
    }
}