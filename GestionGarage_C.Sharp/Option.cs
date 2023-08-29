using System;

namespace GestionGarage.Properties
{
    [Serializable]
    public class Option
    {
        //id 
        protected int id;
        public int Id
        {
            get => id;
            set => id = value;
        }
        private static int _incrementId = 1;
        
        //name
        protected string name;
        public string Name
        {
            get => name;
            set => name = value;
        }
        
        //price
        protected decimal price;
        public decimal Price
        {
            get => price;
            set => price = value;
        }

        //constructor
        public Option(string name, decimal price)
        {
            id = _incrementId++;
            this.name = name;
            this.price = price;
        }
        
        //display
        public void Display()
        {
            Console.WriteLine("Option: {0} {1}€", name, price);
        }
        
    }
}