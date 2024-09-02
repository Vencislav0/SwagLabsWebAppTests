using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabsProject.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;
        public static readonly string BaseUrl = "https://www.saucedemo.com";
        protected WebDriverWait wait;
        protected Actions actions;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            actions = new Actions(driver);
        }

        public virtual string Url => BaseUrl + "";
        public IWebElement ShoppingCartButton => FindElement(By.XPath("//a[@data-test='shopping-cart-link']"));
        public IWebElement HamburgerMenuButton => FindElement(By.XPath("//button[@id='react-burger-menu-btn']"));
        public IWebElement AllItemsLink => FindElement(By.XPath("//a[@id='inventory_sidebar_link']"));
        public IWebElement AboutLink => FindElement(By.XPath("//a[@id='about_sidebar_link']]"));
        public IWebElement LogoutLink => FindElement(By.XPath("//a[@id='logout_sidebar_link']"));
        public IWebElement ResetAppStateLink => FindElement(By.XPath("//a[@id='reset_sidebar_link']"));
        public IWebElement AddToCartBackPackButton => FindElement(By.XPath("//button[@id='add-to-cart-sauce-labs-backpack']"));
        public IWebElement RemoveButton => FindElement(By.XPath("//button[@data-test='remove-sauce-labs-backpack']"));

        public IWebElement FindElement(By locator)
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
            
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

        public IList<IWebElement> FindElements(By locator)
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));
        }

        public void ScrollToElement(By locator)
        {
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
            actions.ScrollToElement(element).Perform();
        }

        







    }
}
