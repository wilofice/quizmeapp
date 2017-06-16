using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuizMeApp.Models
{
    public class Enseignant
    {
        [Key]
        public string ID { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }

        public virtual ICollection<Cours> Cours { get; set; }
        public virtual ICollection<Evaluation> Evaluations { get; set; }

    }
}