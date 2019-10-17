using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sweets.practice.Data
{
    public class Owners
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OID { get; set; }
        public string OL { get; set; }
        public string ON { get; set; }



        //foreign key
        public int CID { get; set; }

        [ForeignKey("CID")]
        public Candy Can { get; set; }

        //foreign key
        public int CSID { get; set; }

        [ForeignKey("CSID")]
        public Candystore candystoreS { get; set; }
    }
}
