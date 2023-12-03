using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Chat
{
    public class Message
    {
        public string ID { get; set; }
        public string IDUser { get; set; }
        public string IDGroup { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime? Updated { get; set; }
        public string Content { get; set; }
        public string? IDParent { get; set; }
    }
}
