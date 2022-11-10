using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMissingJewelMystery_AssetCreator
{
    class Controller
    {
        ItemCreation item = new ItemCreation();
        ContainerCreation container = new ContainerCreation();
        LockedContainerCreation lockedContainer = new LockedContainerCreation();
        QuestionCreation question = new QuestionCreation();

        public void StartUp()
        {
            bool exitMenu = false;

            while(!exitMenu)
            {
                Title();
                exitMenu = CreateMenu();
            }
            
        }


            



        void Title()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("The Missing Jewel: Item Creation Program.");
            Console.ResetColor();
        }
        bool CreateMenu()
        {
            int playerInput = 0;

            Console.WriteLine();

            WriteInputPrompt(1, "Create Items");
            WriteInputPrompt(2, "Create Containers");
            WriteInputPrompt(3, "Create Containers(Locked)");
            WriteInputPrompt(4, "Create Questions");


            WriteInputPrompt(0, "Exit");


            try
            {
                playerInput = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (playerInput)
                {
                    case 0:
                        return true;
                        break;
                    case 1:
                        item.CreateItems();
                        break;
                    case 2:
                        container.CreateItems();
                        break;
                    case 3:
                        lockedContainer.CreateItems();
                        break;
                    case 4:
                        question.CreateQuestions();
                        break;
                    default:
                        InvalidInputWarning();
                        break;
                }
            }
            catch
            {
                Console.Clear();
                InvalidInputWarning();
            }

            return false;
        }



        
        void WriteInputPrompt(int requiredInput, string prompt)
        {
            Console.ForegroundColor= ConsoleColor.Red;
            Console.Write(requiredInput);
            Console.Write(") ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(prompt);
            Console.ResetColor();
        }
        void InvalidInputWarning()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("INVALID INPUT");
            Console.ResetColor();
        }
    }

}
