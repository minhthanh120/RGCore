using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Chat
{
    public class Group
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime Created {  get; set; } = DateTime.Now;
        public string CreatedBy { get; set; }
        public DateTime? Updated { get; set; }
        public string? UpdatedBy { get; set;}
    }
}
