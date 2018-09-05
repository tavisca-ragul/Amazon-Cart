using System;

namespace Shopping_Cart
{
    class Home
    {
        private AmazonCart _Cart;
        private IPayment _Payment;
        private int _ID, _Quantity;
        string _Name;
        double _Price;
        int _PaymentMethod;

        public Home()
        {
            _Cart = new AmazonCart();
        }
        public void Display()
        {
            Console.Write("\t\t\tShopping Cart Operations\n1.Add Item to Cart\n2.Remove Item from Cart\n3.Show Items in Cart\n4.Clear Items in Cart\n5.Quantity of Items in Cart\n6.Total Amount\n7.Pay and Checkout\nSelect the Operation: ");
            byte choice = Convert.ToByte(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    
                    Console.WriteLine("-------------Adding Items Page------------");
                    Console.Write("Item ID:");
                    _ID = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Item Name:");
                    _Name = Console.ReadLine();
                    Console.Write("Item Quantity:");
                    _Quantity = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Item Price:");
                    _Price = Convert.ToDouble(Console.ReadLine());
                    try
                    {
                        if (!_Cart.AddItemToCart(new Item(_ID, _Name, _Quantity, _Price)))
                            throw new Exception();
                        Console.WriteLine("\t\tItem is Added\n");
                    }
                    catch (Exception message)
                    {
                        Console.WriteLine("\t\tItem is not Added\n");
                    }
                    Display();
                    break;
                case 2:
                    Console.WriteLine("--------------Remove Items Page-------------");
                    Console.Write("Item ID:");
                    _ID = Convert.ToInt32(Console.ReadLine());
                    try
                    {
                        if (!_Cart.RemoveItemFromCart(_ID))
                            throw new Exception();
                        Console.WriteLine("\t\tItem is Removed\n");
                    }
                    catch (Exception message)
                    {
                        Console.WriteLine("\t\tItem is not available in Cart\n");
                    }
                    Display();
                    break;
                case 3:
                    _Cart.ShowItemsInCart();
                    Display();
                    break;
                case 4:
                    try
                    {
                        if (!_Cart.ClearItemsInCart())
                            throw new Exception();
                        Console.WriteLine("\t\tCart is cleared\n");
                    }
                    catch (Exception message)
                    {
                        Console.WriteLine("\t\tNo items in cart to clear\n");
                    }
                    Display();
                    break;
                case 5:
                    Console.WriteLine("\t\tNumber of items in Cart: {0}", _Cart.GetQuantityOfItemsInCart());
                    Display();
                    break;
                case 6:
                    Console.WriteLine("\t\tTotal Amount of Items in Cart: {0}", _Cart.GetTotalAmountOfItemsInCart());
                    Display();
                    break;
                case 7:
                    Console.Write("\t\tPayment Method\n1.Cash on Delivery\n2.Net Banking\nSelect Payment Method: ");
                    _PaymentMethod = Convert.ToInt32(Console.ReadLine());
                    switch(_PaymentMethod)
                    {
                        case 1:
                            _Payment = new CashOnDelivery();
                            break;
                        case 2:
                            _Payment = new NetBanking();
                            break;
                    }
                    try
                    {
                        if (!_Cart.Payment(_Payment))
                            throw new Exception();
                        Console.WriteLine("\t\tPayment Success");
                    }
                    catch(Exception message)
                    {
                        Console.WriteLine("\t\tPayment Failed");
                    }
                    Display();
                    break;
                default:
                    Console.WriteLine("Wrong Operation...., Try again");
                    Display();
                    break;
            }
        }
    }
}