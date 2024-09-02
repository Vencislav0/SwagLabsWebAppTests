using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabsProject.Pages
{
    public class CheckoutPage2 : BasePage
    {
        public CheckoutPage2(IWebDriver driver) : base(driver)
        {
            
        }

        public override string Url => BaseUrl + "/checkout-step-one.html";

        public IWebElement FirstNameField => FindElement(By.XPath("//input[@data-test='firstName']"));
        public IWebElement LastNameField => FindElement(By.XPath("//input[@data-test='lastName']"));
        public IWebElement PostalCodeField => FindElement(By.XPath("//input[@data-test='postalCode']"));
        public IWebElement ContinueButton => FindElement(By.XPath("//input[@data-test='continue']"));
        public IWebElement CancelButton => FindElement(By.XPath("//button[@data-test='cancel']"));
        public IWebElement ErrorMessage => FindElement(By.XPath("//button[@data-test='cancel']"));

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);
        }

        public void FillForm(string firstName, string lastName, string postalCode)
        {
            Fill(FirstNameField, firstName);
            Fill(LastNameField, lastName);
            Fill(PostalCodeField, postalCode);
            ClickElement(ContinueButton);
        }



    }
}
