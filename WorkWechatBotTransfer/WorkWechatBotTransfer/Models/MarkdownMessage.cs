namespace WorkWechatBotTransfer.Models
{
    public class MarkdownMessage
    {
        public string msgtype { get; set; }

        public MarkdownContent markdown { get; set; }
        
        
    }

    public class MarkdownContent
    {
        public string content { get; set; }
    }
}
