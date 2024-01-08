using FluentValidation;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using RetailSystem.Application.Abstractions;
using RetailSystem.Application.Services;
using RetailSystem.Application.Validation;
using System.Reflection;

namespace RetailSystem.Application.DI
{
    public static class Bootstrap
    {
        public static IServiceCollection ApplicationStrapping(this IServiceCollection services)
        {

            #region Services

            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IBranchService, BranchService>();
            services.AddScoped<ICashierService, CashierService>();
            services.AddScoped<IInvoiceHeaderService, InvoiceHeaderService>();
            services.AddScoped<IInvoiceDetailService, InvoiceDetailService>();

            #endregion


            #region Validators


            services.AddScoped<IValidator<CreateCashierDto>, CreateCashierValidation>();
            services.AddScoped<IValidator<UpdateCashierDto>, UpdateCashierValidation>();

            services.AddScoped<IValidator<CreateInvoiceHeaderDto>, CreateInvoiceHeaderValidation>();
            services.AddScoped<IValidator<UpdateInvoiceHeaderDto>, UpdateInvoiceHeaderValidation>();

            services.AddScoped<IValidator<CreateInvoiceDetailDto>, CreateInvoiceDetailValidation>();
            services.AddScoped<IValidator<UpdateInvoiceDetailDto>, UpdateInvoiceDetailValidation>();

            #endregion


            #region Mappster

            var config = TypeAdapterConfig.GlobalSettings;

            config.Scan(Assembly.GetExecutingAssembly());

            services.AddSingleton(config);

            TypeAdapterConfig.GlobalSettings.Default.NameMatchingStrategy(NameMatchingStrategy.Flexible);

            services.AddScoped<IMapper, ServiceMapper>();

            #endregion


            return services;
        }
    }
}
