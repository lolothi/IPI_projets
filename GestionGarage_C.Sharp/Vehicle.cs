using System;
using System.Collections.Generic;
using GestionGarage.Properties;

namespace GestionGarage
{
    [Serializable]
    public abstract class Vehicle : IComparable
    {
        public List<Option> options = new List<Option>();

        private static int _incrementId = 1;
        
        //id
        protected int id;
        public int Id
        {
            get => id;
            set => id = value;
        }
        
        //name
        protected string name;
        
        public string Name
        {
            get => name;
            set => name = value;
        }
        
        //engine from Engine engine
        private Engine _vehiculeEngine;
        
        //price excluding tax (prix Hors taxe)
        protected decimal priceEt;
        public decimal PriceEt
        {
            get => priceEt;
            set => priceEt = value;
        }
        
        //brand
        public enum BrandEnum
        {
            Peugeot, Citroen, Renault, Audi, Ferrari
        }
        
        protected BrandEnum brand;

        public BrandEnum Brand
        {
            get => brand;
            set => brand = value;
        }
        
        //constructor
        public Vehicle(string name, decimal priceEt, BrandEnum brand, Engine engine)
        {
            id = _incrementId++;
            this.name = name;
            this.priceEt = priceEt;
            this.brand = brand;
            _vehiculeEngine = engine;
        }
        
        //calculate the taxes
        public abstract decimal CalculateTaxes();
        
        //display options
        public void DisplayOptions()
        {
            Console.WriteLine("OPTIONS: ");
            if (options.Count > 0)
            {
                foreach (Option option in options)
                {
                    Console.WriteLine("- Id.{0} {1} price:{2}€", option.Id, option.Name, option.Price);
                }
            }
            else
            {
                Console.WriteLine("No option for this vehicle");
            }
            
        }

        //Add option.  if option ou options null ??
        public void AddOption(Option option)
        {
            options.Add(option);
        }
        
        //Remove option.
        public void DelOption(Option option)
        {
            Console.WriteLine("option choisie: {0}", option.Name);
            options.Remove(option);
        }

        //final price : price excluding taxes + taxes + options prices
        public decimal FinalPrice()
        {
            decimal priceAllOptions = 0;
            foreach (Option option in options)
            {
                priceAllOptions = priceAllOptions + option.Price;
            }
            
            return priceAllOptions + priceEt + CalculateTaxes();
        }

        //display
        public virtual void Display()
        {
            Console.Write("*********** Information of the vehicle {0} **********\n", name);
            Console.WriteLine("Name: {0}, from brand: {1} and price (excluding taxes): {2} €", name, brand, priceEt);
            Console.WriteLine("Taxes:{0}€, Final Price(options & taxes):{1}€", CalculateTaxes(), FinalPrice());
            Console.WriteLine("Engine: {0} power:{1} type:{2}", _vehiculeEngine.Name, _vehiculeEngine.Power, _vehiculeEngine.TypeEngine);
            
            if (options.Count > 0)
            {
                DisplayOptions();
            }
            
        }
        
        public int CompareTo(object obj)
        {
            Vehicle vehicle = (Vehicle)obj;
            if (this.FinalPrice() < vehicle.FinalPrice())
            {
                return -1;
            }
            else if (this.FinalPrice() > vehicle.FinalPrice())
            {
                return 1;
            }
            else
            {
               return 0; 
            }

            
        }
    }
}