using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TravelTeam.UseCases.Tour.GetTourInfo
{
    public class GetTourInfoQuery : IRequest<TourInfoDto>
    {
        public int TourId { get; set; }
    }
}
