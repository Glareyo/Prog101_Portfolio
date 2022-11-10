using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMissingJewelMystery_AssetCreator
{
    class ContainerCreation
    {
        public void CreateItems()
        {
            const string FOLDER = "All_Items";



            Console.WriteLine("Containers Creation Menu.");




            List<string> itemID = new List<string>();
            List<string> name = new List<string>();
            List<string> description = new List<string>();
            List<string> interactDescription = new List<string>();
            List<string> clueSummary = new List<string>();
            List<string> Room_ID = new List<string>();
            List<string> currentState = new List<string>();
            List<string> size = new List<string>();
            List<string> canPickUp = new List<string>();

            List<string> containedItems_List1 = new List<string>();
            List<string> containedItems_List2 = new List<string>();
            List<string> containedItems_List3 = new List<string>();
            List<string> containedItems_List4 = new List<string>();
            List<string> containedItems_List5 = new List<string>();




            addToList_addLine(itemID, "ItemID", "ItemID");
            addToList(name, "Name");
            addToList(description, "Description");
            addToList(interactDescription, "Interact Description");
            addToList(clueSummary, "Clue Summary");
            addToList(Room_ID, "Room ID");
            addToList(currentState, "CurrentState");
            addToList(size, "Size");
            addToList(canPickUp, "Can Pick Up Bool");

            addToList_addLine(containedItems_List1, "Contained Item 1", "ItemID");
            addToList_addLine(containedItems_List2, "Contained Item 2", "ItemID");
            addToList_addLine(containedItems_List3, "Contained Item 3", "ItemID");
            addToList_addLine(containedItems_List4, "Contained Item 4", "ItemID");
            addToList_addLine(containedItems_List5, "Contained Item 5", "ItemID");






            //Create Text Files
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
true
-----------------------------------------------------------------------------------
-IS_LOCKED
False
-----------------------------------------------------------------------------------
-UNLOCKING_DESCRIPTION
 
-----------------------------------------------------------------------------------
-KEY_ITEM_ID(If locked):
 
-----------------------------------------------------------------------------------
-CONTAINED_ITEM_IDS (List of items)
{containedItems_List1[i]}
{containedItems_List2[i]}
{containedItems_List3[i]}
{containedItems_List4[i]}
{containedItems_List5[i]}";

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
                    else targetList.Add(playerInput);
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
                        if (playerInput == "_") 
                        {
                            playerInput = " ";
                            targetList.Add(playerInput);
                        }
                        else targetList.Add(playerInput + addLine);


                    }
                }
                Console.ResetColor();
                Console.Clear();

            }


        }
    }
}
