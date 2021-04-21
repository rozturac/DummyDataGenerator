using DummyDataGenerator.Metadata.Builder;
using System;

namespace DummyDataGenerator.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var builder = new DummyModelBuilder<Test>();
            builder.Property(x => x.Text);
            builder.Property(x => x.Number).HasRange(0, 50);
        }
    }

    class Test
    {
        public string Text { get; set; }
        public double Number { get; set; }
    }
}
