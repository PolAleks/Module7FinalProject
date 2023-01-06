using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalyProject
{
    internal class Product
    {
        private int idProduct;
        private string nameProduct;
        private decimal priceProduct;
        private int countProduct;

        public int IdProduct
        { 
            get { return idProduct; } 
            private set { idProduct = value; }
        }
        public string NameProduct
        {
            get { return nameProduct; }
            private set { nameProduct = value; }
        }

        public decimal PriceProduct
        {
            get { return priceProduct; }
            private set { priceProduct = value; }
        }
        public int CountProduct
        {
            get { return countProduct; }
            private set { countProduct = value; }
        }
        
        public Product(int id, string name, decimal price, int count) 
        {
            idProduct = id;
            nameProduct = name;
            priceProduct = price;
            countProduct = count;
        }
        public string PrintProduct()
        {
            return $"{nameProduct} за {priceProduct} рублей";
        }
    }

    class ListProduct
    {
        private Product[] products;
        public ListProduct() 
        {
            this.products = GetDBProduct();
        }
        private Product[] GetDBProduct()
        {
            Product[] products =  { new Product( 1, "Телевизор", 12000, 4 ),
                                    new Product( 2, "Стиральная машина", 15000, 7),
                                    new Product( 3, "Холодильник", 30000, 12),
                                    new Product( 4, "Водонагреватель", 17000, 3)};
            return products;
        }
        public void Print()
        {
            Console.WriteLine(String.Format("{0, -3} {1, 22} {2, 7} {3, 3}" , "№ |", "Наименование |","Цена |", "Кол-во"));
            Console.WriteLine(new string('-',43));
            foreach(Product p in products)
            {
                Console.WriteLine($"{p.IdProduct, -1} | {p.NameProduct, 20} | {p.PriceProduct, -3} | {p.CountProduct, 1}");
            }
        }
        public Product this[int index]
        {
            get 
            {
                if (index.IsInRange(products.Length))
                    return products[index];
                return null;
            }
            set 
            {
                if (index.IsInRange(products.Length))
                    products[index] = value;
            }
        }
    }
}
