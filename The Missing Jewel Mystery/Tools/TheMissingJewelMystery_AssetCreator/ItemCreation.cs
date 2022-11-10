using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TheMissingJewelMystery_AssetCreator
{
    class ItemCreation
    {
        public void CreateItems()
        {
            const string FOLDER = "All_Items";



            Console.WriteLine("Items Creation Menu.");
            



            List<string> itemID = new List<string>();
            List<string> name = new List<string>();
            List<string> description = new List<string>();
            List<string> interactDescription = new List<string>();
            List<string> clueSummary = new List<string>();
            List<string> Room_ID = new List<string>();
            List<string> currentState = new List<string>();
            List<string> size = new List<string>();
            List<string> canPickUp = new List<string>();


            addToList_addLine(itemID, "ItemID", "ItemID");

            
            addToList(name, "Name");
            addToList(description, "Description");
            addToList(interactDescription, "Interact Description");
            addToList(clueSummary, "Clue Summary");
            addToList(Room_ID, "Room ID");
            addToList(currentState, "CurrentState");
            addToList(size, "Size");
            addToList(canPickUp, "Can Pick Up Bool");






            for (int i = 0; i < itemID.Count; i++)
            {
                string holdingFolder = Path.Combine(Directory.GetCurrentDirectory(), FOLDER);
                string entireFormating = $@"-ITEM-ID
{itemID[i]}
-----------------------------------------------------------------------------------
-NAME: 
{name[i]}
-----------------------------------------------------------------------------------
-DESCRIPTION:
{description[i]}
-----------------------------------------------------------------------------------
-INTERACT_DESCRIPTION: 
{interactDescription[i]}
-----------------------------------------------------------------------------------
-CLUE-SUMMARY
{clueSummary[i]}
-----------------------------------------------------------------------------------
-ROOM_ID: 
{Room_ID[i]}
-----------------------------------------------------------------------------------
-CURRENT_STATE:
{currentState[i]}
-----------------------------------------------------------------------------------
-Size (1-5) (Small-Large)
{size[i]}
-----------------------------------------------------------------------------------
-CAN_PICK_UP: 
{canPickUp[i]}
-----------------------------------------------------------------------------------
-Container Prompts
-----------------------------------------------------------------------------------
-IS_CONTAINER
False
-----------------------------------------------------------------------------------
-IS_LOCKED
False
-----------------------------------------------------------------------------------
-UNLOCKING_DESCRIPTION
 
-----------------------------------------------------------------------------------
-KEY_ITEM_ID(If locked):
 
-----------------------------------------------------------------------------------
-CONTAINED_ITEM_IDS (List of items)
 ";

                File.WriteAllText(Path.Combine(holdingFolder, $"{itemID[i]}.txt"), entireFormating);
                
            }

            ConfirmedCreation();




            void ConfirmedCreation()
            {
                Console.Clear();
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Magenta;

                Console.WriteLine($"Creating Items....Please check {FOLDER} for text files.");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Press \"Enter\" to continue...");
                Console.ReadLine();

                Console.Clear();

            }



            void addToList(List<string> targetList, string targetPrompt)
            {
                bool exitMenu = false;
                string playerInput = "";

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Copy and paste the column of the {targetPrompt}: ");
                while (!exitMenu)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    playerInput = Console.ReadLine();
                    if (playerInput == "") exitMenu = true;
                    else
                    {
                        targetList.Add(playerInput);
                    }
                    
                }

                Console.ResetColor();
                Console.Clear();
            }
            void addToList_addLine(List<string> targetList, string targetPrompt, string addLine)
            {
                bool exitMenu = false;
                string playerInput = "";

                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine($"Copy and paste the column of the {targetPrompt}: ");
                while (!exitMenu)
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    playerInput = Console.ReadLine();
                    if (playerInput == "") exitMenu = true;
                    else
                    {
                        targetList.Add(playerInput + addLine);
                        Console.ResetColor();
                    }
                }

                Console.ResetColor();
                Console.Clear();
            }
        }
    }
}
