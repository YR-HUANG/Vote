using Atata;
using NUnit.Framework;

namespace Vote
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class UITestFixture
    {
        [SetUp]
        public void SetUp()
        {
            AtataContext.Configure().Build();
        }

        [TearDown]
        public void TearDown()
        {
            AtataContext.Current?.CleanUp();
        }
    }
}
