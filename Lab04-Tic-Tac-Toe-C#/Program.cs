using System.ComponentModel.DataAnnotations;

namespace Lab04TicTacToeCsharp
{
    //creating class for players since they have two data types associated with them
    public class Player
    {
        public string Name;
        public string Marker;

        //takes in parameters to build and object with same parameters ;constructor function for class has same name ; instanciate object from class and set object from one stroke
        public Player(string name, string marker)
        {
            // set values of constructors for the objects
            Name = name;
            Marker = marker;
        }
    }

    internal class Program
    {
        public static string[][] Board; //property that holds board : matrix array
        public static Player currentPlayer;
        static void Main(string[] args)
        {
            Console.WriteLine("Heeeeeeeerrrreee's Johnny!!!");

            Console.WriteLine("PlayerOne's Name: ");
            string playerOneName = Console.ReadLine();
            Player playerOne = new Player(playerOneName, "X"); //instanciating player object

            Console.WriteLine("PlayerTwo's Name: ");
            string playerTwoName = Console.ReadLine();
            Player playerTwo = new Player(playerTwoName, "O");

            //returning the names that were entered in tournament/vs style
            Console.WriteLine("===== {0} vs {1} =====", playerOne.Name, playerTwo.Name);

            Board = new string[][]
            {
                    //declare objects : rows
                    new string[] {"1", "2", "3"},
                    new string[] {"4", "5", "6"},
                    new string[] {"7", "8", "9"}
            };


            Console.WriteLine("Try me, if you dare!");
            DisplayBoard();




            Player currentPlayer = playerOne;//declare winner
            string winner = null; //either player one or two will win; so we use string because that's how we set our players up
            while (winner == null) // while there is no winner, keep going
            {
                Console.WriteLine(" It's {0}'s Turn", currentPlayer.Name);//each time the game loop runs, let user know who's turn it is

                //on each player's turn, display game board and give option to choose slot
                Console.WriteLine("Choose a Slot");
                DisplayBoard();
                string selectedSlot = Console.ReadLine();


                bool isValid = SelectionIsValid(selectedSlot);
                if (isValid)
                {
                    int[] indexes = FromSelectionToIndex(selectedSlot);
                    int row = indexes[0];
                    int column = indexes[1];
                    Board[row][column] = currentPlayer.Marker;
                }
                else
                {
                    continue;
                }

                if (currentPlayer == playerOne)
                {
                    currentPlayer = playerTwo;
                }
                else if (currentPlayer == playerTwo)
                {
                    currentPlayer = playerOne;
                }
            }
        }

        //    // as a user, I want to mark a spot that I select
        //    if (selectedSlot == "1")
        //    {
        //        //Check if slot has already been selected
        //        string slotValue = Board[0][0];
        //        if (slotValue == "X" || slotValue == "O")
        //        {
        //            Console.WriteLine("Invalid Solution");
        //            continue;
        //        }
        //        Board[0][0] = currentPlayer.Marker;
        //    }
        //    else if (selectedSlot == "2")
        //    {
        //        string slotValue = Board[0][1];
        //        if (slotValue == "X" || slotValue == "O")
        //        {
        //            Console.WriteLine("Invalid Solution");
        //            continue;
        //        }
        //        Board[0][1] = currentPlayer.Marker;

        //    }
        //    else if (selectedSlot == "3")
        //    {
        //        string slotValue = Board[0][2];
        //        if (slotValue == "X" || slotValue == "O")
        //        {
        //            Console.WriteLine("Invalid Solution");
        //            continue;
        //        }
        //        Board[0][2] = currentPlayer.Marker;
        //    }
        //    else if (selectedSlot == "4")
        //    {
        //        string slotValue = Board[1][0];
        //        if (slotValue == "X" || slotValue == "O")
        //        {
        //            Console.WriteLine("Invalid Solution");
        //            continue;
        //        }
        //        Board[1][0] = currentPlayer.Marker;

        //    }
        //    else if (selectedSlot == "5")
        //    {
        //        string slotValue = Board[1][1];
        //        if (slotValue == "X" || slotValue == "O")
        //        {
        //            Console.WriteLine("Invalid Solution");
        //            continue;
        //        }
        //        Board[1][1] = currentPlayer.Marker;

        //    }
        //    else if (selectedSlot == "6")
        //    {
        //        string slotValue = Board[1][2];
        //        if (slotValue == "X" || slotValue == "O")
        //        {
        //            Console.WriteLine("Invalid Solution");
        //            continue;
        //        }
        //        Board[1][2] = currentPlayer.Marker;

        //    }
        //    else if (selectedSlot == "7")
        //    {
        //        string slotValue = Board[2][0];
        //        if (slotValue == "X" || slotValue == "O")
        //        {
        //            Console.WriteLine("Invalid Solution");
        //            continue;
        //        }
        //        Board[2][0] = currentPlayer.Marker;

        //    }
        //    else if (selectedSlot == "8")
        //    {
        //        string slotValue = Board[2][1];
        //        if (slotValue == "X" || slotValue == "O")
        //        {
        //            Console.WriteLine("Invalid Solution");
        //            continue;
        //        }
        //        Board[2][1] = currentPlayer.Marker;

        //    }
        //    else if (selectedSlot == "9")
        //    {
        //        string slotValue = Board[2][2];
        //        if (slotValue == "X" || slotValue == "O")
        //        {
        //            Console.WriteLine("Invalid Solution");
        //            continue;
        //        }
        //        Board[2][2] = currentPlayer.Marker;
        //    }

