using DummyDataGenerator.Extensions;
using DummyDataGenerator.Interfaces;
using DummyDataGenerator.Metadata.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DummyDataGenerator.Implementation
{
    internal class Generator : IGenerator
    {
        public TResult Generate<TResult>() where TResult : class, new()
        {
            var dummyModelBuilder = new DummyModelBuilder<TResult>();
            var dummyModelConfiguration = (IDummyModelConfiguration<TResult>)ServiceCollectionExtensions.DummyModelConfigurations.FirstOrDefault(x => x is IDummyModelConfiguration<TResult>);
            if (dummyModelBuilder == null)
                throw new Exception("IDummyModelConfiguration not found !");

            dummyModelConfiguration.Configure(dummyModelBuilder);
            TResult result = new TResult();
            dummyModelBuilder.PropertyBuilders.ForEach(x => x.BindData(result));
            return result;
        }

        public TResult Generate<TResult, TRequest>(TRequest request) where TResult : class, new()
        {
            throw new NotImplementedException();
        }

        public IList<TResult> GenerateList<TResult>(int count = 100) where TResult : class, new()
        {
            return Enumerable.Range(0, count).Select(i => Generate<TResult>()).ToList();
        }

        public IList<TResult> GenerateList<TResult, TRequest>(TRequest request, int count = 100) where TResult : class, new()
        {
            throw new NotImplementedException();
        }
    }
}
