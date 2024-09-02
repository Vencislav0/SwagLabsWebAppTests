using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabsProject.Pages
{
    public class CheckoutPage3 : BasePage
    {
        public CheckoutPage3(IWebDriver driver) : base(driver)
        {
            
        }

        public override string Url => BaseUrl + "/checkout-step-two.html";
        public IWebElement FinishButton => FindElement(By.XPath("//button[@data-test='finish']"));
        public IWebElement CancelButton => FindElement(By.XPath("//button[@data-test='cancel']"));

    }
}
