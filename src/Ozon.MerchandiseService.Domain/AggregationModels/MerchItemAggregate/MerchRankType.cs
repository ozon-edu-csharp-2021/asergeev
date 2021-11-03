using Ozon.MerchandiseService.Domain.Models;

namespace Ozon.MerchandiseService.Domain.AggregationModels.MerchItemAggregate
{
    public class MerchRankType: Enumeration
    {
        public static MerchRankType WelcomePack = new(1, nameof(WelcomePack));
        public static MerchRankType ConferenceListenerPack = new(2, nameof(ConferenceListenerPack));
        public static MerchRankType ConferenceSpeakerPack = new(3, nameof(ConferenceSpeakerPack));
        public static MerchRankType ProbationPeriodEndingPack = new(4, nameof(ProbationPeriodEndingPack));
        public static MerchRankType VeteranPack = new(5, nameof(VeteranPack));
        
        public MerchRankType(int id, string name) : base(id, name)
        {
        }
    }
}