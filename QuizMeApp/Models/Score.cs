using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuizMeApp.Models
{
    public class Score
    {
        [Key]
        public int Id { get; set; }

        public int score { get; set; }

        public int EvaluationId { get; set; }
        [ForeignKey("EvaluationId")]
        public virtual Evaluation Evaluation { get; set; }

        public string ApprenantId { get; set; }

        [ForeignKey("ApprenantId")]
        public virtual Apprenant Apprenant { get; set; }
    }
}