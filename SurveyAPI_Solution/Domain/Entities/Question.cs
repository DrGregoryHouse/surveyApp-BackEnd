using System.Collections.Generic;

namespace Domain.Entities
{
    public class Question : GenericItem
    {
        public string Text { get; set; }

        public bool IsActive { get; set; }

        public int QuestionTypeId { get; set; }

        public virtual QuestionType QuestionType { get; set; }

        public virtual ICollection<Survey> Surveys { get; set; }

        public virtual ICollection<Option> Options { get; set; }

        public Question()
        {
            Surveys = new HashSet<Survey>();

            Options = new HashSet<Option>();
        }
    }
}