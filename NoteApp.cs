namespace Even_More_Notes
{
    internal class Program
    {
        //Main method. This is only where I am outputting things. Anything to do with the functionality of the Note app goes in "class Notes"!!!!!
        static void Main(string[] args)
        {
            //Call upon the Notes Class to create a new instance called notepad
            Notes notepad = new Notes();
            string menuChoice = "";
            bool leave = false;


            while (leave == false)
            {

                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1 - View notes");
                Console.WriteLine("2 - Create note");
                Console.WriteLine("3 - Delete note");
                Console.WriteLine("4 - View favorites");
                Console.WriteLine("5 - Favorite a note");
                Console.WriteLine("6 - Remove a favorite");
                Console.WriteLine("x - Exit notes\n");

                menuChoice = Console.ReadLine();

                //case switch 
                //Users input for menuChoice tells us where to go. 
                switch (menuChoice)
                {
                    case "1":
                        notepad.spacer();
                        notepad.viewNotes();
                        notepad.spacer();
                        break;

                    case "2":
                        notepad.createNote();
                        notepad.spacer();
                        break;

                    case "3":
                        notepad.deleteNote();
                        break;

                    case "4":
                        notepad.viewFavorites();
                        break;

                    case "5":
                        int favInput = notepad.favoriteInput();
                        notepad.addFavorite(favInput);
                        break;

                    case "6":
                        favInput = notepad.favoriteInput();
                        notepad.removeFavorite(favInput);
                        break;

                    case "x":
                        leave = true;
                        break;

                    default:
                        Console.WriteLine($"Invalid Input");
                        break;
                }
            }
        }

        //Notes application - ****Any functionality that a note app would serve belongs in here****
        class Notes
        {
            public string[] notesArray = new string[10];
            public DateTime[] createdDates = new DateTime[10];
            public int[] favoriteNumbers = new int[10];
            public int favoriteCount = 0;

            //All the methods
            //
            //
            // 1. User chooses to create a note. Once the note is entered then the "return;" breaks us out of the loop and sends us to the top of the while loop. 
            //if (notesArray[i] == null) is saying "if this specific spot in the array is nothing then do what's inside the if statement" 
            //
            // ****"null" only works for strings****
            //
            //notesArray[i] = userNote; WE ARE ADDING WHAT WAS JUST CREATED TO WHATEVER [i] EQUALS IN THE ARRAY
            public void createNote()
            {
                for (int i = 0; i < notesArray.Length; i++)
                {
                    if (notesArray[i] == null)
                    {
                        //Every time a note is created a spot in the array of notesArray[] and createdDates[] is filled.
                        Console.WriteLine("\nEnter note:");
                        string userNote = Console.ReadLine();
                        createdDates[i] = DateTime.Now;
                        notesArray[i] = userNote;
                        return;
                    }
                }
                Console.WriteLine("\n**Too many notes**\n");
            }

            //2. User wants to see their notes
            //
            //if (notesArray[i] != null) is saying "if there's something in that specific spot in the array then do what's in the if statement" 
            //It will loop 10 times(notesArray.Length) and if something is in there then we're going inside that if statement.
            //
            public void viewNotes()
            {
                for (int i = 0; i < notesArray.Length; i++)
                {
                    //THIS ONLY DISPLAYS NOTES IN THE ARRAY THAT ARE OCCUPIED
                    if (notesArray[i] != null)
                    {
                        Console.WriteLine($"Note #{i + 1} - {notesArray[i]} - {createdDates[i].ToString("d")}");
                    }
                }
            }

            //3. User wants to delete a note
            public void deleteNote()
            {
                //user inputs the note they want to delete
                Console.WriteLine("Select a note to delete");
                int noteToDelete = Convert.ToInt32(Console.ReadLine());

                //notesArray is updated to the user input -1 because notesArray is initialized with 10 spots. Whatever they input is now considered null(nothing)
                notesArray[noteToDelete - 1] = null;
            }

            //4. User wants to view their favorited notes
            public void viewFavorites()
            {
                Console.WriteLine("Favorites:");
                for (int i = 0; i < favoriteCount; i++)
                {
                    //noteIndex is equal to however many spots the array favoriteNumbers[] currently holds - 1(because arrays start at 0)
                    //**If 4 & 1 are selected as favorites then the first time the loop goes through the noteIndex will equal 3 and the second time it will equal 0. 
                    //
                    //
                    int noteIndex = favoriteNumbers[i] - 1;
                    //if noteIndex is GREATER THAN OR EQUAL to 0 AND noteIndex is LESS THAN notesArray.Length(10) AND notesArray[noteIndex] IS SOMETHING then do whatever is in the if statement
                    if (noteIndex >= 0 && noteIndex < notesArray.Length && notesArray[noteIndex] != null)
                    {
                        //displaying whichever number was first in favoriteNumbers[]. if noteIndex = 3 then notesArray[noteIndex] will display the 4th note in notesArray[].
                        Console.WriteLine($"Note #{favoriteNumbers[i]}: {notesArray[noteIndex]} - {createdDates[i].ToString("d")}");
                    }

                }
            }

            //5. User wants to add a favorite note. IF PASSING SOMETHING INTO A METHOD THEN THERE HAS TO BE A PARAMETER
            public void addFavorite(int faveNum)
            {
                //**faveNum that we gathered from favoriteInput() is now inside addFavorite()**
                //
                //**Whenever this method is called it places faveNum into favoriteNumbers[]**
                //**It's placement in favoriteNumbers[] is based on whatever favoriteCount is when it enters this method**
                //
                //If favoriteCount = 2 and faveNum = 6 then the number 6(also 6th note in notesArray[]) will be added to the 3rd spot in favoriteNumbers[]  
                //favoriteCount is incremented by 1 each time addFavorite() is called on
                favoriteNumbers[favoriteCount] = faveNum;
                favoriteCount++;
                Console.WriteLine($"Favorite note #{faveNum} added");

            }

            //6. User wants to remove a favorite note. YOU'RE ABOUT TO PASS SOMETHING ***INTO*** THIS FUNCTION. YOU NEED A PARAMETER!!!!!
            public void removeFavorite(int removeNum)
            {
                //faveNum from favoriteInput() has been passed to removeFavorite()
                for (int i = 0; i < favoriteNumbers.Length; i++)
                {
                    //loop until favoriteNumbers[i] is equal to the user input from favoriteInput()
                    if (favoriteNumbers[i] == removeNum)
                    {
                        //once favoriteNumbers[i] equals the user input then we replace that spot in the array favoriteNumbers[] with 0
                        favoriteNumbers[i] = 0;
                        //favoriteCount decrements to make space for another favorite
                        favoriteCount--;
                        Console.WriteLine($"Favorite note #{removeNum} removed");
                        //return to exit loop
                        return;
                    }
                }
            }
            //User inputs a favorite number. IF PASSING SOMETHING OUT OF A METHOD THEN YOU DON'T NEED A PARAMETER, BUT YOU DO NEED THE RETURN TYPE TO MATCH THE DATA YOU'RE RETURNING
            public int favoriteInput()
            {
                //user inputs the # of the note they want to favorite
                Console.WriteLine("Enter a favorite note");
                int faveNum = Convert.ToInt32(Console.ReadLine());

                //displays the user input and puts the user input into that specific spot within the notesArray[faveNum -1]
                Console.WriteLine($"Favorite note #{faveNum} - Note: {notesArray[faveNum - 1]}");

                //returning faveNum to the Main Method
                return faveNum;
            }

            //One lone line spacing
            public void spacer()
            {
                Console.WriteLine();
            }
        }
    }
}