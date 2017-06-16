using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuizMeApp.Models
{
    public class Reponse
    {
        [Key]
        public int Id { get; set; }

        public string choix { get; set; }
        public string dateReponse { get; set; }

        public int QuestionId { get; set; }

        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }

        public string ApprenantId { get; set; }

        [ForeignKey("ApprenantId")]
        public virtual Apprenant Apprenant { get; set; }


    }
}