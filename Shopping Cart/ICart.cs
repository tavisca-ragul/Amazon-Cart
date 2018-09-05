namespace Shopping_Cart
{
    interface ICart
    {
        bool AddItemToCart(Item item);
        bool RemoveItemFromCart(int itemID);
        void ShowItemsInCart();
        bool ClearItemsInCart();
        int GetQuantityOfItemsInCart();
        double GetTotalAmountOfItemsInCart();
        bool Payment(IPayment payment);
    }
}