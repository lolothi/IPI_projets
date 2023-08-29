using System;

namespace GestionGarage
{
    [Serializable]
    public class Car : Vehicle
    {
        //fiscal power
        protected int fiscalPower;
        public int FicaslPower
        {
            get => fiscalPower;
            set => fiscalPower = value;
        }
        //number of doors
        protected int nbDoors;
        public int Nbdoors
        {
            get => nbDoors;
            set => nbDoors = value;
        }
        //number of seats
        protected int nbSeats;
        public int NbSeats
        {
            get => nbSeats;
            set => nbSeats = value;
        }
        //size of the trunk
        protected int sizeTrunk;
        public int SizeTrunk
        {
            get => sizeTrunk;
            set => sizeTrunk = value;
        }
        
        //constructor
        public Car(string name, decimal priceEt, BrandEnum brand, Engine engine,int fiscalPower, int nbDoors, int nbSeats, int sizeTrunk) : base(name, priceEt, brand, engine)
        {
            this.fiscalPower = fiscalPower;
            this.nbDoors = nbDoors;
            this.nbSeats = nbSeats;
            this.sizeTrunk = sizeTrunk;
        }
        
        //calculate taxes
        public override decimal CalculateTaxes()
        {
            return fiscalPower*10;
        }
        
        //display
        public override void Display()
        {
            base.Display();
            Console.WriteLine("Fiscal power: {0}", fiscalPower);
            Console.WriteLine("Number of doors: {0}", nbDoors);
            Console.WriteLine("Number of seats: {0}", nbSeats);
            Console.WriteLine("Size of the trunck: {0}m3", sizeTrunk);
        }
    }
}