using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FinalyProject
{

    /// <summary>
    /// Доставка
    /// </summary>
    abstract class Delivery
    {
        protected string address;

        protected bool isFilledAdress;
        /// <summary>
        /// Конструктор принимающий адресс доставки
        /// </summary>
        /// <param name="address">Адресс доставки</param>
        public Delivery(string address)
        {
            isFilledAdress = !string.IsNullOrEmpty(address);
            if (isFilledAdress) this.address = address;
            else this.address = string.Empty;
        }
      
        public virtual string PrintAddress()
        {
            if (isFilledAdress)
                return address; 
            else return "Адресс доставки не выбран";
        }
    }

    /// <summary>
    /// Доставка на дом
    /// </summary>
    class HomeDelivery : Delivery
    {
        public Courier courier;
        public HomeDelivery(string address) : base(address)
        {
            this.courier = new Courier(address);
        }
        public override string PrintAddress() 
        {
            return $"Курьер {courier.GetFullName()} доставит заказ по " +
                $"следующему адрессу: {address}";
        }
    }
    /// <summary>
    /// Доставка в пункт выдачи
    /// </summary>
    class PickPointDelivery : Delivery
    {
        private int numberPickPoint; // Номер пункта выдачи
        
        public int NumberPickPoint
        {
            get { return numberPickPoint + 1; }
            set 
            {
                numberPickPoint = isPickPoint(value);
            }
        }

        private static int isPickPoint(int index) // Проверка на существование пункта выдачи
        {
            if (index > 0 && index < PickPoint.address.Length)
                return index;
            return 0;
        }

        public override string PrintAddress()
        {
            return  $"Товар будет доставлен в пунтк выдачи №{NumberPickPoint} по адресу: " + address;
             
        }
        public PickPointDelivery(int numberPickPoint) : base(PickPoint.address[isPickPoint(numberPickPoint - 1)])
        {
            NumberPickPoint = numberPickPoint - 1;
        }
    }
    /// <summary>
    /// Доставка в партнерский магазин 
    /// </summary>
    class ShopDelivery : Delivery
    {
        private static string AddressShop()
        {
            Random rand = new Random();
            string address = string.Empty;
            switch (rand.Next(1, 4))
            {
                case 1:
                    address = "г. Симферополь, ул. Героев сталингарада 17";
                    break;
                case 2:
                    address = "г. Симферополь, ул. Киевская 141";
                    break;
                case 3:
                    address = "г. Симферополь, п-кт Победы 151";
                    break;
            }
            return address;
        }
        public ShopDelivery() : base(AddressShop())
        {

        }
        public override string PrintAddress()
        {
            DateTime date = DateTime.Now;
            return $"Заказ можно будет забрать {date.Tomorrow().ToString("D")} по адрессу: {address} "; // Использования метода расширения
        }
    }
    class PickPoint
    {
        public static string[] address;
        static PickPoint()
        {
            address = new string[] { "295015, Севастопольская, д. 62",
                                     "295000, Толстого ул., д. 4",
                                     "295043, Киевская ул., д. 5В",
                                     "295014, Евпаторийское шоссе, д. 8",
                                     "295035, Тав-Даир ул., д. 47",
                                     "295023, Беспалова ул., д. 156",
                                     "295026, Киевская ул., д. 96",
                                     "295022, Механизаторов ул., д. 51",
                                     "295015, Севастопольская ул., д. 52",
                                     "295035, Маршала Жукова ул., д. 21",
                                     "295047, Маршала Василевского ул., д. 16" };
        }
        public static int SetPickPoint()
        {
            int numberPickPoint;
            for (int i = 0; i < address.Length; i++) 
            {
                Console.WriteLine($"Пункт выдачи №{i+1} по адрессу: {address[i]}");
            }
            string answer;
            do
            {
                Console.Write("Выберите номер пункта выдачи: ");
                answer = Console.ReadLine();
            }
            while(!int.TryParse(answer, out numberPickPoint) || numberPickPoint < 1 || numberPickPoint > address.Length );
            return numberPickPoint;
        }
    }
    static class HomeShipAdress
    {
        public static string GetAdress()
        {
            string adress;
            do
            {
                Console.Write("Введите адресс доставки: ");
                adress = Console.ReadLine();
            } while (String.IsNullOrEmpty(adress));
            return adress;
        }
    }
}
