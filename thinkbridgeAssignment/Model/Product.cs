using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace thinkbridgeAssignment.Model
{
    public partial class Product
    {
        [Key]
        public int ProductId { get; set; }
        
        [MaxLength(50,ErrorMessage ="Name Should be max 50 characters")]
        public string Name { get; set; }

        [MaxLength(100,ErrorMessage = "Description Should be max 100 characters")]
        public string Description { get; set; }
        public decimal Prise { get; set; }
    }
}
