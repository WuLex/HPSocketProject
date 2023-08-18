
using GameApp;

GameClient client = new GameClient();

// 连接服务器并开始游戏
client.Connect();
if (client.isConnected)
{
    client.PlayGame();
}

// 模拟断线重连
client.Reconnect();

Console.ReadKey();