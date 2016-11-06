using System;
using NUnit.Framework;

namespace ChamaeleoIoT.Tests
{
    public abstract class BaseTestFixture<TSubject, TTestEnvironment>
        where TTestEnvironment : TestEnvironment<TSubject>
    {
        public virtual TTestEnvironment GetEnvironment()
        {
            TTestEnvironment env = Activator.CreateInstance<TTestEnvironment>();

            env.SetupEnvironment();

            return env;
        }

        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            this.OnTestFixtureSetUp();
        }

        [SetUp]
        public void TestSetup()
        {
            this.OnTestSetup();
        }

        protected virtual void OnTestFixtureSetUp()
        {
        }

        protected virtual void OnTestSetup()
        {
        }
    }
}
