using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Chat
{
    [Table("Group")]
    public class Group
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public string ID { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime Created {  get; set; } = DateTime.Now;
        public string CreatedBy { get; set; }
        public DateTime? Updated { get; set; } = null;
        public string? UpdatedBy { get; set;}
    }
}
