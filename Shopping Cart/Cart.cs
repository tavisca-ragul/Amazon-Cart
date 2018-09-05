using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopping_Cart
{
    class AmazonCart : ICart
    {
        private List<Item> _Items;

        public AmazonCart()
        {
            _Items = new List<Item>();
        }

        public bool AddItemToCart(Item item)
        {
            try
            {
                _Items.Add(item);
                return true;
            }
            catch (Exception message)
            {
                return false;
            }
        }

        public bool ClearItemsInCart()
        {
            try
            {
                if(!_Items.Any())
                    throw new Exception();
                _Items.Clear();
                return true;
            }
            catch(Exception message)
            {
                return false;
            }
        }

        public int GetQuantityOfItemsInCart()
        {
            int quantity = 0;
            foreach (var item in _Items)
                quantity += item.Quantity;
            return quantity;
        }

        public bool RemoveItemFromCart(int itemID)
        {
            try
            {
                var itemToRemove = _Items.Single(item => item.ID == itemID);
                _Items.Remove(itemToRemove);
                return true;
            }
            catch(Exception message)
            {
                return false;
            }
        }

        public void ShowItemsInCart()
        {
            try
            {
                Console.WriteLine("-------------Items in Cart---------------");
                if (_Items.Count == 0)
                    Console.WriteLine("\n\tCart is Empty\n");
                else
                {
                    foreach (var item in _Items)
                        Console.WriteLine("Item ID: {0}\nItem Name: {1}\nQuantity: {2}\nPrice: {3}\n-----------------------------------------", item.ID, item.Name, item.Quantity, item.Price);
                    Console.WriteLine("\tNumber of items in Cart: {0}", GetQuantityOfItemsInCart());
                    Console.WriteLine("\tTotal Amount of Items in Cart: {0}\n------------------------------------------", GetTotalAmountOfItemsInCart());
                }
            }
            catch(Exception message)
            {
                Console.WriteLine(message);
            }
        }

        public double GetTotalAmountOfItemsInCart()
        {
            double amount = 0;
            foreach (var item in _Items)
                amount += item.Price * item.Quantity;
            return amount;
        }

        public bool Payment(IPayment payment)
        {
            try
            {
                if (!payment.Payment(GetTotalAmountOfItemsInCart()))
                    throw new Exception();
                //saveorderdetails
                _Items.Clear();
                return true;
            }
            catch(Exception message)
            {
                return false;
            }
        }
    }
}