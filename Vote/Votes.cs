using System.Threading.Tasks;
using Atata;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;


namespace Vote
{
    [TestFixture]
    public class Votes
    {
      
        private static ChromeDriver _driver;
        [SetUp]
        public void SetUp()
        {
            AtataContext.GlobalConfiguration
                .UseChrome()
                .WithArguments("start-maximized")
                .UseBaseUrl("https://www.fusohero.com.tw/vote-content.php?id=67")
                .UseCulture("en-US")
                .UseAllNUnitFeatures();

            AtataContext.GlobalConfiguration.AutoSetUpDriverToUse();
        }

        [TearDown]
        public void TearDown()
        {
            AtataContext.Current?.CleanUp();
        }

        [Test]
        public void SignIn()
        {
            Go.To<VotePage>();
        }

        [Test]
        public void VoteWithoutHeader()
        {
            Go.To<VotePage>().VoteBtn.Click();
        }

        [Test]
        public void VoteWithHeader()
        {
            SignIn();
            UseModHeader();
        }

        private void UseModHeader()
        {
            var url = _driver.Url;
            Go.ToUrl("https://bewisse.com/add?X-Forwarded-For=210.212.145.105");
            Go.ToUrl(url);
        }

        private static void ChromeExtension()
        {
            var options = new ChromeOptions();
            options.AddExtension("C:/Workspace/Vote/Vote/modheader.crx");
            _driver = new ChromeDriver(options);
        }
    }

}