using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabsProject.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
            
        }

        public IWebElement UsernameField => FindElement(By.XPath("//input[@data-test='username']"));
        public IWebElement PasswordField => FindElement(By.XPath("//input[@data-test='password']"));
        public IWebElement LoginButton =>  FindElement(By.XPath("//input[@data-test='login-button']"));
        public IWebElement ErrorMessage =>  FindElement(By.XPath("//h3[@data-test='error']"));

        public void Login(string username, string password)
        {
            Fill(UsernameField, username);
            Fill(PasswordField, password);
            ClickElement(LoginButton);
            
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BaseUrl);
        }



    }
}
