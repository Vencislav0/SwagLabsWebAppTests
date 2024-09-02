using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabsProject.Pages
{
    public class CheckoutCompletePage : BasePage
    {
        public CheckoutCompletePage(IWebDriver driver) : base(driver)
        {
            
        }

        public override string Url => BaseUrl + "/checkout-complete.html";

        public IWebElement BackHomeButton => FindElement(By.XPath("//button[@data-test='back-to-products']"));
        public IWebElement ValidationMessage => FindElement(By.XPath("//h2[@data-test='complete-header']"));

    }
}