        //    if (currentPlayer == playerOne)
        //    {
        //        currentPlayer = playerTwo;

        //    }
        //    else if (currentPlayer == playerTwo)

        //    {
        //        currentPlayer = playerOne;
        //    }



        //use a method to abstract away repeated logic
        static void DisplayBoard()
        {
            //display board to use display property
            Console.WriteLine("|{0}| |{1}| |{2}|", Board[0][0], Board[0][1], Board[0][2]);
            Console.WriteLine("|{0}| |{1}| |{2}|", Board[1][0], Board[1][1], Board[1][2]);
            Console.WriteLine("|{0}| |{1}| |{2}|", Board[2][0], Board[2][1], Board[2][2]);
        }

        // method that translates user selections into indexes
        static int[] FromSelectionToIndex(string selectedSlot)
        {
            int[] indexes = new int[2]; //declare interger array
            switch (selectedSlot)
            {
                case "1":
                    indexes[0] = 0;
                    indexes[1] = 0;
                    break;

                case "2":
                    indexes[0] = 0;
                    indexes[1] = 1;
                    break;

                case "3":
                    indexes[0] = 0;
                    indexes[1] = 2;
                    break;

                case "4":
                    indexes[0] = 1;
                    indexes[1] = 0;
                    break;

                case "5":
                    indexes[0] = 1;
                    indexes[1] = 1;
                    break;

                case "6":
                    indexes[0] = 1;
                    indexes[1] = 2;
                    break;

                case "7":
                    indexes[0] = 2;
                    indexes[1] = 0;
                    break;

                case "8":
                    indexes[0] = 2;
                    indexes[1] = 1;
                    break;

                case "9":
                    indexes[0] = 2;
                    indexes[1] = 2;
                    break;

            }
            return indexes;
        }


        public static bool SelectionIsValid(string selectedSlot)
        {

            //{
            //    bool isValid = true;
            //    if (selectedSlot == "1")
            //    {
            //        string slotValue = Board[0][0];
            //        if (slotValue == "X" || slotValue == "O")
            //        {
            //            isValid = false;

            //        }
            //    }
            //    else if (selectedSlot == "2")
            //    {
            //        string slotValue = Board[0][1];
            //        if (slotValue == "X" || slotValue == "O")
            //        {
            //            isValid = false;

            //        }
            //    }
            //    else if (selectedSlot == "3")
            //    {
            //        string slotValue = Board[0][2];
            //        if (slotValue == "X" || slotValue == "O")
            //        {
            //            isValid = false;

            //        }
            //    }
            //    else if (selectedSlot == "4")
            //    {
            //        string slotValue = Board[1][0];
            //        if (slotValue == "X" || slotValue == "O")
            //        {
            //            isValid = false;

            //        }
            //    }
            //    else if (selectedSlot == "5")
            //    {
            //        string slotValue = Board[1][1];
            //        if (slotValue == "X" || slotValue == "O")
            //        {
            //            isValid = false;

            //        }
            //    }
            //    else if (selectedSlot == "6")
            //    {
            //        string slotValue = Board[1][2];
            //        if (slotValue == "X" || slotValue == "O")
            //        {
            //            isValid = false;

            //        }
            //    }
            //    else if (selectedSlot == "7")
            //    {
            //        string slotValue = Board[2][0];
            //        if (slotValue == "X" || slotValue == "O")
            //        {
            //            isValid = false;

            //        }
            //    }
            //    else if (selectedSlot == "8")
            //    {
            //        string slotValue = Board[2][1];
            //        if (slotValue == "X" || slotValue == "O")
            //        {
            //            isValid = false;

            //        }
            //    }
            //    else if (selectedSlot == "9")
            //    {
            //        string slotValue = Board[2][2];
            //        if (slotValue == "X" || slotValue == "O")
            //        {
            //            isValid = false;

            //        }
            //    }

            //    if (isValid != true)
            //    {
            //        Console.WriteLine("Invalid Selection");
            //    }
            //    return isValid;

            //}

            bool isValid = true;
            int[] indexes = FromSelectionToIndex(selectedSlot);
            int row = indexes[0];
            int column = indexes[1];
            string slotValue = Board[row][column];
            if (slotValue == "X" || slotValue == "O")
            {
                isValid = false;
            }
            if (isValid == false)
            {
                Console.WriteLine("Selection is invalid");
            }
            return isValid;
        }
        public static string WhoWinsTheGame()
        {
            // Checking the rows for win
            // i = row
            for (int i = 0; i < 3; i++)
            {
                if (Board[i][0] == Board[i][1] && Board[i][1] == Board[i][2])
                {
                    return Board[i][0];
                }
            }

            // Checking columns for win
            // i = colummn
            for (int i = 0; i < 3; i++)
            {
                if (Board[0][i] == Board[1][i] && Board[1][i] == Board[2][i])
                {
                    return Board[0][i];
                }
            }

            // Check diagonals for win
            if ((Board[0][0] == Board[1][1] && Board[1][1] == Board[2][2]) ||
                (Board[0][2] == Board[1][1] && Board[1][1] == Board[2][0]))
            {
                return Board[1][1];
            }

            // if there is no winner ...
            return null;
        }

        public static void SwitchPlayers(Player playerOne, Player playerTwo)
        {
            if (currentPlayer == playerOne)
            {
                currentPlayer = playerTwo;
            }
            else
            {
                currentPlayer = playerOne;
            }
        }
    }
}
