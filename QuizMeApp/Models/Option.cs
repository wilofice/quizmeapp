using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuizMeApp.Models
{
    public class Option
    {
        [Key]
        public int Id { get; set; }

        public string intitule { get; set; }

        public Boolean is_correct { get; set; }

        public int QuestionId { get; set; }

        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }


    }
}