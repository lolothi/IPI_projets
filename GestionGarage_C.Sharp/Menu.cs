using System;
using GestionGarage.Properties;

namespace GestionGarage
{
    //Exception for choice menu, out of the range of choices
    public class MenuException : Exception
    {
    }
    
    //Exception for choice menu, out of the existing ID choices
    public class MenuIdException : Exception
    {
    }
    public class Menu
    {
        private Garage garage;
        public Garage Garage{ get=>garage; set=>garage=value; }

        private Vehicle vehicle;
        public Vehicle Vehicle { get=>vehicle;}
        
        private Option option;
        public Option Option { get=>option; }
        
        private Engine engine;
        public Engine Engine { get=>engine; }

        private int _selectedVehicleId;

        private string _messageForUser = "";
        
        //constructor
        public Menu(Garage garage)
        {
            this.garage = garage;
        }

        //Start with the First menu
        public void Start()
        {

            int choiceMenu = 0;

            while (choiceMenu != 13)
            {
                DisplayMenu();
                try 
                {
                    const int choiceMax = 13;
                    choiceMenu = GetChoice(choiceMax);

                    switch (choiceMenu)
                    {
                        case 1:
                            DisplayVehicles();
                            break;
                        case 2:
                            AddVehicle();
                            break;
                        case 3:
                            DelVehicle();
                            break;
                        case 4:
                            garage.DelSelectedVehicle(_selectedVehicleId);
                            _selectedVehicleId = 0;
                            SelectVehicle();
                            break;
                        case 5:
                            DisplayVehicleOptions();
                            break;
                        case 6:
                            AddOptionVehicle();
                            break;
                        case 7:
                            DelOptionVehicle();
                            break;
                        case 8:
                            DisplayOptions();
                            break;
                        case 9:
                            DisplayBrands();
                            break;
                        case 10:
                            DisplayEngineType();
                            break;
                        case 11:
                            garage.DelSelectedVehicle(_selectedVehicleId);
                            _selectedVehicleId = 0;
                            RestoreGarage();
                            break;
                        case 12:
                            SaveGarage();
                            break;
                        case 13:
                            QuitApp();
                            break;
                    }
                }
                catch (Exception e)
                {
                    if (e is FormatException)
                    {
                        _messageForUser = "*Error message: The choice is not a number";
                    } 
                    else if (e is MenuException)
                    {
                        _messageForUser = "*Error message: Wrong choice. The choice should be between 1 and 13";
                    }
                    else if (e is MenuIdException)
                    {
                        _messageForUser = "*Error message: Wrong Id choice. The choice should be in the list";
                    } 
                    else
                    {
                        Console.WriteLine("");
                    }
                }
            }
        }

        //Menu : choice number and Check if FormatException
        public int GetChoice(int choiceMax)
        {
            try
            {
                if (_messageForUser != "")
                {
                    Console.WriteLine(_messageForUser);
                }
                Console.Write(">>> Your choice : ");
                string choiceUserStr = Console.ReadLine();
                int choiceUser = Convert.ToInt32(choiceUserStr);
                
                return GetChoiceMenu(choiceUser, choiceMax);
            }
            catch (FormatException)
            {
                throw new FormatException();
            }
        }
        
        //choice Menu with exception on menu numbers
        public static int GetChoiceMenu(int choiceUser, int choiceMax)
        {
            if (choiceMax != 0)
            {
                if (choiceUser < 1 || choiceUser > choiceMax)
                {
                    throw new MenuException();
                }
                return choiceUser;
            }
            return choiceUser;
        }

        // Menu
        public void DisplayMenu()
        {
            Console.WriteLine("\n");
            Console.WriteLine("************ Menu ************");
            Console.WriteLine("1. Display the vehicles");
            Console.WriteLine("2. Add a vehicle");
            Console.WriteLine("3. Remove a vehicle");
            if (garage.DisplaySelectedVehicle().Length > 0)
            {
                Console.WriteLine("4. Deselect the vehicle: <Selected vehicle {0}>", Garage.DisplaySelectedVehicle());
            }
            else
            {
                Console.WriteLine("4. Select a vehicle");
            }
            Console.WriteLine("5. Display the options of a vehicle");
            Console.WriteLine("6. Add option to a vehicle");
            Console.WriteLine("7. Remove option to a vehicle");
            Console.WriteLine("8. Add/Display options");
            Console.WriteLine("9. Display brands");
            Console.WriteLine("10. Add/Display type engine");
            Console.WriteLine("11. Restore the garage");
            Console.WriteLine("12. Save the garage");
            Console.WriteLine("13. -> Quit\n");
        }
        
