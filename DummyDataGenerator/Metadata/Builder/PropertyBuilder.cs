using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DummyDataGenerator.Metadata.Builder
{
    public abstract class PropertyBuilder
    {
        private readonly PropertyInfo _property;
        protected readonly Random _random;

        public PropertyBuilder(PropertyInfo property)
        {
            _property = property;
            _random = new Random();
        }

        protected abstract object GetGeneratedValue();

        internal void BindData<TModel>(TModel model)
        {
            var value = GetGeneratedValue();
            _property.SetValue(model, value);
        }
    }
}
