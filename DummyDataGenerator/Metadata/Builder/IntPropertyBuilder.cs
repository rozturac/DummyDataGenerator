using System;
using System.Collections.Generic;
using System.Text;

namespace DummyDataGenerator.Metadata.Builder
{
    public class IntPropertyBuilder : PropertyBuilder
    {
        private int _minValue = int.MinValue;
        private int _maxValue = int.MaxValue;
        private int? _staticValue;

        public IntPropertyBuilder(Type property) : base(property)
        {
        }

        public IntPropertyBuilder HasRange(int minValue, int maxValue)
        {
            _maxValue = maxValue;
            _minValue = minValue;

            return this;
        }

        public IntPropertyBuilder HasStaticText(int staticValue) { _staticValue = staticValue; return this; }

        protected override object GetGeneratedValue()
        {
            return _staticValue ?? _random.Next(_minValue, _maxValue);
        }
    }
}
