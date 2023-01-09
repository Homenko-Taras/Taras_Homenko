using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace Pages
{
    [TestFixture]
    public class TimeShiftPage
    {
        string shiftName = "Afternoon";
        string assignedEmployees = "Odis Adalwin";

        ChromeDriver driver;
        public WebDriverWait wait;

        public TimeShiftPage(ChromeDriver Driver)
        {
            driver = Driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        string clockTimeInput0 = "/html/body/div/div[1]/div[2]/div[2]/div/div/form/div[2]/div/div[1]/div/div[2]/div/div/i";
        string clockTimeInput1 = "/html/body/div/div[1]/div[2]/div[2]/div/div/form/div[2]/div/div[2]/div/div[2]/div/div/i";
        string xPathButtonFrom = "/html/body/div/div[1]/div[2]/div[2]/div/div/form/div[2]/div/div[1]/div/div[2]/div/div[2]/div[1]/i[2]";
        string xPathButtonTo = "/html/body/div/div[1]/div[2]/div[2]/div/div/form/div[2]/div/div[2]/div/div[2]/div/div[2]/div[1]/i[1]";

        string inputAssignedEmployees = "//input[@placeholder='Type for hints...']";
        string saveButton = "//button[@type='submit']";



        public void ShiftTimeTo6To6()
        {
            wait.Until(d => driver.FindElement(By.XPath("//input[not(@placeholder)]")));
            driver.FindElement(By.XPath("//input[not(@placeholder)]")).SendKeys(shiftName);


            driver.FindElement(By.XPath(clockTimeInput0)).Click();
            wait.Until(d => driver.FindElement(By.XPath(xPathButtonFrom)));
            for (int i = 0; i < 3; i++)
            {
                driver.FindElement(By.XPath(xPathButtonFrom)).Click();
            }

            driver.FindElement(By.XPath(clockTimeInput1)).Click();
            wait.Until(d => driver.FindElement(By.XPath(xPathButtonTo)));

            for (int i = 0; i < 1; i++)
            {
                driver.FindElement(By.XPath(xPathButtonTo)).Click();
            }

            driver.FindElement(By.XPath(inputAssignedEmployees)).SendKeys(assignedEmployees);

            driver.FindElement(By.XPath(saveButton)).Click();
        }

        public void CheckNewRow()
        {
            string xPathFoundRow = $"//div[@class='oxd-table-row oxd-table-row--with-border' and contains(., '{shiftName}')]";
            wait.Until(d => driver.FindElement(By.XPath(xPathFoundRow)));
            IWebElement foundRow = driver.FindElement(By.XPath(xPathFoundRow));

            // Will work 
            Assert.NotZero(foundRow.FindElements(By.XPath($"//div[contains(., '{shiftName}')]")).Count);
            Assert.NotZero(foundRow.FindElements(By.XPath($"//div[contains(., '06:00')]")).Count);
            Assert.NotZero(foundRow.FindElements(By.XPath($"//div[contains(., '18:00')]")).Count);
            Assert.NotZero(foundRow.FindElements(By.XPath($"//div[contains(., '12.00')]")).Count);

        }

        public void RemoveRow()
        {
            string xPathDelete = $"//div[@class='oxd-table-row oxd-table-row--with-border' and contains(., '{shiftName}')]//i[@class='oxd-icon bi-trash']";

            wait.Until(d => driver.FindElement(By.XPath(xPathDelete)));
            IWebElement foundRow = driver.FindElement(By.XPath(xPathDelete));

            wait.Until(d => foundRow.FindElement(By.XPath("//button[@class='oxd-icon-button oxd-table-cell-action-space']")));
            foundRow.FindElement(By.XPath("//button[@class='oxd-icon-button oxd-table-cell-action-space']")).Click();
            wait.Until(d => driver.FindElement(By.XPath("//button[contains(.,'Yes, Delete')]"))).Click();

        }

        public void CheckRemovedRow()
        {

            string xPathDelete = $"//div[@class='oxd-table-row oxd-table-row--with-border' and contains(., '{shiftName}')]//i[@class='oxd-icon bi-trash']";


            if (driver.FindElements(By.XPath(xPathDelete)).Count > 0)
            {
                Assert.Fail();
            }
        }
    }
}
