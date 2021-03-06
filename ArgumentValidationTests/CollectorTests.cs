﻿using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Zonkflut.ArgumentValidation;
using static Zonkflut.ArgumentValidation.ArgumentValidator;

namespace ArgumentValidationTests
{
    [TestFixture]
    public class CollectorTests
    {
        [Test]
        public void TestCollector()
        {
            var myArgument = "";
            var myCollectionArgument = new List<string>();
            var mySuccessArgument = "Hello world";
            var message = "Errors occurred";
            
            var collector = CreateValidationErrorCollector();

            var result1 = collector.Add(() => myArgument, v => v.Is.NotNullOrWhitespace()).Value;
            var result2a = collector.Add(() => myCollectionArgument, v => v.Collection().Is.NotEmpty()).Value;
            var result2b = collector.Add(() =>  myCollectionArgument, v => v.Collection().Is.NotEmpty().And.NotNull()).Value;
            var result3 = collector.Add(() =>  mySuccessArgument, v => v.Is.NotNull()).Value;
            
            Assert.AreEqual(myArgument, result1);
            Assert.AreEqual(myCollectionArgument, result2a);
            Assert.AreEqual(myCollectionArgument, result2b);
            Assert.AreEqual(mySuccessArgument, result3);

            Assert.That(
                () => collector.ThrowAll(message),
                Throws.TypeOf<CompositeValidationException>().With.Message.EqualTo(message));
        }

        [Test]
        public void RenameArgumentTest()
        {
            DateTime? myDate = DateTime.Now;
            var collector = CreateValidationErrorCollector();
            collector.Add(() => myDate.Value, nameof(myDate), v => v.Is.LessThan(DateTime.MinValue.AddDays(1)));

            CompositeValidationException exception = null;
            try { collector.ThrowAll("Message"); }
            catch (CompositeValidationException e) { exception = e; }

            Assert.IsNotNull(exception);
            Assert.IsNotNull(exception.Exceptions.FirstOrDefault());
            Assert.AreEqual(nameof(myDate), exception.Exceptions.First().ParamName);
        }
    }
}
