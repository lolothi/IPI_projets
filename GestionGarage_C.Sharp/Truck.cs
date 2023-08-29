using System;

namespace GestionGarage
{
    [Serializable]
    public class Truck : Vehicle
    {
        //number of axles
        protected int nbAxle;
        public int NbAxle
        {
            get => nbAxle;
            set => nbAxle = value;
        }
        
        //weight
        protected int weight;
        public int Weight
        {
            get => weight;
            set => weight = value;
        }
        
        //volume
        protected int volume;
        public int Volume
        {
            get => volume;
            set => volume = value;
        }
        
        //constructor
        public Truck(string name, decimal priceEt, BrandEnum brand, Engine engine,int nbAxle, int weight, int volume) : base(name, priceEt, brand, engine)
        {
            this.nbAxle = nbAxle;
            this.weight = weight;
            this.volume = volume;
        }
        
        //calculate the taxes
        public override decimal CalculateTaxes()
        {
            return nbAxle*50;
        }
        
        //display
        public override void Display()
        {
            base.Display();
            Console.WriteLine("Number of axles: {0}", nbAxle);
            Console.WriteLine("Weight: {0}kg", weight);
            Console.WriteLine("Volume: {0}m3", volume);
        }
    }
}