        //Menu choice 1 : show all the vehicles in the garage
        public void DisplayVehicles()
        {
            if (garage.vehicles.Count > 0)
            {
                _messageForUser = "";
                garage.Display();
            }
            else
            {
                _messageForUser = "*Message: Garage empty";
            }
        }
        
        //Menu choice 2 : add a vehicle in the garage
        public void AddVehicle()
        {
            _messageForUser = "";
            Engine dv5R = new Engine("dv5R", 130, Engine.typeEngineEnum.diesel);
            Engine twinCam = new Engine("twinCam", 103, Engine.typeEngineEnum.essence);
            Engine etechPlugIn160 = new Engine("etechPlugIn160", 160, Engine.typeEngineEnum.hybrid);
            
            Moto harleyMoto = new Moto("HarleyDavidsonXA", 12500, Vehicle.BrandEnum.Ferrari, twinCam, 1340);
            Car limousine = new Car("limousineA8L", 65230, Vehicle.BrandEnum.Audi, dv5R, 310, 6, 6, 2);
            Car f458Spider = new Car("f458Spider", 230000,Vehicle.BrandEnum.Ferrari, dv5R,500, 2, 2, 1);
            Truck manTgs = new Truck("manTgs", 55000, Vehicle.BrandEnum.Citroen, etechPlugIn160, 4, 44000, 100);
            
            limousine.Display();
            manTgs.Display();
            f458Spider.Display();
            manTgs.Display();
            
            Console.WriteLine("\n");
            Console.WriteLine(">>> Which vehicle do you want to add?");
            Console.WriteLine("1.HarleyDavidsonXA\n2.limousineA8L\n3.f458Spider\n4.manTgs\n5. -> Quit\n");
            
            try
            {
                const int choiceMax = 5;
                int userVehicleChoice = GetChoice(choiceMax);

                switch (userVehicleChoice)
                {
                    case 1:
                        garage.AddVehicle(harleyMoto);
                        break;
                    case 2:
                        garage.AddVehicle(limousine);
                        break;
                    case 3:
                        garage.AddVehicle(f458Spider);
                        break;
                    case 4:
                        garage.AddVehicle(manTgs);
                        break;
                    case 5:
                        DisplayMenu();
                        break;
                }

            }
            catch (Exception e)
            {
                if (e is FormatException)
                {
                    Console.WriteLine(e.Message);
                } 
                else if (e is MenuException)
                {
                    _messageForUser = "*Error message: Wrong choice. The choice should be between 1 and 4";
                }
                else
                {
                    Console.WriteLine("");
                }
            }
        }

        //Menu choice 3 : remove a vehicle from a garage
        public void DelVehicle()
        {
            if (garage.vehicles.Count > 0)
            {
                _messageForUser = "";
                garage.Display();
                Console.WriteLine(">>> Which vehicle do you want to remove? (Vehicle Id)");
                
                const int choiceMax = 0;
                int userGarageVehicleChoice = GetChoice(choiceMax);
                
                //Check with MenuIdException
                Boolean vehicleExists = false;
                foreach (Vehicle oneVehicle in garage.vehicles)
                {
                    if (oneVehicle.Id == userGarageVehicleChoice)
                    {
                        vehicleExists = true;
                    }
                }
                if (vehicleExists == false)
                {
                    throw new MenuIdException();
                }
                
                garage.DelVehicule(userGarageVehicleChoice);
            }
            else
            {
                _messageForUser = "*Message: Garage empty";
            }
        }

