namespace Shopping_Cart
{
    class Item
    {
        public int ID { get; }
        public string Name { get; }
        public int Quantity { get; }
        public double Price { get; }

        public Item(int id, string name, int quantity, double price)
        {
            ID = id;
            Name = name;
            Quantity = quantity;
            Price = price;
        }
    }
}