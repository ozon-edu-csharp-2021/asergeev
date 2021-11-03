using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Ozon.MerchandiseService.Domain;
using Ozon.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using Ozon.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using Ozon.MerchandiseService.Domain.Contracts;
using Ozon.MerchandiseService.Domain.Models;
using Ozon.MerchandiseService.Infrastucture.Handlers;
using System.Linq;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Добавление в DI контейнер инфраструктурных сервисов
        /// </summary>
        /// <param name="services">Объект IServiceCollection</param>
        /// <returns>Объект <see cref="IServiceCollection"/></returns>
        
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(RequestMerchCommandHandler).Assembly);
            services.AddScoped<IEmployeeRepository, Repo>();
            services.AddScoped<IMerchItemRepository, Repo>();
            
            return services;
        }
        
        /// <summary>
        /// Добавление в DI контейнер инфраструктурных репозиториев
        /// </summary>
        /// <param name="services">Объект IServiceCollection</param>
        /// <returns>Объект <see cref="IServiceCollection"/></returns>
        public static IServiceCollection AddInfrastructureRepositories(this IServiceCollection services)
        {
            services.AddMediatR(typeof(RequestMerchCommandHandler).Assembly);
            services.AddScoped<IEmployeeRepository, Repo>();
            services.AddScoped<IMerchItemRepository, Repo>();
            return services;
        }
    }
    
    public class Repo: IEmployeeRepository, IMerchItemRepository
    {
        private static List<MerchItem> _merchItems = new List<MerchItem>()
        {
            new MerchItem(
                new Id(0),
                new MerchName("OzzzOn"),
                new Item(ItemType.TShirt),
                MerchRankType.WelcomePack,
                ClothingSize.M),
                
            new MerchItem(
                new Id(1),
                new MerchName("OzzzOn"),
                new Item(ItemType.Bag),
                MerchRankType.VeteranPack,
                ClothingSize.M),
                
            new MerchItem(
                new Id(2),
                new MerchName("OzzzOn"),
                new Item(ItemType.Notepad),
                MerchRankType.WelcomePack,
                ClothingSize.M),
        };
        
        private List<Employee> _employees = new List<Employee>()
        {
            new Employee(
                new Id(0),
                new Email("zzz@mail.ru"),
                ClothingSize.L,
                new MerchIssuanceInfo()),
            new Employee(
                new Id(1),
                new Email("alex_sergo@list.ru"),
                ClothingSize.M,
                new MerchIssuanceInfo(MerchRankType.WelcomePack, new IssueStatus(false), null)),
            new Employee(
                new Id(2),
                new Email("AAA@ozon.ru"),
                ClothingSize.S,
                new MerchSet(
                    new List<MerchItem>(){_merchItems[0]}),
                new MerchIssuanceInfo(MerchRankType.WelcomePack, new IssueStatus(true), 
                    new DateTime(2020,12,12)))
        };
        public IUnitOfWork UnitOfWork { get; }
        Task<MerchItem> IRepository<MerchItem>.CreateAsync(MerchItem itemToCreate, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        Task<MerchItem> IMerchItemRepository.UpdateAsync(MerchItem itemToUpdate, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<MerchItem> FindByIdAsync(Id merchId, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<MerchItem>> FindByMerchRankAsync(MerchRankType rank, CancellationToken cancellationToken = default)
        {
            var merchItemsWithRank = _merchItems.FindAll(it => it.MerchRank.Equals(rank));
            
            return Task.FromResult<List<MerchItem>>(merchItemsWithRank);
        }

        Task<MerchItem> IMerchItemRepository.CreateAsync(MerchItem itemToCreate, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        Task<MerchItem> IRepository<MerchItem>.UpdateAsync(MerchItem itemToUpdate, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<Employee> CreateAsync(Employee itemToCreate, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<Employee> UpdateAsync(Employee itemToUpdate, CancellationToken cancellationToken = default)
        {
            var employee = _employees.Find(it => it.Email.Equals(itemToUpdate.Email));
            _employees.Remove(employee);
            
            _employees.Add(itemToUpdate);
            
            return Task.FromResult<Employee>(itemToUpdate);
        }

        public Task<Employee> FindEmployeeByEmailAsync(Email email, CancellationToken cancellationToken = default)
        {

            var employee = _employees.Find(it => it.Email.Equals(email));

            return Task.FromResult(employee);
        }

        public Task<Employee> FindEmployeeById(Id id, CancellationToken cancellationToken = default)
        {
            var employee = _employees.Find(it => Equals(it.Id, id));
            return Task.FromResult(employee);
        }
    }
}