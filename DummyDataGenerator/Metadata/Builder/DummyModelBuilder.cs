using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
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
            var propBuilder = new StringPropertyBuilder(GetPropInfo(propertyExpression.Body));
            PropertyBuilders.Add(propBuilder);
            return propBuilder;
        }

        public DoublePropertyBuilder Property(Expression<Func<TModel, double>> propertyExpression)
        {
            var propBuilder = new DoublePropertyBuilder(GetPropInfo(propertyExpression.Body));
            PropertyBuilders.Add(propBuilder);
            return propBuilder;
        }

        public IntPropertyBuilder Property(Expression<Func<TModel, int>> propertyExpression)
        {
            var propBuilder = new IntPropertyBuilder(GetPropInfo(propertyExpression.Body));
            PropertyBuilders.Add(propBuilder);
            return propBuilder;
        }

        public DateTimeModelBuilder Property(Expression<Func<TModel, DateTime>> propertyExpression)
        {
            var propBuilder = new DateTimeModelBuilder(GetPropInfo(propertyExpression.Body));
            PropertyBuilders.Add(propBuilder);
            return propBuilder;
        }

        private PropertyInfo GetPropInfo(Expression expression)
        {
            PropertyInfo propInfo = null;

            if (expression is UnaryExpression unaryExp)
            {
                if (unaryExp.Operand is MemberExpression memberExp)
                {
                    propInfo = (PropertyInfo)memberExp.Member;
                }
            }
            else if (expression is MemberExpression memberExp)
            {
                propInfo = (PropertyInfo)memberExp.Member;
            }

            return propInfo;
        }
    }
}