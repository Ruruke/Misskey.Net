using System.Text.Json.Serialization;

namespace MisskeyDotNet.WebAPI;

public class MiSendNote
{
    public string i { get; set;}
    public string visibility { get; set; } = "public";
    public List<string> visibleUserIds { get; set; } = new();
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string cw { get; set; } = null;
    public bool localOnly { get; set; } = false;
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object reactionAcceptance { get; set; } = null;
    public bool noExtractMentions { get; set; } = false;
    public bool noExtractHashtags { get; set; } = false;
    public bool noExtractEmojis { get; set; } = false;
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string replyId { get; set; } = null;
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object renoteId { get; set; } = null;
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string channelId { get; set; } = null!;
    public string text { get; set; } = "";
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object fileIds { get; set; } = null;
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object mediaIds { get; set; } = null;
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object poll { get; set; } = null;
}