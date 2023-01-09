using OpenQA.Selenium.Chrome;
using Pages;
using Selenium.Hooks;

namespace Selenium.Steps
{
    [Binding]
    public class TestOrangehrm 
    {
        public ChromeDriver driver = null;
        public Login login = null;
        public MainPage mainPage = null;
        public TimeShiftPage timeShiftPage = null;
        private Driver hooks = new Driver();

        [Given(@"we have logged in the site")]
        public void GivenWeHaveLoggenInTheSite()
        {
            login = new Login(driver);
            login.LoginPage();
        }

        [When(@"we go to the Work Shifts page")]
        public void WhenWeGoToTheWorkShiftsPage()
        {
            mainPage = new MainPage(driver);
            mainPage.GoToShiftPage();
        }

        [When(@"we add new work shift")]
        public void WhenWeAddNewWorkShift()
        {
            timeShiftPage = new TimeShiftPage(driver);
            timeShiftPage.ShiftTimeTo6To6();
        }

        [Then(@"we have new time shift")]
        public void ThenWeHaveNewTimeShift()
        {
            timeShiftPage.CheckNewRow();
        }

        [When(@"we delete new work shift row")]
        public void WhenWeDeleteNewWorkShiftRow()
        {
            timeShiftPage.RemoveRow();
        }

        [Then(@"we have work shift row removed")]
        public void ThenWeHaveWorkShiftRowRemoved()
        {
            timeShiftPage.CheckRemovedRow();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            driver = hooks.StartBrowser();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            hooks.Quit(driver);
        }
    }
}