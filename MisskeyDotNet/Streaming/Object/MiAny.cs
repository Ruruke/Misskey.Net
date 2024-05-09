namespace MisskeyDotNet.Object;
// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

public class AnyBody
{
    public string id { get; set; }
    public string type { get; set; }
}


public class MiAny : MiObject
{
    public string type { get; set; }
    public AnyBody body { get; set; }
}

public class AvatarDecoration
{
    public string id { get; set; }
    public double angle { get; set; }
    public string url { get; set; }
    public double? offsetX { get; set; }
    public double? offsetY { get; set; }
}

public class BadgeRole
{
    public string name { get; set; }
    public string iconUrl { get; set; }
    public int displayOrder { get; set; }
}


public class Emojis
{
}

public class Note
{
    public string id { get; set; }
    public DateTime createdAt { get; set; }
    public string userId { get; set; }
    public User user { get; set; }
    public string text { get; set; }
    public object cw { get; set; }
    public string visibility { get; set; }
    public bool localOnly { get; set; }
    public object reactionAcceptance { get; set; }
    public int renoteCount { get; set; }
    public int repliesCount { get; set; }
    public int reactionCount { get; set; }
    // public Reactions reactions { get; set; } //TODO
    // public ReactionEmojis reactionEmojis { get; set; } // TODO
    public List<object> fileIds { get; set; }
    public List<object> files { get; set; }
    public object replyId { get; set; }
    public object renoteId { get; set; }
    public List<string> mentions { get; set; }
    public int clippedCount { get; set; }
}

public class User
{
    public string id { get; set; }
    public string name { get; set; }
    public string username { get; set; }
    public object host { get; set; }
    public string avatarUrl { get; set; }
    public string avatarBlurhash { get; set; }
    public List<AvatarDecoration> avatarDecorations { get; set; }
    public bool isBot { get; set; }
    public bool isCat { get; set; }
    public Emojis emojis { get; set; }
    public string onlineStatus { get; set; }
    public List<BadgeRole> badgeRoles { get; set; }
}