        //Menu choice 4 : select a vehicle from the garage
        public void SelectVehicle()
        {
            
            if (garage.vehicles.Count > 0)
            {
                _messageForUser = "";
                garage.Display();
                Console.WriteLine(">>> Which vehicle do you want to select? (Vehicle Id)");
                
                const int choiceMax = 0;
                int userGarageVehicleChoice = GetChoice(choiceMax);
                
                //Check with MenuIdException
                Boolean vehicleExists = false;
                foreach (Vehicle oneVehicle in garage.vehicles)
                {
                    if (oneVehicle.Id == userGarageVehicleChoice)
                    {
                        vehicleExists = true;
                    }
                }
                if (vehicleExists == false)
                {
                    throw new MenuIdException();
                }
                
                garage.SelectedVehicule(userGarageVehicleChoice);
                _selectedVehicleId = userGarageVehicleChoice;

            }
            else
            {
                _messageForUser = "*Message: Garage empty";
            }

        }

        //Menu choice 5 : show all the vehicle option
        public void DisplayVehicleOptions()
        {
          
            if (garage.DisplaySelectedVehicle().Length > 0)
            {
                _messageForUser = "";
                foreach (Vehicle oneVehicle in garage.vehicles)
                {
                    if (oneVehicle.Id == _selectedVehicleId)
                    {
                        oneVehicle.DisplayOptions();
                    }
                }
            }
            else
            {
                _messageForUser = "*Message: need to select a vehicle";
            }
        }

        //Menu choice 6 : add option to a vehicle
        public void AddOptionVehicle()
        {
            if (garage.DisplaySelectedVehicle().Length > 0)
            {
                _messageForUser = "";

                if (garage.options.Count > 0)
                {
                    garage.DisplayOptions(option);
                    Console.WriteLine(">>> Which option do you want to add? (Option Id)");
                    const int choiceMax = 0;
                    int userVehicleOption = GetChoice(choiceMax);
    
                    foreach (Vehicle oneVehicle in garage.vehicles)
                    {
                        if (oneVehicle.Id == _selectedVehicleId)
                        {
                            foreach (Option oneOption in garage.options)
                            {
                                if (oneOption.Id == userVehicleOption)
                                {
                                    oneVehicle.AddOption(oneOption);
                                }
                            }
                        }
                    }
                }
                else
                {
                    _messageForUser = "*Message: no option in the garage. Need to add option";
                }

                
            }
            else
            {
                _messageForUser = "*Message: need to select a vehicle";
            }
        }

        //Menu choice 7 : remove option from vehicle
        public void DelOptionVehicle()
        {
            if (garage.DisplaySelectedVehicle().Length > 0)
            {
                _messageForUser = "";
                foreach (Vehicle oneVehicle in garage.selectedVehicule)
                {
                    if (oneVehicle.Id == _selectedVehicleId)
                    {
                        oneVehicle.DisplayOptions();
                        Console.WriteLine(">>> Which option do you want to remove? (Option Id)");
                        int choiceMax = 0;
                        int userVehicleOptionChoice = GetChoice(choiceMax);
                        
                        foreach (Option oneOption in oneVehicle.options)
                        {
                            if (oneOption.Id == userVehicleOptionChoice)
                            {
                                oneVehicle.DelOption(oneOption);
                            }
                        }
                    }
                }
            }
            else
            {
                _messageForUser = "*Message: need to select a vehicle";
            }
        }

