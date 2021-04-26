using DummyDataGenerator.Implementation;
using DummyDataGenerator.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DummyDataGenerator.Extensions
{
    public static class ServiceCollectionExtensions
    {
        internal static List<object> DummyModelConfigurations { get; set; } = new List<object>();

        public static IServiceCollection AddDummyDataGenerator(this IServiceCollection services, params Assembly[] assemblies)
        {

            #region DI
            services.AddSingleton<IGenerator, Generator>();
            #endregion

            #region Find all Config Files
            foreach (var type in assemblies.SelectMany(x => x.GetTypes()))
            {
                if (type.GetInterfaces().Contains(typeof(IDummyModelConfiguration)))
                {
                    DummyModelConfigurations.Add(Activator.CreateInstance(type));
                }
            }
            #endregion

            return services;
        }
    }
}
