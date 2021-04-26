using DummyDataGenerator.Interfaces;
using DummyDataGenerator.TestAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DummyDataGenerator.TestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IGenerator _generator;
        public TestController(IGenerator generator)
        {
            this._generator = generator;
        }

        [HttpGet]
        public TestModelVm Get()
        {
            return _generator.Generate<TestModelVm>();
        }
    }
}
