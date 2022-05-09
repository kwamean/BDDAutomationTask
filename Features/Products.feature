Feature: Products
	Add product to wishlist and select the lowest to add to cart

@mytag
Scenario: Verify four items added wishlist and add the lowest price to cart
	Given I add four different products to my wish list
	When I view my wishlist table
	Then I find total four selected items in my Wishlist
	When I search the lowest price product
	And I am able to add the lowest price to my cart
	Then I am able to verify the item in my cart