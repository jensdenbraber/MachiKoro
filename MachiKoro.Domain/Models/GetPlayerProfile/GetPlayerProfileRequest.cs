using MediatR;
using System;

namespace MachiKoro.Core.Models.GetPlayerProfile
{
    public class GetPlayerProfileRequest : IRequest<GetPlayerProfileResponse>
    {
        public Guid PlayerId { get; set; }
    }
}
