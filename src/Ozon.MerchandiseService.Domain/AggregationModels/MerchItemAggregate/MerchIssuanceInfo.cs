using System;
using Ozon.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using Ozon.MerchandiseService.Domain.Models;

namespace Ozon.MerchandiseService.Domain.AggregationModels.MerchItemAggregate
{
    public class MerchIssuanceInfo: Entity
    {
        public MerchRankType MerchRankType { get; }
        public IssueStatus IssueStatus { get; }
        public DateTime? IssuanceDate { get; }

        public MerchIssuanceInfo(MerchRankType merchRankType, IssueStatus issueStatus, DateTime? issuanceDate)
        {
            MerchRankType = merchRankType;
            IssuanceDate = issuanceDate ?? DateTime.Now;
            IssueStatus = issueStatus;
        }

        public MerchIssuanceInfo()
        {
            MerchRankType = null;
            IssueStatus = new IssueStatus(false);
            IssuanceDate = null;
        }
    }
}