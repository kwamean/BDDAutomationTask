//this is an automation assignment even though is made public on github for assessment, its content at solely for the intended client


namespace BDDAutomationTask.Steps
{
    using BDDAutomationTask.PageObjects;
    using TechTalk.SpecFlow;

    [Binding]
    public class ProductsSteps
    {
        HomePage _homePage = new HomePage();
        ShopPage _shopPage = new ShopPage();

        [Given(@"I add four different products to my wish list")]
        public void GivenIAddFourDifferentProductsToMyWishList()
        {
             _homePage.CookiesPreference();
            _homePage.SelectProduct();
    
        }
        
        [When(@"I view my wishlist table")]
        public void WhenIViewMyWishlistTable()
        {
            _shopPage.ShopFor4Products();
            _shopPage.WishList();
        }
        
        [When(@"I search the lowest price product")]
        public void WhenISearchTheLowestPriceProduct()
        {
            //_shopPage.AddLowestPriceProductToCart();
        }
        
        [When(@"I am able to add the lowest price to my cart")]
        public void WhenIAmAbleToAddTheLowestPriceToMyCart()
        {
            _shopPage.AddLowestPriceProductToCart();
        }
        
        [Then(@"I find total four selected items in my Wishlist")]
        public void ThenIFindTotalFourSelectedItemsInMyWishlist()
        {
            _shopPage.ProductsWishlist();
        }
        
        [Then(@"I am able to verify the item in my cart")]
        public void ThenIAmAbleToVerifyTheItemInMyCart(string cartItems)
        {
            _shopPage.CheckCartItems(cartItems);
        }
    }
}
