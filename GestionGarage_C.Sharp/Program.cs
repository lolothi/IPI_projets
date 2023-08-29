using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace GestionGarage
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //TP step 1 : creation test:
            
           /*Engine DV5R = new Engine("DV5R", 130, Engine.typeEngineEnum.diesel);
            Engine twinCam = new Engine("twinCam", 103, Engine.typeEngineEnum.essence);
            Engine EtechPlugIn160 = new Engine("EtechPlugIn160", 160, Engine.typeEngineEnum.hybrid);
            
            Option wheel = new Option("HeatedSteeringWheel", 150);
            Option seat = new Option("heatedSeat", 500);
            Option bigComfort = new Option("bigComfortSeat", 650);
            Option goldwheel = new Option("goldWheel", 2000);
            Option towbar = new Option("detachableTowbar", 605);
            Option sunroof = new Option("sunRoof", 480);
            
            Moto HarleyMoto = new Moto("HarleyDavidsonXA", 12500, Vehicle.BrandEnum.Ferrari, twinCam, 1340);
            Car limousine = new Car("limousineA8L", 65230, Vehicle.BrandEnum.Audi, DV5R, 310, 6, 6, 2);
            Car f458spider = new Car("F458Spider", 230000,Vehicle.BrandEnum.Ferrari, DV5R,500, 2, 2, 1);
            Truck ManTgs = new Truck("manTgs", 55000, Vehicle.BrandEnum.Citroen, EtechPlugIn160, 4, 44000, 100);
            
            HarleyMoto.AddOption(seat);
            HarleyMoto.AddOption(bigComfort);
            limousine.AddOption(towbar);
            limousine.AddOption(sunroof);
            limousine.AddOption(wheel);
            ManTgs.AddOption(bigComfort);
            f458spider.AddOption(goldwheel);
            f458spider.AddOption(sunroof);
            
            limousine.Display();
            ManTgs.Display();
            f458spider.Display();
            ManTgs.Display();

            Garage garageLolo = new Garage("garagelolo");
            garageLolo.AddVehicle(limousine);
            garageLolo.AddVehicle(f458spider);
            Garage garageBob = new Garage("garageBob");
            garageBob.AddVehicle(HarleyMoto);
            garageBob.AddVehicle(f458spider);
            garageBob.AddVehicle(limousine);
            garageBob.AddVehicle(ManTgs);
            garageLolo.Display();
            
            garageBob.SortVehicle();
            garageBob.Display();*/
            
           
            //TP step 2
            Garage garage2 = new Garage("garage");
            Menu menuGarage = new Menu(garage2);

            menuGarage.Start();

        }
        public static void Save(object toSave, string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream flux = null;
            try
            {
                flux = new FileStream(path, FileMode.Create, FileAccess.Write);
                formatter.Serialize(flux, toSave);
                flux.Flush();
                Console.WriteLine("*Message : Garage saved");
            }
            catch
            {
                Console.WriteLine("*Error Message : error with the garage saving");
            }
            finally
            {
                if (flux != null)
                    flux.Close();
                
            }
        }
                
        public static T Restore<T>(string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream flux = null;
            try
            {
                flux = new FileStream(path, FileMode.Open, FileAccess.Read);
                return (T)formatter.Deserialize(flux);

            }
            catch (Exception err)
            {
                Console.WriteLine("*Error Message : error with the garage restoring {0}", err);
                return default(T);
            }
            finally
            {
                if (flux != null)
                    flux.Close();
            }
        }
        
        


        
        
        
        
        
        
        
        
        
    }
}