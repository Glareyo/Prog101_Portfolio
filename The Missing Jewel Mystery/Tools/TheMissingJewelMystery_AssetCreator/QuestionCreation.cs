using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMissingJewelMystery_AssetCreator
{
    class QuestionCreation
    {
        public void CreateQuestions()
        {
            const string FOLDER = "All_Questions";



            Console.WriteLine("Questions Creation Menu.");

            string characterName = "";

            List<string> questionID = new List<string>();
            List<string> questionPrompt = new List<string>();
            List<string> answer = new List<string>();
            List<string> requiredQuestionID = new List<string>();
            List<string> requiredClueID = new List<string>();
            List<string> statementCluePerson = new List<string>();
            List<string> clueSummary = new List<string>();


            characterName = SetCharacterName();

            //Get question prompt
            addToList(questionPrompt, "Question Prompt");


            


            //Get answer prompt
            addToList(answer, "Answer");

            //Get the required Question ID
            addToList(requiredQuestionID, "Required Question Prompt");
            
            //Get Required Clue ID
            addToList(requiredClueID, "Required Clue ID");

            //Get the name of the person who holds the clue, if the clue is a statement.
            addToList(statementCluePerson, "The name of the person Statement ClueID");


            //Get the clue summary.
            addToList(clueSummary, "Clue Summary");

            //Set the question ID
            for (int n = 0; n < questionPrompt.Count; n++)
            {
                string entireID = characterName + "_" + SetQuestionID(questionPrompt[n]);
                questionID.Add(entireID);

                if (requiredQuestionID[n] != "_")
                {
                    requiredQuestionID[n] = characterName + "_" + SetQuestionID(requiredQuestionID[n]);
                }
                else requiredQuestionID[n] = " ";


            }

            
            
            SetClueIDs();


            for (int i = 0; i < questionID.Count; i++)
            {
                string holdingFolder = Path.Combine(Directory.GetCurrentDirectory(), FOLDER);

                string entireFormating = $@"-QUESTION_ID
{questionID[i]}
-----------------------------------------------------
-QUESTION_PROMPT
{questionPrompt[i]}
-----------------------------------------------------
-ANSWER
{answer[i]}
-----------------------------------------------------
-REQUIRED_QUESTION_ID;
{requiredQuestionID[i]}
-----------------------------------------------------
-REQUIRED_CLUE_ID;
{requiredClueID[i]}
-----------------------------------------------------
-CLUE_SUMMARY;
{clueSummary[i]}
-----------------------------------------------------";

                File.WriteAllText(Path.Combine(holdingFolder, $"{questionID[i]}.txt"), entireFormating);



            }

            ConfirmedCreation();



            void SetRequiredQuestions()
            {
                foreach(string prompt in questionPrompt)
                {
                    questionID.Add(characterName + "_" + SetQuestionID(prompt));
                }
            }
            string SetCharacterName()
            {
                string playerInput;
                
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine($"Type the Character's name: ");

                playerInput = Console.ReadLine();
                Console.ResetColor();
                Console.Clear();

                return playerInput;
            }
            string SetQuestionID(string _question)
            {
                string modifiedQuestion = "";
                bool capitalizedLetter = false;
                
                foreach (char c in _question)
                {
                    if (c == ' ')
                    {
                        capitalizedLetter = true;
                    }
                    else if (c == '\'' || c == '.' || c =='?' || c == '\"' || c == ',')
                    {
                        //continue;
                    }
                    else
                    {
                        if (capitalizedLetter)
                        {
                            capitalizedLetter = false;
                            Console.WriteLine("Capitalization Cleared.");
                            string temp = c.ToString();
                            temp = temp.ToUpper();

                            modifiedQuestion += temp;

                        }
                        else modifiedQuestion += c;




                    }
                }

                return modifiedQuestion + "QID";
            }
            void SetClueIDs()
            {
                for (int x = 0; x < requiredClueID.Count; x++)
                {
                    if (requiredClueID[x] == "_")
                    {
                        requiredClueID[x] = " ";
                    }//Else if clueID has a string in it.
                    else if (statementCluePerson[x] != "_")
                    {
                        requiredClueID[x] = statementCluePerson[x] + "_" + SetQuestionID(requiredClueID[x]);
                    }
                    else
                    {
                        requiredClueID[x] = requiredClueID[x] + "ItemID";
                    }
                }
            }

            void ConfirmedCreation()
            {
                Console.Clear();
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Magenta;

                Console.WriteLine($"Creating questions....Please check {FOLDER} for text files.");

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
