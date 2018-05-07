using System.Collections.Generic;

namespace Domain.Entities
{
    public class Answer : GenericItem
    {
        public string Guest { get; set; }

        public string OpenText { get; set; }

        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }

        public virtual ICollection<Option> Options { get; set; }

        public virtual ICollection<Survey> Surveys { get; set; }

        public Answer()
        {
            Options = new HashSet<Option>();

            Surveys = new HashSet<Survey>();
        }

    }
}