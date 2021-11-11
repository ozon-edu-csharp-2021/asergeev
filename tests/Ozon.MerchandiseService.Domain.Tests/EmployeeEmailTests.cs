using Ozon.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using Ozon.MerchandiseService.Domain.Exceptions;
using Xunit;

namespace Ozon.MerchandiseService.Domain.Tests
{
    public class EmployeeEmailTests
    {
        [Fact]
        public void EmailCorrect()
        {
            var expectedEmail = "alex_sergo@list.ru";
            var email = new Email(expectedEmail);
            
            Assert.Equal(expectedEmail, email.Value);
        }
        
        [Fact]
        public void EmailIncorrect()
        {
            var incorrectEmail = "alex_sergolist.ru";

            Assert.Throws<IncorrectEmailException>(() => new Email(incorrectEmail));
            
            incorrectEmail = "alex_sergo@listru";
            Assert.Throws<IncorrectEmailException>(() => new Email(incorrectEmail));
        }
    }
}