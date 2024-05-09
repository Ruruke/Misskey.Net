namespace MisskeyDotNet.Object;


    public class MiNSecBody
    {
        public string id { get; set; }
        public DateTime createdAt { get; set; }
        public string type { get; set; }
        public string userId { get; set; }
        public User user { get; set; }
        public Note note { get; set; }
        public string reaction { get; set; }
    }

    public class MiNBody
    {
        public string id { get; set; }
        public string type { get; set; }
        public MiNSecBody body { get; set; }
    }



    public class MiNotification: MiObject
    {
        public string type { get; set; }
        public MiNBody body { get; set; }
    }

