using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuizMeApp.Models
{
    public class SousObjectif
    {
        [Key]
        public int Id { get; set; }
        public string intitule { get; set; }

        public int ObjectifId { get; set; }

        [ForeignKey("ObjectifId")]
        public virtual Objectif Objectif { get; set; }
    }
}