namespace API.Entities
{
    public class UserTool
    {
        public FSUser Subscriber { get; set; }
        public int SubscriberId { get; set; }
        public Tool NotificationTool { get; set; }
        public int ToolId { get; set; }
    }
}