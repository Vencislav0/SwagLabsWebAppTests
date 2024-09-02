using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabsProject.Pages
{
    public class CheckoutPage : BasePage
    {
        public CheckoutPage(IWebDriver driver) : base(driver)
        {
            
        }
        public override string Url => BaseUrl + "/cart.html";
        public IWebElement CheckoutButton => FindElement(By.XPath("//button[@data-test='checkout']"));
        public IWebElement Item => FindElement(By.XPath("//div[@data-test='inventory-item-name']"));
        public IWebElement ContinueShoppingButton => FindElement(By.XPath("//button[@data-test='continue-shopping']"));
        public IWebElement ShoppingCartBadge => FindElement(By.XPath("//span[@data-test='shopping-cart-badge']"));
        public IList<IWebElement> CartItems => driver.FindElements(By.XPath("//div[@class='cart_item_label']"));
        public IWebElement LastCartItem => CartItems.Last().FindElement(By.XPath(".//div[@class='cart_item_label']"));
        public IWebElement LastCartRemoveButton => CartItems.Last().FindElement(By.XPath(".//button[@class='btn btn_secondary btn_small cart_button']"));

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);
        }
    }
}
