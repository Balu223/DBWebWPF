using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BYLLQ0_HFT_2022232.Models
{
    public class Label
    {
        public Label()
        {
            Artists = new HashSet<Artist>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LabelId { get; set; }
        public string LabelName { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Artist> Artists { get; set; }

        public Label(string data)
        {
            string[] d = data.Split('#');
            LabelId = int.Parse(d[0]);
            LabelName = d[1];
            Address = d[2];
            Artists = new HashSet<Artist>();
        }
    }
}
