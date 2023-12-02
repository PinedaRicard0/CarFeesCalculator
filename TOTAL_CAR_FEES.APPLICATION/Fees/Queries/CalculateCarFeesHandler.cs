using System;
using MediatR;

namespace TOTAL_CAR_FEES.APPLICATION.Fees.Queries
{
	public class CalculateCarFeesHandler : IRequestHandler<CalculateCarFeesQuery, string>
	{
		public CalculateCarFeesHandler()
		{
		}

        public Task<string> Handle(CalculateCarFeesQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

