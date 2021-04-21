using System;
using System.Collections.Generic;
using System.Text;

namespace DummyDataGenerator.Metadata.Builder
{
    public abstract class PropertyBuilder
    {
        private readonly Type _property;
        protected readonly Random _random;

        public PropertyBuilder(Type property)
        {
            _property = property;
            _random = new Random();
        }

        protected abstract object GetGeneratedValue();

        internal void BindData<TModel>(TModel model)
        {
            var value = GetGeneratedValue();
        }
    }
}
