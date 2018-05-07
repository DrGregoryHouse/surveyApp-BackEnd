using Domain.Entities;
using System;

namespace WebAPI.Models
{
    public class SurveyDTO
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public int StatusId { get; set; }

        public virtual Status Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

    }
}