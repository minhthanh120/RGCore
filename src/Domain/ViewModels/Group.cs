using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class GroupView
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public DateTime Created {  get; set; } = DateTime.Now;
        public string CreatedBy { get; set; }
        public DateTime? Updated { get; set; } = null;
        public string? UpdatedBy { get; set;}
    }
}
