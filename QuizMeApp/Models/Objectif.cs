using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuizMeApp.Models
{
    public class Objectif
    {
        [Key]
        public int Id { get; set; }
        public string intitule { get; set; }

        public virtual ICollection<SousObjectif> SousObjectifs { get; set; }

        public int CoursId { get; set; }

        [ForeignKey("CoursId")]
        public virtual Cours Cours { get; set; }
    }
}