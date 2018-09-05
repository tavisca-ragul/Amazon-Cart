using System;

namespace Shopping_Cart
{
    class CashOnDelivery : IPayment
    {
        public bool Payment(double totalAmount)
        {
            try
            {
                Console.WriteLine("\t\tCash On Delivery");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}