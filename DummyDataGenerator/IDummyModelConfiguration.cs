using DummyDataGenerator.Metadata.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace DummyDataGenerator
{
    public interface IDummyModelConfiguration
    {

    }

    public interface IDummyModelConfiguration<TModel> : IDummyModelConfiguration where TModel : class, new()
    {
        void Configure(DummyModelBuilder<TModel> model);
    }

    public interface IDummyModelConfiguration<TModel, TRequest> : IDummyModelConfiguration<TModel> where TModel : class, new() where TRequest : class
    {
        TRequest Request { get; }

        void SetRequest(TRequest request);
    }
}