using DrinkStore.BLL.DTOs;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RiskFirst.Hateoas;
using Microsoft.Extensions.DependencyInjection;

namespace DrinkStore.API.Utilities
{
    public static class HateoasLinkConfig
    {
        public static void AddHateoas(this IServiceCollection services)
        {
            services.AddLinks(config =>
            {
                config.AddPolicy<DTO>(policy => {
                    policy.RequireSelfLink()
                          .RequireRoutedLink("products", "GetProducts")
                          .RequireRoutedLink("orders", "GetOrders")
                          .RequireRoutedLink("categories", "GetCategories");
                });

                config.AddPolicy<ProductListDTO>(policy => {
                    policy.RequireSelfLink()
                          .RequireRoutedLink("add", "AddProduct");
                });

                config.AddPolicy<ProductDTO>(policy => {
                    policy.RequireSelfLink()
                          .RequireRoutedLink("update", "UpdateProduct", x => new { id = x.Id })
                          .RequireRoutedLink("delete", "DeleteProduct", x => new { id = x.Id });
                });
            });
        }
    }
}
