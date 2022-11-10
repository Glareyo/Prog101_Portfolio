using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Security.Cryptography;

namespace TheMissingJewelMystery_GeneralItemNamingTool
{
    class NamingController
    {
        string addOnName;
        List<string> targetNames;
        List<string> modifiedNames;

        string directoryFile = Directory.GetCurrentDirectory();
        string targetFolder = "ModifiedNames.txt";


        public void Startup()
        {
            Process.Start(GetDirectory());

            while (true)
            {

                //Player inputs an  AddOnName
                addOnName = GetAddOnName();

                //Player then inputs a list of names
                targetNames = GetTargetNames();

                //Take the list of names and add the AddOnName to the beginning of each name.
                Menu();

                //Create a textFile With those names on it.
                CreateText();

                Console.Clear();
            }
            

        }
        string GetAddOnName()
        {
            string playerInput;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Please input the AddOnName you want to add on: ");
            Console.ForegroundColor= ConsoleColor.Red;
            playerInput = Console.ReadLine();

            Console.ResetColor();
            Console.Clear();
            return playerInput;
        }

        void Menu()
        {
            int currentSelection = 1;
            bool running = true;
            string keyPressed;

            string enterKeyString = ConsoleKey.Enter.ToString();
            string upArrowString = ConsoleKey.UpArrow.ToString();
            string downArrowString = ConsoleKey.DownArrow.ToString();


            string[] options = { " 1) Before", " 2) After" };

            while (running)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Do you wanted added on before or after?: ");


                for (int i = 0; i < options.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (currentSelection == i)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                    }
                    Console.WriteLine(options[i]);
                    Console.ResetColor();
                }


                keyPressed = Console.ReadKey().Key.ToString();
                Console.Clear();


                if (keyPressed == upArrowString)
                {
                    currentSelection--; //Going up
                    if (currentSelection < 0) currentSelection = options.Length - 1;
                }
                else if (keyPressed == downArrowString)
                {
                    currentSelection++; //Going up
                    if (currentSelection >= options.Length) currentSelection = 0;
                }
                else if (keyPressed == enterKeyString)
                {
                    running = false;
                }
            }


            modifiedNames = CreateName(addOnName, targetNames, currentSelection);




        }



        List<string> GetTargetNames()
        {
            string playerInput;
            bool exit = false;
            List<string> names = new List<string>();



            string[] InfoFiles = File.ReadAllLines(directoryFile);



            foreach (string text in InfoFiles)
                names.Add(text);


            return names;

        }
        List<string> CreateName(string _addOnName, List<string> _targetNames, int optionSelected)
        {
            List<string> newNames = new List<string>();


            foreach (string name in _targetNames)
            {
                if (optionSelected == 0) newNames.Add(_addOnName + name); //Before Selected.
                else newNames.Add(name + _addOnName); //After Selected
            }

            return newNames;
        }
        string GetDirectory()
        {
            return directoryFile = Path.Combine(directoryFile, targetFolder);
        }
        void CreateText()
        {
            File.WriteAllLines(directoryFile, modifiedNames);


            //Utilizing https://stackoverflow.com/questions/4055266/open-a-file-with-notepad-in-c-sharp
            Process.Start(directoryFile);
        }




    }
}
