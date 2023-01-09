using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace Pages
{
    [TestFixture]
    public class Login
    {
        string username = "Admin";
        string password = "admin123";

        ChromeDriver driver;
        public WebDriverWait wait;

        public Login(ChromeDriver Driver)
        {
            driver = Driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public IWebElement usernameLogin => driver.FindElement(By.CssSelector("[name = 'username']"));
        public IWebElement passwordLogin => driver.FindElement(By.CssSelector("[name = 'password']"));
        public IWebElement loginButton => driver.FindElement(By.XPath("//button[@type='submit']"));


        public void LoginPage()
        {

            wait.Until(d => usernameLogin);

            usernameLogin.SendKeys(username);
            passwordLogin.SendKeys(password);

            loginButton.Click();
        }
    }
}