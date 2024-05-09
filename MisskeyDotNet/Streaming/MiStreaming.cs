using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text.Json;
using MisskeyDotNet.Object;
using MisskeyDotNet.Streaming.Event;
using WebSocket4Net;
using WebSocket = WebSocket4Net.WebSocket;

namespace MisskeyDotNet.Streaming;

public class MiStreaming
{
    private String _ch = "";
    private String _id = "";
    private String _token = "";
    private String _baseUrl = "";
    private event EventHandler<MiStreamConnect> _ConnectEvent;
    private event EventHandler<MiStreamDisconnect> _DisconnectEvent;
    private event EventHandler<MiStreamMessageReceived> _MiStreamMessageReceived;
    
    

    public event EventHandler<MiStreamConnect> Connect
    {
        add => this._ConnectEvent += value;
        remove => this._ConnectEvent -= value;
    }
    public event EventHandler<MiStreamDisconnect> Disconnect
    {
        add => this._DisconnectEvent += value;
        remove => this._DisconnectEvent -= value;
    }
    public event EventHandler<MiStreamMessageReceived> MessageReceived
    {
        add => this._MiStreamMessageReceived += value;
        remove => this._MiStreamMessageReceived -= value;
    }
    public MiStreaming(String channel, String id, String token, String baseUrl = "misskey.io")
    {
        _ch = channel;
        _id = id;
        _token = token;
        _baseUrl = baseUrl;
    }
    
    private WebSocket _websocket = null!;
    public void start()
    {
        _websocket = new WebSocket($"wss://{_baseUrl}/streaming?i={_token}");
        _websocket.Opened += websocket_Opened;
        _websocket.Error += websocket_Error;
        _websocket.Closed += websocket_Closed;
        _websocket.MessageReceived += websocket_MessageReceived;
        _websocket.AutoSendPingInterval = 10;
        _websocket.EnableAutoSendPing = true;
        _websocket.Open();
    }

    private void websocket_MessageReceived(object? sender, MessageReceivedEventArgs e)
    {
        Console.WriteLine("Received : "+e.Message);
        MiAny miAny = JsonSerializer.Deserialize<MiAny>(e.Message)!;
        Console.WriteLine("Type > "+miAny.body.type);
        MiStreamMessageReceived args;
        switch (miAny.body.type)
        {
            case "mention":
                MiMention miMention = JsonSerializer.Deserialize<MiMention>(e.Message)!;
                Console.WriteLine(miMention.body.body.text);
                args = new MiStreamMessageReceived() { type = MiStreamEventType.Mention ,message = miMention};
                _MiStreamMessageReceived.Invoke(this,args);
                break;
            
            case "notification":
                MiNotification miNotification = JsonSerializer.Deserialize<MiNotification>(e.Message)!;
                Console.WriteLine(miNotification.body.body.type);
                args = new MiStreamMessageReceived() { type = MiStreamEventType.Notification ,message = miNotification};
                _MiStreamMessageReceived.Invoke(this,args);
                break;
        }
    }

    private void websocket_Closed(object? sender, EventArgs e)
    {
        Console.WriteLine("Closed.");
        _DisconnectEvent.Invoke(this,null!);
        //RE CONNECT
        Console.WriteLine("RECONNECT");
        start();
    }

    private void websocket_Error(object? sender, SuperSocket.ClientEngine.ErrorEventArgs e)
    {
        _DisconnectEvent.Invoke(this,null!);
        throw new SocketException();
    }


    private void websocket_Opened(object sender, EventArgs e)
    {
        Console.WriteLine("Opend");
        // websocket.Send("{\"type\": \"connect\", \"body\": {\"channel\": \"localTimeline\", \"id\": \"test\"}}");

        _websocket.Send($"{{\"type\": \"connect\", \"body\": {{\"channel\": \"{_ch}\", \"id\": \"{_id}\"}}}}");
        _ConnectEvent.Invoke(this,null!);
    }
}