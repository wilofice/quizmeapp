using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuizMeApp.Models
{
    public class Evaluation
    {
        [Key]
        public int Id { get; set; }

        public string date_creation { get; set; }
        public string description { get; set; }

        public string type { get; set; }
        public int scoreSuccess { get; set; }

        public string EnseignantId { get; set; }

        [ForeignKey("EnseignantId")]
        public virtual Enseignant Enseignant { get; set; }

        public virtual ICollection<Question> Questions { get; set; }

        public virtual ICollection<Score> Scores { get; set; }

        
        public virtual ICollection<Certificat> Certificats { get; set; }


    }
}
