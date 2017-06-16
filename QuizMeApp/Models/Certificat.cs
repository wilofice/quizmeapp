using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuizMeApp.Models
{
    public class Certificat
    {
        [Key]
        public int Id { get; set; }
        public string description { get; set; }

        public int EvaluationId { get; set; }

        [ForeignKey("EvaluationId")]
        public virtual Evaluation Evaluation { get; set; }
    }
}