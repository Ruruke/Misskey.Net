
using System.Text;
using System.Text.Json;
using MisskeyDotNet.Object;
using MisskeyDotNet.Streaming;
using MisskeyDotNet.Streaming.Event;
using WebSocket4Net;

namespace SampleApp;

public abstract class SampleApp
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.GetEncoding("utf-8"); // コンソールの文字コードいい加減UTF-8に統一してくれねぇの？
        String tokenFile = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule?.FileName)+Path.DirectorySeparatorChar+"token.txt"!; 
        // Console.WriteLine(tokenFile);
        if (!File.Exists(tokenFile))
        {
            Console.WriteLine("cannot find token.txt");
            Environment.Exit(-1);
        }
        Task.Run(() =>
        {
            

            string token = new StreamReader(tokenFile, Encoding.UTF8).ReadToEnd();
            MiStreaming mi = new MiStreaming("main", "foo",token);
            mi.Connect += MiOnConnect;
            mi.MessageReceived += MiOnMessageReceived;
            mi.start();
        });
        Console.ReadKey();
    }

    private static void MiOnMessageReceived(object? sender, MiStreamMessageReceived e)
    {
        if (e.type == MiStreamEventType.Mention)
        {
            Console.WriteLine((e.message as MiMention)?.body.body.text);
        }
    }

    private static void MiOnConnect(object? sender, MiStreamConnect e)
    {
        Console.WriteLine("CONNECT EVENT!");
    }
}