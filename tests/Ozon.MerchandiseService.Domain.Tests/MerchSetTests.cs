using System.Collections.Generic;
using Ozon.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using Ozon.MerchandiseService.Domain.Exceptions;
using Xunit;

namespace Ozon.MerchandiseService.Domain.Tests
{
    public class MerchSetTests
    {
        [Fact]
        public void CreateMerchSetCurrect()
        {
            MerchSet merchSetCorrect = new MerchSet(
                new List<MerchItem>(){
                    new MerchItem(
                        new Id(1),
                        new MerchName("Ozon.SomeName"),
                        new Item(ItemType.TShirt),
                        MerchRankType.WelcomePack,
                        ClothingSize.M),
                    
                    new MerchItem(
                        new Id(2),
                        new MerchName("Ozon.SomeName"), 
                        new Item(ItemType.Notepad),
                        MerchRankType.WelcomePack,
                        ClothingSize.NO),
                    
                    new MerchItem(
                        new Id(3),
                        new MerchName("Ozon.SomeName"),
                        new Item(ItemType.Sweatshirt),
                        MerchRankType.WelcomePack,
                        ClothingSize.M)
                }
            );
            
            Assert.Equal(MerchRankType.WelcomePack,merchSetCorrect.Set[1].MerchRank);
        }

        [Fact]
        public void CreateMerchSetWithZeroItemsFail()
        {
            Assert.Throws<ZeroMerchItemsInListException>(() =>
                new MerchSet(new List<MerchItem>())
            );
        }

        [Fact]
        public void CreateMerchSetWithDifferentMerchRankFail()
        {
            Assert.Throws<DifferentMerchRankException>(() =>
                new MerchSet(
                    new List<MerchItem>()
                    {
                        new MerchItem(
                            new Id(1),
                            new MerchName("Ozon.SomeName"),
                            new Item(ItemType.TShirt),
                            MerchRankType.WelcomePack,
                            ClothingSize.M),

                        new MerchItem(
                            new Id(2),
                            new MerchName("Ozon.SomeName"),
                            new Item(ItemType.Notepad),
                            MerchRankType.VeteranPack,
                            ClothingSize.NO),

                        new MerchItem(
                            new Id(3),
                            new MerchName("Ozon.SomeName"),
                            new Item(ItemType.Sweatshirt),
                            MerchRankType.WelcomePack,
                            ClothingSize.M)
                    }
                )
            );
        }
    }
}