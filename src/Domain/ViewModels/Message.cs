using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class MessageView
    {
        public string ID { get; set; }
        public string IDUser { get; set; }
        public string IDGroup { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public string Content { get; set; }
        public string? IDParent { get; set; }
    }
}
