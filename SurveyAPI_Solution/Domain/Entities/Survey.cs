using System.Collections.Generic;

namespace Domain.Entities
{
    public class Survey : GenericItem
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public int StatusId { get; set; }

        public virtual Status Status { get; set; }

        public ICollection<Question> Questions { get; set; }

        public ICollection<Answer> Answers { get; set; }

        public Survey()
        {
            Questions = new HashSet<Question>();

            Answers = new HashSet<Answer>();
        }
    }
}
