using Discord.WebSocket;
using System;
using WebSocket4Net;

class WebSocketTest
{
    public void Main()
    {
        var websocket = new WebSocket("ws://example.com:81/...");

        websocket.Opened += Websocket_Opened;
        websocket.MessageReceived += Websocket_MessageReceived;
        websocket.Closed += Websocket_Closed;
        websocket.DataReceived += Websocket_DataReceived;
        websocket.Error += Websocket_Error;

        websocket.AutoSendPingInterval = 30;
        websocket.EnableAutoSendPing = true;

        websocket.Open();

        Console.ReadKey();
    }

    /// <summary>
    /// WebSocketの機能をオンにするか
    /// </summary>
    /// <param name="messageEvent"></param>
    public void WebSocketOpenCheck(SocketMessage messageEvent)
    {
        if (0 <= messageEvent.Content.IndexOf("websocket"))
        {
            function.webhookFlag = !function.webhookFlag;
            messageEvent.Channel.SendMessageAsync("websocketの機能を" + function.webhookFlag.ToString() + "にしました");
            function.commandUser = null;
        }
        else
        {
            messageEvent.Channel.SendMessageAsync("何もないようなので終了します");
            function.commandUser = null;
        }
    }

    private static void Websocket_Opened(object sender, EventArgs e)
    {
        Console.WriteLine("Websocket_Opened");
    }

    private static void Websocket_Error(object sender, SuperSocket.ClientEngine.ErrorEventArgs e)
    {
        Console.WriteLine("Websocket_Error");
    }

    private static void Websocket_DataReceived(object sender, DataReceivedEventArgs e)
    {
        Console.WriteLine($"Websocket_DataReceived { e.Data }");
    }

    private static void Websocket_Closed(object sender, EventArgs e)
    {
        Console.WriteLine("closed");
    }

    private static void Websocket_MessageReceived(object sender, MessageReceivedEventArgs e)
    {
        Console.WriteLine($"Websocket_MessageReceived { e.Message }");
    }
}
