using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DummyDataGenerator.Metadata.Builder
{
    public class DummyModelBuilder<TModel> where TModel : class, new()
    {
        public List<PropertyBuilder> PropertyBuilders { get; private set; }
        public DummyModelBuilder()
        {
            PropertyBuilders = new List<PropertyBuilder>();
        }

        public StringPropertyBuilder Property(Expression<Func<TModel, string>> propertyExpression)
        {
            var propBuilder = new StringPropertyBuilder(propertyExpression.ReturnType);
            PropertyBuilders.Add(propBuilder);
            return propBuilder;
        }

        public DoublePropertyBuilder Property(Expression<Func<TModel, double>> propertyExpression)
        {
            var propBuilder = new DoublePropertyBuilder(propertyExpression.ReturnType);
            PropertyBuilders.Add(propBuilder);
            return propBuilder;
        }

        public IntPropertyBuilder Property(Expression<Func<TModel, int>> propertyExpression)
        {
            var propBuilder = new IntPropertyBuilder(propertyExpression.ReturnType);
            PropertyBuilders.Add(propBuilder);
            return propBuilder;
        }
    }
}