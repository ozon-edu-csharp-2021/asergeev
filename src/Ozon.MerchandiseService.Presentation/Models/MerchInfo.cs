using System;

namespace Ozon.MerchandiseService.Presentation.Models
{
    public class MerchInfo
    {
        public MerchInfo(bool wasIssued, string merchRank, DateTime? issueDate)
        {
            WasIssued = wasIssued;
            MerchRank = merchRank;
            IssueDate = issueDate;
        }
        public bool WasIssued { get; init; }
        public string MerchRank { get; init; }
        public DateTime? IssueDate { get; init; }
    }
}