        //Menu choice 8 : Add or display the options from the garage
        public void DisplayOptions()
        {
            _messageForUser = "";
            garage.DisplayOptions(option);
            Option wheel = new Option("HeatedSteeringWheel", 150);
            Option seat = new Option("heatedSeat", 500);
            Option bigComfort = new Option("bigComfortSeat", 650);
            Option goldwheel = new Option("goldWheel", 2000);
            Option towbar = new Option("detachableTowbar", 605);
            Option sunroof = new Option("sunRoof", 480);
            
            Console.WriteLine("---- Option available ---");
            Console.WriteLine("1. {0} {1}€", wheel.Name, wheel.Price);
            Console.WriteLine("2. {0} {1}€", seat.Name, seat.Price);
            Console.WriteLine("3. {0} {1}€", bigComfort.Name, bigComfort.Price);
            Console.WriteLine("4. {0} {1}€", goldwheel.Name, goldwheel.Price);
            Console.WriteLine("5. {0} {1}€", towbar.Name, towbar.Price);
            Console.WriteLine("6. {0} {1}€", sunroof.Name, sunroof.Price);
            Console.WriteLine("7. -> Quit");
       
            Console.WriteLine("\n");
            Console.WriteLine(">>> Which option do you want to add?");
            
            try
            {
                const int choiceMax = 7;
                int userEngineChoice = GetChoice(choiceMax);

                switch (userEngineChoice)
                {
                    case 1:
                        garage.AddOption(wheel);
                        break;
                    case 2:
                        garage.AddOption(seat);
                        break;
                    case 3:
                        garage.AddOption(bigComfort);
                        break;
                    case 4:
                        garage.AddOption(goldwheel);
                        break;
                    case 5:
                        garage.AddOption(towbar);
                        break;
                    case 6:
                        garage.AddOption(sunroof);
                        break;
                    case 7:
                        DisplayMenu();
                        break;
                }
            }
            catch (Exception e)
            {
                if (e is FormatException)
                {
                    Console.WriteLine(e.Message);
                } 
                else if (e is MenuException)
                {
                    _messageForUser = "*Error message: Wrong choice. The choice should be between 1 and 6";
                }
                else
                {
                    Console.WriteLine("");
                }
            }
        }

        //Menu choice 9
        public void DisplayBrands()
        {
            if (garage.vehicles.Count > 0)
            {
                _messageForUser = "";
                Console.WriteLine("**** Vehicle Brands in the garage ***");
                garage.DisplayBrand(vehicle);
            }
            else
            {
                _messageForUser = "*Message: Garage empty";
            }
        }

        //Menu choice 10 : add or display the engine from the garage
        public void DisplayEngineType()
        {
            _messageForUser = "";
            garage.DisplayEngines(Engine);
            Engine dv5R = new Engine("dv5R", 130, Engine.typeEngineEnum.diesel);
            Engine twinCam = new Engine("twinCam", 103, Engine.typeEngineEnum.essence);
            Engine etechPlugIn160 = new Engine("etechPlugIn160", 160, Engine.typeEngineEnum.hybrid);
            
            Console.WriteLine("---- Engine available ---");
            Console.WriteLine("1. {0} Power:{1}ch type:{2}", dv5R.Name, dv5R.Power, dv5R.TypeEngine);
            Console.WriteLine("2. {0} Power:{1}ch type:{2}", twinCam.Name, twinCam.Power, twinCam.TypeEngine);
            Console.WriteLine("3. {0} Power:{1}ch type:{2}", etechPlugIn160.Name, etechPlugIn160.Power, etechPlugIn160.TypeEngine);
            Console.WriteLine("4. -> Quit\n");
            
            Console.WriteLine("\n");
            Console.WriteLine(">>> Which engine do you want to add?");

            try
            {
                const int choiceMax = 4;
                int userEngineChoice = GetChoice(choiceMax);

                switch (userEngineChoice)
                {
                    case 1:
                        garage.AddEngine(dv5R);
                        break;
                    case 2:
                        garage.AddEngine(twinCam);
                        break;
                    case 3:
                        garage.AddEngine(etechPlugIn160);
                        break;
                    case 4:
                        DisplayMenu();
                        break;
                }
            }
            catch (Exception e)
            {
                if (e is FormatException)
                {
                    Console.WriteLine(e.Message);
                } 
                else if (e is MenuException)
                {
                    _messageForUser = "*Error message: Wrong choice. The choice should be between 1 and 3";
                }
                else
                {
                    Console.WriteLine("");
                }
            }
            
        }

        //Menu choice 11 : restore a saved garage
        public void RestoreGarage()
        {
            _messageForUser = "";
            garage = Program.Restore<Garage>("garageData.bin");
        }

        //Menu choice 12 : save the parameters of the garage
        public void SaveGarage()
        {
            _messageForUser = "";
            Program.Save(garage, "garageData.bin");
        }

        //Menu choice 13 : leave the application
        public void QuitApp()
        {
        }
        
        
        
    }
    
    
}