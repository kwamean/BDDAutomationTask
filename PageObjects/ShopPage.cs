using BDDAutomationTask.Hooks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BDDAutomationTask.PageObjects
{
    public class ShopPage
    {
        public IWebDriver driver;
        public ShopPage()
        {
            driver = WebHooks.driver;
        }
        //article[@class='col-md-9']
        //h1[@class='page-title']

        private By bikini = By.XPath("//li[contains(@class,'product type-product post-22 status-publish first instock product_cat-clothing product_cat-womens-clothing has-post-thumbnail sale shipping-taxable purchasable product-type-simple')]//span[contains(text(),'Add to wishlist')]");
        private By blackTrousers = By.XPath("//li[contains(@class,'product type-product post-15 status-publish instock product_cat-clothing product_cat-mens-clothing has-post-thumbnail sale shipping-taxable purchasable product-type-simple')]//span[contains(text(),'Add to wishlist')]");
        private By eveningTrousers = By.XPath("//li[contains(@class,'product type-product post-16 status-publish last instock product_cat-clothing product_cat-mens-clothing has-post-thumbnail sale shipping-taxable purchasable product-type-simple')]//span[contains(text(),'Add to wishlist')]");
        private By hardTop = By.XPath("//li[contains(@class,'product type-product post-18 status-publish instock product_cat-clothing product_cat-womens-clothing has-post-thumbnail shipping-taxable purchasable product-type-simple')]//span[contains(text(),'Add to wishlist')]");
        private By wishList = By.XPath("//div[contains(@class,'header-right col-md-3 hidden-xs')]//i[contains(@class,'lar la-heart')]");
        private By lowestPriced = By.XPath("//a[@aria-label='Add “Bikini” to your cart']");
        private By cart = By.XPath("//div[@class='header-right col-md-3 hidden-xs']//i[@class='la la-shopping-bag']");
        public void ProductsWishlist()//span[normalize-space()='Product name'] //h2[normalize-space()='My wishlist']
        {
            var shopResultPage = driver.FindElement(By.XPath("//span[normalize-space()='Product name']"));
            var products = new List<IWebElement>(shopResultPage.FindElements(By.TagName("a")));
            foreach (IWebElement product in products)
            {
                Console.WriteLine(product);
                IWebElement element = product;
                string prod = element.GetAttribute("href");
                //log.Info(url + "found url in results page");
                Assert.That(prod.Contains("Hard top"));
                Assert.That(prod.Contains("Evening trousers"));
                Assert.That(prod.Contains("Black trousers"));
                Assert.That(prod.Contains("Bikini"));
            }
        }

        public void ShopFor4Products()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(e => e.FindElement(bikini));
            driver.FindElement(bikini).Click();
            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait1.Until(e => e.FindElement(blackTrousers));
            driver.FindElement(blackTrousers).Click();
            driver.FindElement(eveningTrousers).Click();
            driver.FindElement(hardTop).Click();
        }

        public void WishList()
        {
            driver.FindElement(wishList).Click();
        }
        public void AddLowestPriceProductToCart()
        {
            driver.FindElement(lowestPriced).Click();
        }

        public void CartItems()
        {
            driver.FindElement(cart).Click();
        }

        public void CheckCartItems(string cartItems )
        {
            var shopResultPage = driver.FindElement(By.XPath("//span[normalize-space()='Product name']"));
            var products = new List<IWebElement>(shopResultPage.FindElements(By.TagName("a")));
            foreach (IWebElement product in products)
            {
                Console.WriteLine(product);
                IWebElement element = product;
                string prod = element.GetAttribute("href");
                Assert.That(prod.Contains(cartItems));
            }
        }
    }
}
