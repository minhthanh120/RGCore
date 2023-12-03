using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Chat
{
    public class Joined
    {
        [Key]
        public string IDUser { get; set; }
        [Key]
        public string IDGroup { get; set; }
        public string Role { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? Updated { get; set; }
    }
}
