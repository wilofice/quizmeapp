using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuizMeApp.Models
{
    public class Apprenant
    {
        [Key]
        public string ID { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public virtual ICollection<Reponse> Reponses { get; set; }
        public virtual ICollection<Score> Scores { get; set; }
    }
}