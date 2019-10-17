using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sweets.practice.Data
{
    public class Candystore
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CSID { get; set; }

        [Display(Name = "CandyStore Location")]
        public string CSLocation { get; set; }

        [Display(Name = "CSName")]
        public string CSName { get; set; }
    }
}
