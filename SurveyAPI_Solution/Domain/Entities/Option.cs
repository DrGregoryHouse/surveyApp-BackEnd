using System.Collections.Generic;

namespace Domain.Entities
{
    public class Option : GenericItem
    {
        public string Text { get; set; }

        public int Value { get; set; }

        public virtual ICollection<Question> Questions { get; set; }

        public Option()
        {
            Questions = new HashSet<Question>();
        }

    }
}