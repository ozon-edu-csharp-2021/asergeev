using System.Collections.Generic;
using System.Text.RegularExpressions;
using Ozon.MerchandiseService.Domain.Exceptions;
using Ozon.MerchandiseService.Domain.Models;

namespace Ozon.MerchandiseService.Domain.AggregationModels.EmployeeAggregate
{
    public class Email: ValueObject
    {
        public string Value { get; }

        public Email(string email)
        {
            if (Regex.IsMatch(email, @".+@.+\..+"))
                Value = email;
            else
                throw new IncorrectEmailException("Incorrect email address!");
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}