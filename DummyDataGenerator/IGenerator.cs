﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DummyDataGenerator.Interfaces
{
    public interface IGenerator
    {
        TResult Generate<TResult>() where TResult : class, new();
        TResult Generate<TResult, TRequest>(TRequest request) where TResult : class, new();
        IList<TResult> GenerateList<TResult>() where TResult : class, new();
        IList<TResult> GenerateList<TResult, TRequest>(TRequest request) where TResult : class, new();
    }
}