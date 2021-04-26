using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DummyDataGenerator.Metadata.Builder
{
    public class DateTimeModelBuilder : PropertyBuilder
    {
        private DateTime? _startDate;
        private DateTime? _endDate;
        private DateTime? _staticDate;

        public DateTimeModelBuilder(PropertyInfo property) : base(property)
        {
        }

        public DateTimeModelBuilder HasStaticDate(DateTime staticDate) { _staticDate = staticDate; return this; }

        protected override object GetGeneratedValue()
        {
            return _staticDate ?? GenerateMiddleText();
        }

        private DateTime GenerateMiddleText()
        {
            _startDate ??= DateTime.MinValue;
            _endDate ??= DateTime.MaxValue;

            var rdmTicks = (long)_random.NextDouble() * _startDate.Value.Ticks + (_endDate.Value.Ticks - _startDate.Value.Ticks);
            return new DateTime(rdmTicks);

        }
    }
}
