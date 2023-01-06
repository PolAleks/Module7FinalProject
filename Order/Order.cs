using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalyProject
{
    class Order<TDelivery> where TDelivery : Delivery
    {
        public TDelivery Delivery;

        public int Number;

        public Product product;

        public void DisplayAddress()
        {
            Console.WriteLine(Delivery.PrintAddress());
        }
        public Order(TDelivery delivery, int number, Product product)
        {
            Delivery = delivery;
            Number = number;
            this.product = product;
        }
    }

    class ListOrder
    {
        private Order<Delivery>[] orders;
        private int index;
        public ListOrder(params Order<Delivery>[] orders)
        {
            this.orders = orders;
            index = orders.Length - 1;
        }

        public Order<Delivery> this[int index]
        {
            get
            {
                if (index.IsInRange(orders.Length))
                    return orders[index];
                else
                    return null;
            }
            set
            {
                if (index.IsInRange(orders.Length))
                    orders[index] = value;
            }
        }

        public void AddOrder(Order<Delivery> order)
        {
            if ((orders.Length - 1) == index)
                Array.Resize(ref this.orders, orders.Length * 2);
            index++;
            this.orders[index] = order;
        }
        
        public void PrintListOrders()
        {
            for (int i = 0; i <= index; i++)
            {
                Console.WriteLine(orders[i].Delivery.PrintAddress());
            }
        }
    }
}
