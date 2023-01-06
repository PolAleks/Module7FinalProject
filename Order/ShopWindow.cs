using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalyProject
{
    internal class ShopWindow
    {
        public ListProduct products;
        private int position;
        private int count;
        private Delivery delivery;
        public ShopWindow() 
        {
            products = new ListProduct();
        }
        /// <summary>
        /// Вывод на экран перечня товаров
        /// </summary>
        public void ShowProducts()
        {
            products.Print();
        }
        /// <summary>
        /// Выбор товара по номеру позиции
        /// </summary>
        /// <returns>Возвращает номер позиции товара</returns>
        public int GetPositionProduct()
        {
            do
            {
                QuestionInt("Выбирете номер товара: ", out position);
            }
            while (!(position > 0 && position < 5));
            Console.WriteLine($"Вы выбрали {products[position - 1].PrintProduct()}");
            return position;
        }
        /// <summary>
        /// Выбор кол-ва товара
        /// </summary>
        /// <returns>Возращает кол-во приобретаемого товара</returns>
        public int GetCountProduct()
        {
            do
            {
                QuestionInt($"Сколько {products[position - 1].PrintProduct()} будете брать: ", out count);
            }
            while (!count.IsInRange(products[position - 1].CountProduct + 1));
            return count;
        }
        /// <summary>
        /// Выбор способа доставки
        /// </summary>
        /// <returns>Возращает вариант доставки</returns>
        public Delivery GetDeliveryMethod()
        {
            Console.WriteLine("Выберите способ доставки:\n" +
                              "1. Доставка курьером на дом\n" +
                              "2. Доставка в пункт выдачи\n" +
                              "3. Доставка в магазин на следующий день");
            int deliveryMethod;

            QuestionInt("Выбирете способ доставки: ", out deliveryMethod);

            Console.WriteLine(new String('-', 50));

            switch (deliveryMethod)
            {
                case 1:
                    return new HomeDelivery(HomeShipAdress.GetAdress());
                case 2:
                    return new PickPointDelivery(PickPoint.SetPickPoint());
                case 3:
                    return new ShopDelivery();
                default:
                    return new ShopDelivery();
            }
        }

        static void QuestionInt(string question, out int answer)
        {
            string enterData;
            bool isInt;
            do
            {
                Console.Write(question);
                enterData = Console.ReadLine();
                isInt = int.TryParse(enterData, out answer);
            } while (!isInt);
            if (answer < 1)
            {
                QuestionInt("Введите значение отличное от нуля: ", out answer);
            }
        }
    }

}
