using System.Collections.Generic;
using Ozon.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using Ozon.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using Ozon.MerchandiseService.Domain.Exceptions;
using Xunit;

namespace Ozon.MerchandiseService.Domain.Tests
{
    public class EmployeeTests
    {
        [Fact]
        public void CreateEmployeeSuccess()
        {
            string expectedEmail = "alex_sergo@list.ru";
            var expectedClothingSize = ClothingSize.M;
            
            var employee = new Employee(
                new Id(0),
                new Email(expectedEmail),
                expectedClothingSize,
                new MerchIssuanceInfo(
                    MerchRankType.WelcomePack, 
                    new IssueStatus(false),
                    null)
                );
            
            Assert.Equal(expectedEmail, employee.Email.Value);
            Assert.Equal(expectedClothingSize, employee.ClothingSize);
        }
        
        [Fact]
        public void CreateEmployeeWithIncorrectEmailFail()
        {
            string expectedEmail = "alex_sergolist.ru";
            var expectedClothingSize = ClothingSize.M;


            Assert.Throws<IncorrectEmailException>(() =>
                new Employee(
                    new Id(0),
                    new Email(expectedEmail),
                    expectedClothingSize,
                    new MerchIssuanceInfo(
                        MerchRankType.WelcomePack,
                        new IssueStatus(false),
                        null)
                )
            );
        }
        
        private MerchSet _merchSetCorrect = new MerchSet(
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

        [Fact]
        public void CreateMerchSetForEmployeeSuccess()
        {
            var employee = new Employee(
                new Id(0),
                new Email("alex_sergo@list.ru"),
                ClothingSize.M, 
                new MerchIssuanceInfo(
                    MerchRankType.WelcomePack, 
                    new IssueStatus(false),
                    null)
            );
            employee.AddMerchSet(_merchSetCorrect);
            
            Assert.True(employee.MerchSet.Set.Count > 0);
            Assert.Equal(MerchRankType.WelcomePack,employee.MerchSet.MerchRankType);
        }
        
        [Fact]
        public void CreateDoubleMerchSetForEmployeeFail()
        {
            var employee = new Employee(
                new Id(0),
                new Email("alex_sergo@list.ru"),
                ClothingSize.M, 
                new MerchIssuanceInfo(
                    MerchRankType.WelcomePack, 
                    new IssueStatus(false),
                    null)
            );
            
            employee.AddMerchSet(_merchSetCorrect);

            Assert.Throws<DoubleCreateMerchSetException>(() =>
                    employee.AddMerchSet(_merchSetCorrect)
                );
        }
        
        [Fact]
        public void CreateMerchSetForEmployeeWithIssueStatusTrueFail()
        {
            var employee = new Employee(
                new Id(0),
                new Email("alex_sergo@list.ru"),
                ClothingSize.M, 
                new MerchIssuanceInfo(
                    MerchRankType.WelcomePack, 
                    new IssueStatus(true),
                    null)
            );

            Assert.Throws<MerchWasIssuedException>(() =>
                employee.AddMerchSet(_merchSetCorrect)
            );
        }

        [Fact]
        public void GetMerchSetForEmployeeSuccess()
        {
            var employee = new Employee(
                new Id(0),
                new Email("alex_sergo@list.ru"),
                ClothingSize.M, 
                new MerchIssuanceInfo(
                    MerchRankType.WelcomePack, 
                    new IssueStatus(false),
                    null)
            );
            employee.AddMerchSet(_merchSetCorrect);
            employee.GetMerchSet();

            var expectedIssued = true;
            Assert.Equal(expectedIssued,employee.MerchIssuanceInfo.IssueStatus.WasIssued);
        }
        
        [Fact]
        public void GetMerchSetForEmployeeWithoutCreatingFail()
        {
            var employee = new Employee(
                new Id(0),
                new Email("alex_sergo@list.ru"),
                ClothingSize.M, 
                new MerchIssuanceInfo(
                    MerchRankType.WelcomePack, 
                    new IssueStatus(false),
                    null)
            );
            
            Assert.Throws<NullMerchSetException>(() =>
                employee.GetMerchSet()
            );
        }
        
        [Fact]
        public void GetMerchSetDoubleForEmployeeFail()
        {
            var employee = new Employee(
                new Id(0),
                new Email("alex_sergo@list.ru"),
                ClothingSize.M, 
                new MerchIssuanceInfo(
                    MerchRankType.WelcomePack, 
                    new IssueStatus(false),
                    null)
            );

            employee.AddMerchSet(_merchSetCorrect);
            employee.GetMerchSet();
            
            Assert.Throws<MerchWasIssuedException>(() =>
                employee.GetMerchSet()
            );
        }
    }
}