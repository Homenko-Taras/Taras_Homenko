using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace Selenium.Hooks
{
    [TestFixture]
    public class Driver
    {
        string url = "https://opensource-demo.orangehrmlive.com/";

        public ChromeDriver driver;
        public WebDriverWait wait;

        public ChromeDriver StartBrowser()
        {
            // Local Selenium WebDriver
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = url;
            return driver;
        }


        public void Quit(ChromeDriver driver)
        {
            driver.Quit();
        }
    }
}