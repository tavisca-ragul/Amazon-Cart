using System;

namespace Shopping_Cart
{
    class NetBanking : IPayment
    {
        public bool Payment(double totalAmount)
        {
            try
            {
                Console.WriteLine("\t\tNet Banking");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

    }
}