using MachiKoro.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace MachiKoro.Persistence.Models
{
    public class Step
    {
        [Key]
        public Guid Id { get; set; }

        public Guid GameId { get; set; }
        public Game Game { get; set; }
        public Guid PlayerId { get; set; }
        public Player Player { get; set; }
        public int StepIndex { get; set; }
        public ChoiceType? ChoiceType { get; set; }
        public ActionType? ActionType { get; set; }
        public string Result { get; set; } // serialize based on Choice/Action type
    }
}