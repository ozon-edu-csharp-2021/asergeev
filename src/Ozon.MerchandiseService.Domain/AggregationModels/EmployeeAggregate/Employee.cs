using System;
using System.Collections.Generic;
using Ozon.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using Ozon.MerchandiseService.Domain.Events;
using Ozon.MerchandiseService.Domain.Exceptions;
using Ozon.MerchandiseService.Domain.Models;

namespace Ozon.MerchandiseService.Domain.AggregationModels.EmployeeAggregate
{
    public class Employee: Entity
    {
        public Employee(Id id, Email email, ClothingSize clothingSize, MerchIssuanceInfo merchIssuanceInfo)
        {
            Id = id;
            Email = email;
            ClothingSize = clothingSize;
            MerchIssuanceInfo = merchIssuanceInfo;
        }
        
        public Employee(Id id,Email email, ClothingSize clothingSize,MerchSet merchSet, MerchIssuanceInfo merchIssuanceInfo)
        {
            Id = id;
            Email = email;
            ClothingSize = clothingSize;
            MerchSet = merchSet;
            MerchIssuanceInfo = merchIssuanceInfo;
        }
        
        public Id Id { get; }
        public Email Email { get; }
        public ClothingSize ClothingSize { get; }
        public MerchSet MerchSet { get; private set; }
        public MerchIssuanceInfo MerchIssuanceInfo { get; private set; }


        public void AddMerchSet(MerchSet merchSet)
        {
            CheckMerchExceptions();
            if (MerchSet is not null)
                throw new DoubleCreateMerchSetException("Merch Set has already been created!");

            MerchSet = merchSet;

            var merchSetDomainEvent = new MerchSetFormedDomainEvent(MerchSet);
            AddDomainEvent(merchSetDomainEvent);
        }

        public void GetMerchSet()
        {
            CheckMerchExceptions();
            if (MerchSet is null)
                throw new NullMerchSetException("Merch Set has not been created!");

            MerchIssuanceInfo = new MerchIssuanceInfo(
                MerchSet.MerchRankType,
                new IssueStatus(true),
                DateTime.Now
            );
            
            var domainEvent = new MerchHaveBeenIssuedDomainEvent(Email);
            AddDomainEvent(domainEvent);
        }

        private void CheckMerchExceptions()
        {
            if (MerchIssuanceInfo is null)
                throw new NullMerchIssuanceInfo("No information about issuance!");
            if (MerchIssuanceInfo.IssueStatus.WasIssued)
                throw new MerchWasIssuedException("Мerch has already been issued!");
        }
    }
}