/*
 Author: Robin Stenskytt
 Course: PRRPRR02
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hundregister
{
    class Program
    {
        //The list with doggos
        private List<Doggo> Doggos = new List<Doggo>();

        //Different run bools
        private bool doggoSearchRun;
        private bool miniRun;
        private bool gateKeeper;

        static void Main(string[] args)
        {
            Program p = new Program();
            p.MainRun();

        }

        #region Main program

        public bool MainRun()
        {
            //Couple of doggos which I've made
            Doggos.Add(new Labrador("GOBO", true, 18, 175, 160, 88));
            Doggos.Add(new Labrador("GOBO", false, 18, 175, 160, 88));
            Doggos.Add(new Weinerdog("MR.MAN", true, 80, 150, 120, 80));
            Doggos.Add(new Poodle("NYMPHO", false, 21, 168, 140, 75));
            Doggos.Add(new Labrador("ARCHAON", true, 1000, 2000, 1500, 1500));

            //Declaring variables
            miniRun = true;

            //Takes the option input
            Console.WriteLine("Starting screen, please enter a command.\nWrite \"Help\" to display all commands\"\n");

            while (miniRun)
            {
                InputManager("Main menu\n\n>> ", out string optionPick);
                Console.Clear();

                if (optionPick == "HELP")
                {
                    //Prints out all commands
                    Console.WriteLine("Help: Displays all commands\nAdd: Adds a new dog\nSearch: Searches for a dog to manage\nList: Prints out all dogs\nExit: Closes the program\n");
                    Console.WriteLine("Press ENTER to continue");
                    Console.ReadLine();
                }

                else if (optionPick == "ADD")
                {
                    //Adds a new doggo
                    Add();
                    Console.Clear();
                }

                else if (optionPick == "SEARCH")
                {
                    //Searches for a doggo
                    DoggoSearcher();
                    doggoSearchRun = true;
                    Console.Clear();
                }

                else if (optionPick == "LIST")
                {
                    //Prints all the doggos
                    PrintDoggoList();
                    Console.ReadLine();
                    Console.Clear();
                }

                else if (optionPick == "EXIT")
                {
                    //Exits the program
                    miniRun = false;
                }

                else
                {
                    Console.WriteLine("Invalid input\nWrite help to see all commands\n");
                }

            }
            return true;
        }

        #endregion

        #region Main program functions

        #region Add function

        protected void Add()
        {
            //Variable to keep my gatekeeper while loops going
            gateKeeper = true;
            miniRun = true;
            string race = "";

            while (gateKeeper)
            {
                InputManager("Please enter the race\n>> ", out string tempRace);
                Console.Clear();

                if (tempRace == "POODLE")
                {
                    gateKeeper = false;
                    race = "POODLE";
                    Console.Clear();
                }
                else if (tempRace == "LABRADOR")
                {
                    gateKeeper = false;
                    race = "LABRADOR";
                    Console.Clear();
                }
                else if (tempRace == "WEINERDOG" || tempRace == "DACHSHUND")
                {
                    gateKeeper = false;
                    race = "WEINERDOG";
                    Console.Clear();
                }
                else
                {
                    gateKeeper = true;
                    Console.WriteLine("\nThe options are \"Labrador\", \"Poodle\", and \"Weinerdog\"\n");
                }
            }

            InputManager("Please enter your dogs name\n>> ", out string name);
            Console.Clear();
            InputManager("Please enter the dogs gender\n>> ", out bool sex);
            Console.Clear();
            InputManager("Please enter its age\n>> ", out int age);
            Console.Clear();
            InputManager("Please enter the dogs length\n>> ", out int length);
            Console.Clear();
            InputManager("Please enter your dogs withers\n>> ", out int withers);
            Console.Clear();
            InputManager("Please enter its weight in decimals.\nExample \"18,43\"\n>> ", out double weight);
            Console.Clear();
            Doggo doggo;
            gateKeeper = true;

            while (gateKeeper)
            {
                if (race == "POODLE")
                {
                    doggo = new Poodle(name, sex, age, length, withers, weight);
                    //If there is no identical dog then it returns -1, and proceeds to add a new doggo
                    if (GetIndex(doggo) == -1)
                    {
                        Doggos.Add(doggo);
                    }

                    //Informs the user of the fact that an idendical dog already exists, and proceeds not to adda new doggo
                    else
                    {
                        Console.WriteLine("An identical dog already exists, and it isn't possible to add another identical dog");
                        Console.Write("Press ENTER to continue");
                        Console.ReadLine();
                    }
                    gateKeeper = false;
                    return;
                }

                else if (race == "LABRADOR")
                {
                    doggo = new Labrador(name, sex, age, length, withers, weight);
                    if (GetIndex(doggo) == -1)
                    {
                        Doggos.Add(doggo);
                    }
                    else
                    {
                        Console.WriteLine("An identical dog already exists, and it isn't possible to add another identical dog");
                        Console.Write("Press ENTER to continue");
                        Console.ReadLine();
                    }
                    gateKeeper = false;
                    return;
                }

                //Have already checked if the user gave the correct race input. So "else" works here
                else
                {
                    doggo = new Weinerdog(name, sex, age, length, withers, weight);
                    if (GetIndex(doggo) == -1)
                    {
                        Doggos.Add(doggo);
                    }
                    else
                    {
                        Console.WriteLine("An identical dog already exists, and it isn't possible to add another identical dog");
                        Console.Write("Press ENTER to continue");
                        Console.ReadLine();
                    }
                    gateKeeper = false;
                    return;
                }
            }

        }

        #endregion

        #region Doggo List Print

        private void PrintDoggoList()
        {
            Doggos.Sort();
            foreach (Doggo doggo in Doggos)
            {
                doggo.PrintDoggo();
                Console.Write("\n");
            }
        }

        #endregion

        #region Doggo management

        private void DoggoSearcher()
        {
            #region The search function

            //Declaring variables
            int dogIndex = 0;
            doggoSearchRun = true;

            List<Doggo> searchDoggos = new List<Doggo>();

            //Gets the dogs name
            InputManager("Search for your doggos name.\n>> ", out string name);
            foreach (Doggo Doggo in Doggos)
            {
                //If a doggo has the same name as the user searched for, then it is added to the list
                if (Doggo.Name == name)
                {
                    searchDoggos.Add(Doggo);
                }
            }
            //Checks how many dogs with that name exists in the list
            //If there was one doggo
            if (searchDoggos.Count == 1)
            {
                //If there was a single doggo whom had that name then the program gets the index of that doggo
                dogIndex = GetIndex(searchDoggos[0]);
                Doggos[dogIndex].PrintDoggo();
            }
            //If there was zero doggos
            if (searchDoggos.Count == 0)
            {
                Console.WriteLine("The dog doesn't exist");
                Console.ReadLine();
                return;
            }
            //If there were more than one doggo
            if (searchDoggos.Count > 1)
            {
                Console.Clear();
                Console.WriteLine("There are multiple doggos who share that name.");
                InputManager("How old is your doggo?\n>> ", out int age);
                //Checks every single doggo in the searchDoggos list age, through the doggo list
                for (int i = 0; i < searchDoggos.Count; i++)
                {
                    //If the doggos age doesnt match the user input, then that doggo is removed from the searchDoggos list
                    if (searchDoggos[i].Age != age)
                    {
                        searchDoggos.RemoveAt(i);
                    }
                }
                //Here it once again checks how many doggos are left in the search doggo list.
                //It then repeats this until all doggo variables have been checked and finds one unique doggo.
                if (searchDoggos.Count == 1)
                {
                    dogIndex = GetIndex(searchDoggos[0]);
                    Doggos[dogIndex].PrintDoggo();
                }
                if (searchDoggos.Count == 0)
                {
                    Console.WriteLine("The dog doesn't exist");
                    Console.ReadLine();
                    return;
                }
                if (searchDoggos.Count > 1)
                {
                    Console.Clear();
                    Console.WriteLine("There are multiple doggos who share that age.");
                    InputManager("What length is your doggo? The answer is in cm\n>> ", out int length);
                    for (int i = 0; i < searchDoggos.Count; i++)
                    {
                        if (searchDoggos[i].Length != length)
                        {
                            searchDoggos.RemoveAt(i);
                        }
                    }
                    if (searchDoggos.Count == 1)
                    {
                        dogIndex = GetIndex(searchDoggos[0]);
                        Doggos[dogIndex].PrintDoggo();
                    }
                    if (searchDoggos.Count == 0)
                    {
                        Console.WriteLine("The dog doesn't exist");
                        Console.ReadLine();
                        return;
                    }
                    if (searchDoggos.Count > 1)
                    {
                        Console.Clear();
                        Console.WriteLine("There are multiple doggos who share that length, how odd.");
                        InputManager("How tall is your doggos withers? The answer is in cm\n>> ", out int withers);
                        for (int i = 0; i < searchDoggos.Count; i++)
                        {
                            if (searchDoggos[i].Withers != withers)
                            {
                                searchDoggos.RemoveAt(i);
                            }
                        }
                        if (searchDoggos.Count == 1)
                        {
                            dogIndex = GetIndex(searchDoggos[0]);
                            Doggos[dogIndex].PrintDoggo();
                        }
                        if (searchDoggos.Count == 0)
                        {
                            Console.WriteLine("The dog doesn't exist");
                            Console.ReadLine();
                            return;
                        }
                        if (searchDoggos.Count > 1)
                        {
                            Console.Clear();
                            Console.WriteLine("There are multiple doggos who share the same withers height. This is starting to look sketchy");
                            InputManager("How much does your doggo weigh? The answer is provided in Kgs\n>> ", out int weight);
                            for (int i = 0; i < searchDoggos.Count; i++)
                            {
                                if (searchDoggos[i].Weight != weight)
                                {
                                    searchDoggos.RemoveAt(i);
                                }
                            }
                            if (searchDoggos.Count == 1)
                            {
                                dogIndex = GetIndex(searchDoggos[0]);
                                Doggos[dogIndex].PrintDoggo();
                            }
                            if (searchDoggos.Count == 0)
                            {
                                Console.WriteLine("The dog doesn't exist");
                                Console.ReadLine();
                                return;
                            }
                            if (searchDoggos.Count > 1)
                            {
                                Console.Clear();
                                Console.WriteLine("There are a number of dogs who even share that weight.\nIts time to stop adding such a ridiculous amount of identical doggos\nOr are you doubting my program?");
                                InputManager("Now finally, what sex is your doggo? There can only be one of each sex left. So you've only bamboozled yourself\n>> ", out bool sex);
                                for (int i = 0; i < searchDoggos.Count; i++)
                                {
                                    if (searchDoggos[i].Sex != sex)
                                    {
                                        searchDoggos.RemoveAt(i);
                                    }
                                }
                                if (searchDoggos.Count == 1)
                                {
                                    dogIndex = GetIndex(searchDoggos[0]);
                                    Doggos[dogIndex].PrintDoggo();
                                }
                            }
                        }
                    }
                }
            }
            #endregion


            while (doggoSearchRun)
            {

                InputManager("\nHow do you want to manage your dog?\n Write \"Help\" to display all commands\n>> ", out string choice);
                Console.Clear();
                if (choice == "HELP")
                {
                    Console.WriteLine("Help: Displays all commands\nEdit: Edits a value of your dog\nReturn: Returns to the main menu\nRemove: Removes a dog");
                }
                else if (choice == "EDIT")
                {

                    #region EDIT FUNCTION

                    foreach (Doggo doggo in Doggos)
                    {
                        //Takes the selected doggos index
                        if (Doggos[dogIndex] == doggo)
                        {
                            InputManager("What about your doggo has changed?\n>> ", out string input);

                            if (input == "NAME")
                            {
                                InputManager("What has your doggo been renamed to?\n>> ", out string newName);
                                Doggos[GetIndex(doggo)].Name = newName;
                            }
                            if (input == "AGE")
                            {
                                InputManager("How old is your doggo now?\n>> ", out int newAge);
                                Doggos[GetIndex(doggo)].Age = newAge;
                            }
                            if (input == "LENGTH")
                            {
                                InputManager("How long is your doggo now?\n>> ", out int newLength);
                                Doggos[GetIndex(doggo)].Length = newLength;
                            }
                            if (input == "WITHERS")
                            {
                                InputManager("How tall is your doggos withers now?\n>> ", out int newWithers);
                                Doggos[GetIndex(doggo)].Withers = newWithers;
                            }
                            if (input == "WEIGHT")
                            {
                                InputManager("How much does your doggo weigh now?\n>> ", out int newWeight);
                                Doggos[GetIndex(doggo)].Weight = newWeight;
                            }
                            if (input == "SEX")
                            {
                                InputManager("Wait, what?? Your doggo changed sex?? How the fu..\nNonetheless, what sex is your doggo now?\n>> ", out bool newSex);
                                Doggos[GetIndex(doggo)].Sex = newSex;
                            }
                        }
                    }
                    #endregion

                }
                else if (choice == "REMOVE")
                {

                    #region REMOVE FUNCTION

                    foreach (Doggo Doggo in Doggos)
                    {
                        //Removes the selected dog
                        if (Doggos[dogIndex] == Doggo)
                        {
                            Doggos.RemoveAt(GetIndex(Doggo));
                            Console.WriteLine("Dog successfully removed!\nPress enter to continue.");
                            Console.ReadLine();
                            return;
                        }
                    }

                    #endregion

                }
                else if (choice == "RETURN")
                {
                    doggoSearchRun = false;
                }
                else
                {
                    doggoSearchRun = true; ;
                }
            }
        }

        #endregion

        #endregion

        #region Input bois
        //Input managers, takes input as a string and converts to the desired variable type
        //Also provides an error message if you give it the wrong type of input


        //This boi outputs the input as a string
        private void InputManager(string message, out string input)
        {
            Console.Write(message);
            input = Console.ReadLine().ToUpper();
        }


        //This boi outputs the input as a bool while letting the user answer with a string
        private bool InputManager(string message, out bool input)
        {
            while (true)
            {
                try
                {
                    Console.Write(message);

                    //String variable that lets the user give a string input, instead of "true" or "false"
                    string answer = (Console.ReadLine().ToUpper());

                    if (answer == "MALE" || answer == "BOY" || answer == "LAD")
                    {
                        input = true;
                    }
                    else if (answer == "FEMALE" || answer == "GIRL" || answer == "LASS")
                    {
                        input = false;
                    }
                    else
                    {
                        input = bool.Parse(answer);
                    }
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Please enter Male or Female\n", e.GetType().Name);
                }

            }
        }


        //This boi outputs the input as an integer
        private bool InputManager(string message, out int input)
        {
            while (true)
            {
                try
                {
                    Console.Write(message);
                    input = int.Parse(Console.ReadLine());
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Please enter an integer\n", e.GetType().Name);
                }

            }
        }


        //This boi outputs the input as a double
        private bool InputManager(string message, out double input)
        {
            while (true)
            {
                try
                {
                    Console.Write(message);
                    input = double.Parse(Console.ReadLine());
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Enter a number, and write \",\" if you want to add decimals", e.GetType().Name);
                }

            }
        }


        #endregion

        #region Index yoink
        //Gets the index of a specific dog
        private int GetIndex(Doggo Doggo)
        {
            for (int i = 0; i < Doggos.Count; i++)
            {
                if (Doggos[i].Equals(Doggo))
                {
                    return i;
                }
            }
            //Index value -1 if the dog wasnt found
            return -1;
        }

        #endregion


    }


}