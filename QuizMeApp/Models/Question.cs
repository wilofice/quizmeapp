using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuizMeApp.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        public string enonce { get; set; }
        public int point { get; set; }
        public int niveauDifficulte { get; set; }
        public string explication { get; set; }

        public int EvaluationId { get; set; }
        [ForeignKey("EvaluationId")]
        public virtual Evaluation Evaluation { get; set; }

        public virtual ICollection<Option> Options { get; set; }

        public virtual ICollection<Reponse> Reponses { get; set; }
    }
}