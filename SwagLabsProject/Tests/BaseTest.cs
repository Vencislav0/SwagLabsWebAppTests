using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SwagLabsProject.Pages;

namespace SwagLabsProject.Tests
{
    public class BaseTest
    {
        protected IWebDriver driver;
        protected LoginPage loginPage;
        protected CheckoutPage checkoutPage;
        protected CheckoutPage2 checkoutPage2;
        protected CheckoutPage3 checkoutPage3;
        protected CheckoutCompletePage checkoutComplete;
        protected WebDriverWait wait;
        protected Actions actions;
        protected InventoryPage inventoryPage;
        

        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--disable-search-engine-choice-screen");
            options.AddUserProfilePreference("profile.password_manager_enabled", false);           
            options.AddArgument("--headless");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--disable-gpu");


            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            loginPage = new LoginPage(driver);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));            
            checkoutPage = new CheckoutPage(driver);
            inventoryPage = new InventoryPage(driver);
            checkoutPage2 = new CheckoutPage2(driver);
            checkoutPage3 = new CheckoutPage3(driver);
            checkoutComplete = new CheckoutCompletePage(driver);
            actions = new Actions(driver);

            loginPage.OpenPage();

        }

        [TearDown]
        public void TearDown() 
        {
            driver?.Quit();
            driver?.Dispose();
        }





        public IWebElement FindElement(By locator)
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        public IList<IWebElement> FindElements(By locator)
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));
        }

        public bool WaitForElementToDisappear(By locator)
        {
             return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        public void ClickElement(IWebElement element)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element)).Click();
        }
        public void Fill(IWebElement element, string keys)
        {

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
            element.SendKeys(keys);
        }



        public void ScrollToElement(By locator)
        {
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
            actions.ScrollToElement(element).Perform();
        }


    }
}