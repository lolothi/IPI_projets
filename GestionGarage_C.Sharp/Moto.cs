using System;

namespace GestionGarage
{
    [Serializable]
    public class Moto : Vehicle
    {
        //cubic capacity
        protected int cubicCapacity;
        public int CubicCapacity
        {
            get => cubicCapacity;
            set => cubicCapacity = value;
        }
        
        //constructor
        public Moto(string name, decimal priceEt, BrandEnum brand, Engine engine, int cubicCapacity) : base(name, priceEt, brand, engine)
        {
            this.cubicCapacity = cubicCapacity;
        }
        
        //calculate taxes
        public override decimal CalculateTaxes()
        {
            return Math.Truncate(cubicCapacity*(decimal)0.3) ;
        }

        //display
        public override void Display()
        {
            base.Display();
            Console.WriteLine("Cubic capacity: {0}", cubicCapacity);
        }
    }
}