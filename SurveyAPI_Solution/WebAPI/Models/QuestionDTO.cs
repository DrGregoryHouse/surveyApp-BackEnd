using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class QuestionDTO
    {
        public string Text { get; set; }

        public bool IsActive { get; set; }

        public int QuestionTypeId { get; set; }

        public virtual QuestionType QuestionType { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

    }
}