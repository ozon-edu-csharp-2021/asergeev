using System.Collections.Generic;
using Ozon.MerchandiseService.Domain.Models;

namespace Ozon.MerchandiseService.Domain.AggregationModels.EmployeeAggregate
{
    public class IssueStatus: ValueObject
    {
        public bool WasIssued { get;}

        public IssueStatus(bool wasIssued)
        {
            WasIssued = wasIssued;
        }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return WasIssued;
        }
    }
}