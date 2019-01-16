using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventoMedia.Models
{   [NotMapped]
    public class Tagi
    {
        [Key]
        public int TagID { get; set; }
        public string TagName { get; set; }
        public string TagDescription { get; set; }
        public bool IsChosen { get; set; }
    }
}
