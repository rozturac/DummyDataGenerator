using DummyDataGenerator.Metadata.Builder;
using DummyDataGenerator.TestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DummyDataGenerator.TestAPI.DummyConfigurations
{
    public class TestModelVmDummyConfiguration : IDummyModelConfiguration<TestModelVm>
    {
        public void Configure(DummyModelBuilder<TestModelVm> model)
        {
            model.Property(p => p.FirstName).HasMinlength(5).HasMaxlength(15).HasContentType(TextContentType.OnlyTextual);
            model.Property(p => p.LastName).HasMinlength(5).HasMaxlength(15).HasContentType(TextContentType.OnlyTextual);
            model.Property(p => p.Age).HasRange(0, 75);
            model.Property(p => p.TCKN).HasMinlength(11).HasMaxlength(11).HasContentType(TextContentType.OnlyNumerical);
            model.Property(p => p.Address).HasMinlength(20).HasMaxlength(75);
        }
    }
}
