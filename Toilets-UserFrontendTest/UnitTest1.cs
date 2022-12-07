using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Toilets_UserFrontendTest
{

    [TestClass]
    public class UnitTest1
    {
        private static readonly string DriverDirectory = "C:\\webdrivers";
        private static IWebDriver driver;

        string url = "https://toilets-userfrontend.azurewebsites.net/";

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            //driver = new FirefoxDriver(DriverDirectory);
            driver = new ChromeDriver(DriverDirectory);
        }

        [ClassCleanup]
        public static void TearDown()
        {
            driver.Dispose();
        }

        [TestMethod]
        public void GetToiletTest()
        {
            driver.Navigate().GoToUrl(url);
            Assert.AreEqual("Poop on the Go", driver.Title);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var isTable = wait.Until(d => d.FindElement(By.ClassName("sel-toilet")));

            Assert.IsNotNull(isTable);
        }
    }
}