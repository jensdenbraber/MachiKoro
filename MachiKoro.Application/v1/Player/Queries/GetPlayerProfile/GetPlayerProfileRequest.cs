using MediatR;
using System;

namespace MachiKoro.Application.v1.Player.Queries.GetPlayerProfile
{
    public class GetPlayerProfileRequest : IRequest<GetPlayerProfileResponse>
    {
        public Guid PlayerId { get; set; }
    }
}
