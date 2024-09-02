using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabsProject.Pages
{
    public class InventoryPage : BasePage
    {
        public InventoryPage(IWebDriver driver) : base(driver)
        {
            
        }


        public override string Url => BaseUrl + "/inventory.html";

        public IList<IWebElement> Items => FindElements(By.XPath("//div[@class='inventory_item_description']"));
        public IWebElement LastInventoryItem => Items.Last().FindElement(By.XPath(".//div[@class='inventory_item_description']"));
        public IList<IWebElement> InventoryItemPrices => FindElements(By.XPath(".//div[@data-test='inventory-item-price']"));
        public IList<IWebElement> InventoryItemNames => FindElements(By.ClassName("inventory_item_name"));
        public IWebElement SortMenu => FindElement(By.XPath("//select[@data-test='product-sort-container']"));

        public void SortByPriceHighest()
        {
            SelectElement dropdown = new SelectElement(SortMenu);
            dropdown.SelectByValue("hilo");

        }

        public void SortByPriceLowest()
        {
            SelectElement dropdown = new SelectElement(SortMenu);
            dropdown.SelectByValue("lohi");

        }

        public void SortByAtoZ()
        {
            SelectElement dropdown = new SelectElement(SortMenu);
            dropdown.SelectByValue("az");

        }

        public void SortByZtoA()
        {
            SelectElement dropdown = new SelectElement(SortMenu);
            dropdown.SelectByValue("za");

        }


    }
}
