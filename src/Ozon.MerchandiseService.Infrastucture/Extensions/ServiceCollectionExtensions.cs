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
using Ozon.MerchandiseService.Infrastucture.Repository;

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
            services.AddScoped<IEmployeeRepository, Repository>();
            services.AddScoped<IMerchItemRepository, Repository>();
            
            return services;
        }
        
        /// <summary>
        /// Добавление в DI контейнер инфраструктурных репозиториев
        /// </summary>
        /// <param name="services">Объект IServiceCollection</param>
        /// <returns>Объект <see cref="IServiceCollection"/></returns>
        public static IServiceCollection AddInfrastructureRepositories(this IServiceCollection services)
        {
            return services;
        }
    }
}