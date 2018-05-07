using System;

namespace WebAPI.Models
{
    public class OptionDTO
    {
        public string Text { get; set; }

        public int Value { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        //public virtual ICollection<Question> Questions { get; set; }
    }
}