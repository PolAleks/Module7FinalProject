using System;

namespace FinalyProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShopWindow shoping = new ShopWindow();
            shoping.ShowProducts();
            Console.WriteLine(new String('-', 50));

            int position = shoping.GetPositionProduct();
            Console.WriteLine(new String('-', 50));

            int count = shoping.GetCountProduct();
            Console.WriteLine(new String('-', 50));

            Delivery delivery = shoping.GetDeliveryMethod();
            
            Order<Delivery> order = new Order<Delivery>(delivery, 1, shoping.products[position - 1]);

            ListOrder listOrder = new ListOrder(order);

            Console.WriteLine(new String('-', 50));

            listOrder.PrintListOrders();
        }
    } 
}