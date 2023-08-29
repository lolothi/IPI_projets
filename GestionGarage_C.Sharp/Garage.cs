using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using GestionGarage.Properties;
using System.Runtime.Serialization.Formatters.Binary;


namespace GestionGarage
{
    [Serializable]
    public class Garage
    {
        //Array list for sorting vehicles
        
        public ArrayList vehicles = new ArrayList();
        public ArrayList selectedVehicule = new ArrayList();
        
        //engines list
        public List<Engine> engines = new List<Engine>();

        //options list
        public List<Option> options = new List<Option>();
        //public List<Option> options = Restore<List<Option>>("garageData.bin");
        

        private Vehicle vehicule { get; }
        
        //name of the garage
        protected string name;
        
        public string Name
        {
            get => name;
            set => name = value;
        }
        
        //constructor
        public Garage(string name)
        {
            this.name = name;
        }
        
        //Add vehicle in the garage
        public void AddVehicle(Vehicle vehicle)
        {
            vehicles.Add(vehicle);
        }

        //Delete a vehicule from the garage
        public void DelVehicule(int carIndex)
        {
            foreach (Vehicle oneVehicle in vehicles)
            {
                if (oneVehicle.Id == carIndex)
                {
                    vehicles.Remove(oneVehicle);
                    
                    foreach (Vehicle oneSelectVehicle in selectedVehicule)
                    {
                        if (oneVehicle.Id == oneSelectVehicle.Id)
                        {
                            selectedVehicule.Remove(oneSelectVehicle);
                        }
                    }
                }

                
            }  
        }
        
        //vehicle selected by the user in the menu
        public void SelectedVehicule(int vehId)
        {
            foreach (Vehicle oneVehicle in vehicles)
            {
                if (oneVehicle.Id == vehId)
                {
                    selectedVehicule.Add(oneVehicle);
                }
            }
        }

        //Remove the selected vehicle
        public void DelSelectedVehicle(int vehId)
        {
            foreach (Vehicle oneVehicle in selectedVehicule)
            {
                if (oneVehicle.Id == vehId)
                {
                    selectedVehicule.Remove(oneVehicle);
                }
            }
        }
        
        //display selected vehicle
        public string DisplaySelectedVehicle()
        {
            if (selectedVehicule.Count > 0)
            {
                foreach (Vehicle vehicle in selectedVehicule)
                {
                    return vehicle.Id + "." + vehicle.Name;
                }
            }
            return "";
        }
        
        //display all garage information
        public void Display()
        {
            if (vehicles.Count > 0)
            {
                Console.Write("------ Information of the garage {0} ------\n", name);
                foreach (Vehicle vehicle in vehicles)
                {
                    Console.WriteLine("Vehicle Id.{0}: {1} {2}€", vehicle.Id, vehicle.Name, vehicle.FinalPrice());
                }
            }
            else
            {
               Console.Write("*Message: Garage empty \n"); 
            }
            
        }
        
        //display cars
        public void DisplayCars()
        {
            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicle is Car)
                {
                    vehicle.Display();
                }
            }
        }
        //display trucks
        public void DisplayTrucks()
        {
            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicle is Truck)
                {
                    vehicle.Display();
                }
            }
        }

        //display motos
        public void DisplayMotos()
        {
            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicle is Moto)
                {
                    vehicle.Display();
                }
            }
        }

        //sort vehicles
        public void SortVehicle()
        {
            vehicles.Sort();
        }
        
        //AddEngine in garage list
        public void AddEngine(Engine engine)
        {
            engines.Add(engine);
        }

        //AddOption in garage list
        public void AddOption(Option option)
        {
            options.Add(option);
        }

        //display garage options
        public void DisplayOptions(Option option)
        {
            Console.Write("------ Options in the garage ------\n");
            if (options.Count > 0)
            {
                foreach (Option oneOption in options)
                {
                    Console.WriteLine("Option id.{0}: {1} {2}$", oneOption.Id, oneOption.Name, oneOption.Price);
                }
            }
            else
            {
                Console.Write("*Message: No option in the garage \n");
            }
            
        }

        //display type engine from engine in the garage
        public void DisplayEngines(Engine engine)
        {
            Console.Write("------ Engines in the garage ------\n");
            if (engines.Count > 0)
            {
                
                foreach (Engine oneEngine in engines)
                {
                    oneEngine.Display();
                }
                Console.WriteLine("\n");
            }
            else
            {
                Console.Write("*Message: No engine in the garage \n");
            }
            
        }
        
        public void DisplayBrand(Vehicle vehicle)
        {
            foreach (Vehicle oneVehicle in vehicles)
            {
                Console.WriteLine("- {0}", oneVehicle.Brand);
            }
        }
        
        
        /*
        public void RestoreGarage()
        {
            engines.Clear();
            engines = Restore<List<Engine>>("garageData.bin");
            options.Clear();
            options = Restore<List<Option>>("garageData.bin");
            
        }
        */

        
    }

}