﻿using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;

namespace BitcoinPricePresenter.Tests.Extensions
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class AutoMoqDataAttribute : AutoDataAttribute

    {
        public AutoMoqDataAttribute()
            : base(() => new Fixture().Customize(new AutoMoqCustomization()))
        {

        }
    }
}
