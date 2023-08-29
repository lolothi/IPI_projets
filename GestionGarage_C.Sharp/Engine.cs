using System;
using System.Runtime.CompilerServices;

namespace GestionGarage
{
    [Serializable]
    public class Engine
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

        //power
        protected int power;
        public int Power
        {
            get => power;
            set => power = value;
        }

        //engine type
        public enum typeEngineEnum
        {
            diesel, essence, hybrid, electric
        }

        private typeEngineEnum typeEngine;
        public typeEngineEnum TypeEngine
        {
            get => typeEngine; 
            set => typeEngine = value;
        }
        
        //constructor
        public Engine(string name, int power, typeEngineEnum typeEngine)
        {
            id = _incrementId++;
            this.name = name;
            this.power = power;
            this.typeEngine = typeEngine;
        }
        
        //display
        public void Display()
        {
            Console.WriteLine("Engine {0} Power:{1}ch type:{2}", name, power, typeEngine);
        }

   }
}