﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiKoro.Core.Models.CreateGame
{
    public class CreateGameResponse
    {
        public CreateGameResponse(Guid? scenarioId = default)
        {
            Id = scenarioId;
        }

        public Guid? Id { get; set; }
    }
}