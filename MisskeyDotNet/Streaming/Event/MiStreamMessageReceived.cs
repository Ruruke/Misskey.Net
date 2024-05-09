using MisskeyDotNet.Object;

namespace MisskeyDotNet.Streaming.Event;

public class MiStreamMessageReceived : EventArgs
{
    public MiStreamEventType type { get; set; } = MiStreamEventType.Other;
    public MiObject message { get; set; } = null!;
}
