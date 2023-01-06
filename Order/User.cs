using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;

namespace FinalyProject
{
    abstract class User
    {
        protected string firstName;
        protected string lastName;
        protected string email;
        protected string login;
        protected string password;
        public string GetFullName()
        {
            return firstName +" " + lastName;
        }
        public User(string firstName = "Вася",
                    string lastName = "Пупкин",
                    string email = "vv.pupkin@yandex.ru",
                    string login = "pupkin",
                    string password = "password")
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.login = login;
            this.password = password;
        }
    }
    class Customer : User
    {
        public Customer() : base() 
        {

        }
        
        // Поле массив заказов с индексатором
    }

    class Manager : User
    {   

        // Методы обработки заказов
    }

    class Courier : User
    {
        private string address;
        
        public Courier(string address) : base()
        {
            this.address = address;
        }
    }
}
