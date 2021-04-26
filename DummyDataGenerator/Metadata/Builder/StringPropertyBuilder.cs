using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DummyDataGenerator.Metadata.Builder
{
    public class StringPropertyBuilder : PropertyBuilder
    {
        private static string[] _numericalCollection;
        private static string[] _textualCollection;
        private static string[] _mixedCollection;

        private int _minLength = 0;
        private int _maxLength = 50;
        private string[] _collections;
        private string _suffix, _prefix;
        private string _statixText;
        private TextContentType _textContentType = TextContentType.Mixed;
        public StringPropertyBuilder(PropertyInfo property) : base(property)
        {
            _numericalCollection ??= new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            _textualCollection ??= new string[] { "A", "B", "C", "D", "E", "F", "G", "Ğ", "H", "I", "İ", "J", "K", "L", "M", "N", "O", "Ö", "P", "R", "S", "Ş", "T", "U", "Ü", "V", "Y", "Z" };

            if (_mixedCollection == null)
            {
                _mixedCollection = new string[_textualCollection.Length + _numericalCollection.Length];
                for (int i = 0; i < _textualCollection.Length; i++)
                    _mixedCollection[i] = _textualCollection[i];

                for (int i = 0; i < _numericalCollection.Length; i++)
                    _mixedCollection[_textualCollection.Length + i] = _numericalCollection[i];
            }
        }

        public StringPropertyBuilder HasMaxlength(int maxLength) { _maxLength = maxLength; return this; }
        public StringPropertyBuilder HasMinlength(int minLength) { _minLength = minLength; return this; }
        public StringPropertyBuilder HasCollection(params string[] collections) { _collections = collections; return this; }
        public StringPropertyBuilder HasPrefix(string prefix) { _prefix = prefix; return this; }
        public StringPropertyBuilder HasSuffix(string suffix) { _suffix = suffix; return this; }
        public StringPropertyBuilder HasStaticText(string staticText) { _statixText = staticText; return this; }
        public StringPropertyBuilder HasContentType(TextContentType textContentType) { _textContentType = textContentType; return this; }

        protected override object GetGeneratedValue()
        {
            var middleValue = _statixText ?? SelectMiddleText() ?? GenerateMiddleText().ToLowerInvariant();
            return string.Concat(_prefix, middleValue, _suffix);
        }

        private string GenerateMiddleText()
        {
            return _textContentType switch
            {
                TextContentType.OnlyNumerical => string.Concat(Enumerable.Range(_minLength, _random.Next(_minLength, _maxLength)).Select(i => _numericalCollection[_random.Next(0, _numericalCollection.Length - 1)])),
                TextContentType.OnlyTextual => string.Concat(Enumerable.Range(_minLength, _random.Next(_minLength, _maxLength)).Select(i => _textualCollection[_random.Next(0, _textualCollection.Length - 1)])),
                _ => string.Concat(Enumerable.Range(_minLength, _random.Next(_minLength, _maxLength)).Select(i => _mixedCollection[_random.Next(0, _mixedCollection.Length - 1)])),
            };
        }

        private string SelectMiddleText()
        {
            return _collections?[_random.Next(0, _collections.Length)];
        }
    }
}