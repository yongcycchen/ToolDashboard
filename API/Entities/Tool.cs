using System.Collections.Generic;

namespace API.Entities
{
    public class Tool
    {
        public int Id { get; set; }
        public string ToolName { get; set; }
        public FSUser  FirstLevelOwner { get; set; }
        public FSUser SecondLevelOwner { get; set; }
        public FSUser HardwareSupport { get; set; }
        public ICollection<UserTool> NotificationList { get; set; }
    }
}