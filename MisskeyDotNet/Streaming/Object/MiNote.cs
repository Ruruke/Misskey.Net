namespace MisskeyDotNet.Object;

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Body
    {
        public string id { get; set; }
        public string type { get; set; }
        public MiNSBody body { get; set; }
    }

    public class MiNSBody
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
        public List<object> reactionAndUserPairCache { get; set; }
        public List<object> fileIds { get; set; }
        public List<object> files { get; set; }
        public object replyId { get; set; }
        public object renoteId { get; set; }
        public int clippedCount { get; set; }
    }

    public class MiNote : MiObject
    {
        public string type { get; set; }
        public Body body { get; set; }
    }

