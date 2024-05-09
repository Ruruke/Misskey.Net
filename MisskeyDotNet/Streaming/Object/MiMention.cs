namespace MisskeyDotNet.Object;
// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class MiMSbody
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
        public Reactions reactions { get; set; }
        public ReactionEmojis reactionEmojis { get; set; }
        public List<object> fileIds { get; set; }
        public List<object> files { get; set; }
        public object replyId { get; set; }
        public object renoteId { get; set; }
        public List<string> mentions { get; set; }
        public int clippedCount { get; set; }
    }

    public class MiMBody
    {
        public string id { get; set; }
        public string type { get; set; }
        public MiMSbody body { get; set; }
    }


    public class ReactionEmojis
    {
    }

    public class Reactions
    {
    }

    public class MiMention : MiObject
    {
        public string type { get; set; }
        public MiMBody body { get; set; }
    }

