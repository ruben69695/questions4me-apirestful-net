using System;

namespace questions4me_apirestful_net.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? AnsweredAt { get; set; }
    }
}