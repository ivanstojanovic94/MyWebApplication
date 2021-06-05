using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApplication.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Name")]
        [Required]
        public string Name { get; set; }
        [DisplayName("Display Orders")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage="Dispaly Order for Category must be greater then 0")]
        public int DisplayOrder { get; set; }
         
    }
}
