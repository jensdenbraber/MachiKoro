using MachiKoro.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace MachiKoro.Persistence.Models
{
    [Keyless]
    public class Step
    {
        public Guid PlayerId { get; set; }

        public Guid GameId { get; set; }
        public int StepIndex { get; set; }
        public ChoiceType? ChoiceType { get; set; }
        public ActionType? ActionType { get; set; }
        public string Result { get; set; } // serialize based on Choice/Action type
    }
}