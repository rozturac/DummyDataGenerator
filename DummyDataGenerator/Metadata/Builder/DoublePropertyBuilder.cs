using System;
using System.Collections.Generic;
using System.Text;

namespace DummyDataGenerator.Metadata.Builder
{
    public class DoublePropertyBuilder : PropertyBuilder
    {
        private double _minValue = double.MinValue;
        private double _maxValue = double.MaxValue;
        private double? _staticValue;

        public DoublePropertyBuilder(Type property) : base(property)
        {
        }

        public DoublePropertyBuilder HasRange(double minValue, double maxValue)
        {
            _maxValue = maxValue;
            _minValue = minValue;

            return this;
        }

        public DoublePropertyBuilder HasStaticValue(double staticValue) { _staticValue = staticValue; return this; }

        protected override object GetGeneratedValue()
        {
            return _staticValue ?? _random.NextDouble() * (_maxValue - _minValue) * _minValue;
        }
    }
}
