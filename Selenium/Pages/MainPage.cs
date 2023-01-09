using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace Pages
{
    [TestFixture]
    public class MainPage
    {
        ChromeDriver driver;
        public WebDriverWait wait;

        public MainPage(ChromeDriver Driver)
        {
            driver = Driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }


        public IWebElement adminPage => driver.FindElement(By.LinkText("Admin"));
        public IWebElement dDownJobs => driver.FindElement(By.XPath("//span[contains(text(),'Job')]"));
        public IWebElement workShifts => driver.FindElement(By.XPath("//a[contains(text(),'Work Shifts')]"));
        public IWebElement addButton => driver.FindElement(By.XPath("//button[contains(.,'Add')]"));

        public void GoToShiftPage()
        {

            wait.Until(d => adminPage);
            adminPage.Click();

            wait.Until(d => dDownJobs);
            dDownJobs.Click();

            wait.Until(d => workShifts);
            workShifts.Click();

            wait.Until(d => addButton);
            addButton.Click();

        }
    }
}
