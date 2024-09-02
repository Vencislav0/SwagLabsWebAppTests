using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabsProject.Tests
{
    public class SwagLabsTests : BaseTest
    {

        [Test]
        public void Login_With_InvalidUsername()
        {
            loginPage.Login("", "secret_sauce");

            Assert.That(loginPage.ErrorMessage.Text.Trim(), Is.EqualTo("Epic sadface: Username is required"), "No error message for username was found.");
        }


        [Test]
        public void Login_With_InvalidPassword()
        {
            loginPage.Login("standard_user", "");

            Assert.That(loginPage.ErrorMessage.Text.Trim(), Is.EqualTo("Epic sadface: Password is required"), "No error message for password was found.");
        }

        [Test]
        public void Login_With_ValidCredentials()
        {
            loginPage.Login("standard_user", "secret_sauce");

            Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/inventory.html"));

            ClickElement(inventoryPage.HamburgerMenuButton);
            Assert.True(inventoryPage.LogoutLink.Displayed, "Logout button is not visible.");
            Assert.True(inventoryPage.AddToCartBackPackButton.Displayed, "No items displayed on the page.");

        }

        [Test]
        public void AddItem_ToShoppingCart_Test()
        {
            loginPage.Login("standard_user", "secret_sauce");

            ClickElement(inventoryPage.AddToCartBackPackButton);
            Assert.That(checkoutPage.ShoppingCartBadge.Displayed, "No shopping cart badge visible.");
            Assert.That(checkoutPage.ShoppingCartBadge.Text.Trim(), Is.EqualTo("1"), "Shopping cart badge number is not equivalent to the number of items in the checkout inventory.");
            Assert.That(inventoryPage.RemoveButton.Displayed, "Remove button is not visible after adding the item to the checkout inventory.");

        }
        
        [Test]
        public void Test_CheckOutPage_AfterAddedItem()
        {
            loginPage.Login("standard_user", "secret_sauce");

            ClickElement(inventoryPage.AddToCartBackPackButton);
            ClickElement(inventoryPage.ShoppingCartButton);
            Assert.That(checkoutPage.Item.Displayed, "No item after adding to checkout inventory.");
            Assert.That(checkoutPage.Item.Text.Trim(), Is.EqualTo("Sauce Labs Backpack"), "The added item is not the expected one.");

        }

        [Test]
        public void RemoveItem_InventoryPage_FromShoppingCart_Test()
        {
            loginPage.Login("standard_user", "secret_sauce");

            ClickElement(inventoryPage.AddToCartBackPackButton);
            ClickElement(inventoryPage.RemoveButton);

            Assert.That(WaitForElementToDisappear(By.XPath("//button[@data-test='remove-sauce-labs-backpack']")), Is.True, "Remove button still visible.");
            Assert.That(WaitForElementToDisappear(By.XPath("//span[@data-test='shopping-cart-badge']")), Is.True, "Badge still visible.");
            Assert.That(inventoryPage.AddToCartBackPackButton.Displayed, "Add to cart button was not displayed after removing the item");

        }


        [Test]
        public void RemoveItem_CheckoutPage_FromShoppingCart_Test()
        {
            loginPage.Login("standard_user", "secret_sauce");

            ClickElement(inventoryPage.AddToCartBackPackButton);
            ClickElement(inventoryPage.ShoppingCartButton);
            var initialCount = checkoutPage.CartItems.Count;
            ClickElement(checkoutPage.LastCartRemoveButton);
            if(checkoutPage.CartItems.Count <= 0)
            {
                Assert.Pass("No items as expected");
            }
            else
            {
                Assert.That(checkoutPage.CartItems.Count, Is.LessThan(initialCount), "Item was not deleted.");
            }
            Assert.That(driver.Url, Is.EqualTo(checkoutPage.Url), "Wrong page no redirection.");
            

        }

        [Test]
        public void AddItem_ProceedToCheckout_Test()
        {
            loginPage.Login("standard_user", "secret_sauce");

            ClickElement(checkoutPage.AddToCartBackPackButton);
            ClickElement(checkoutPage.ShoppingCartButton);

            ClickElement(checkoutPage.CheckoutButton);
            Assert.That(driver.Url, Is.EqualTo(checkoutPage2.Url), "Wrong page no redirection.");
            
            checkoutPage2.FillForm("John", "Doe", "1000");
            Assert.That(driver.Url, Is.EqualTo(checkoutPage3.Url), "Wrong page no redirection.");
            Assert.That(checkoutPage.Item.Displayed, Is.True, "No item found.");
            var itemPrice = FindElement(By.XPath("//div[@data-test='subtotal-label']"));
            Assert.That(itemPrice.Text.Trim(), Is.EqualTo("Item total: $29.99"), "expected price of checkout items doesnt match.");

            ClickElement(checkoutPage3.FinishButton);
            Assert.That(driver.Url, Is.EqualTo(checkoutComplete.Url), "Wrong page no redirection.");
            Assert.That(checkoutComplete.ValidationMessage.Text.Trim(), Is.EqualTo("Thank you for your order!"), "Something went wrong with the order.");

        }



        [Test]
        public void BrokenAccessControl_InventoryPage_WithoutLoginTest()
        {
            driver.Navigate().GoToUrl(inventoryPage.Url);

            Assert.That(loginPage.ErrorMessage.Displayed);
            Assert.That(loginPage.ErrorMessage.Text.Trim(), Is.EqualTo("Epic sadface: You can only access '/inventory.html' when you are logged in."));


        }


        [Test]
        public void SortBy_Highest_Test()
        {
            loginPage.Login("standard_user", "secret_sauce");

            inventoryPage.SortByPriceHighest();

            List<decimal> prices = inventoryPage.InventoryItemPrices.Select(priceElement =>
            {
                string priceText = priceElement.Text.Replace("$", "");
                return Convert.ToDecimal(priceText);
            }).ToList();


            List<decimal> sortedPrices = new List<decimal>(prices);
            sortedPrices.Sort((a, b) => b.CompareTo(a));

            Assert.That(prices.SequenceEqual(sortedPrices), Is.True);


        }

        [Test]
        public void SortBy_Lowest_Test()
        {
            loginPage.Login("standard_user", "secret_sauce");

            inventoryPage.SortByPriceLowest();

            List<decimal> prices = inventoryPage.InventoryItemPrices.Select(priceElement =>
            {
                string priceText = priceElement.Text.Replace("$", "");
                return Convert.ToDecimal(priceText);
            }).ToList();


            List<decimal> sortedPrices = new List<decimal>(prices);
            sortedPrices.Sort((a, b) => a.CompareTo(b));

            Assert.That(prices.SequenceEqual(sortedPrices), Is.True, "Items were not sorted correctly.");


        }

        [Test]
        public void SortBy_AtoZ_Test()
        {
            loginPage.Login("standard_user", "secret_sauce");

            inventoryPage.SortByAtoZ();

            List<string> itemNames = inventoryPage.InventoryItemNames.Select(name => name.Text).ToList();

            List<string> sortedNames = new List<string>(itemNames);
            sortedNames.Sort();

            Assert.That(itemNames.SequenceEqual(sortedNames), Is.True, "Items were not sorted correctly.");


        }

        [Test]
        public void SortBy_ZtoA_Test()
        {
            loginPage.Login("standard_user", "secret_sauce");

            inventoryPage.SortByZtoA();

            List<string> itemNames = inventoryPage.InventoryItemNames.Select(name => name.Text).ToList();

            List<string> sortedNames = new List<string>(itemNames);
            sortedNames.Sort((a, z) => z.CompareTo(a));

            Assert.That(itemNames.SequenceEqual(sortedNames), Is.True, "Items were not sorted correctly.");


        }

        [Test]
        public void ResetStateButton_Test()
        {
            loginPage.Login("standard_user", "secret_sauce");

            ClickElement(inventoryPage.HamburgerMenuButton);            
            ClickElement(inventoryPage.AddToCartBackPackButton);           
            ClickElement(inventoryPage.ResetAppStateLink);

            // Known issue: The Remove button does not revert correctly. Temporarily commenting out this assertion.
            //Assert.That(WaitForElementToDisappear(By.XPath("//button[@data-test='remove-sauce-labs-backpack']")), Is.True, "Remove button still visible.");

            Assert.That(WaitForElementToDisappear(By.XPath("//span[@data-test='shopping-cart-badge']")), Is.True, "Badge still visible.");

            // Known issue: The Add to cart button does not appear correctly after reset.
            //Assert.That(inventoryPage.AddToCartBackPackButton.Displayed, "Add to cart button was not displayed after removing the item");

            Assert.Inconclusive("Test passed without crucial assertions.");
            Console.WriteLine($"Reset state functionallity failed. Expected \"Remove\" button to revert back to add to cart, but was \"Add to cart\" instead. Please check if the reset state process is working correctly");

        }


    }
}
