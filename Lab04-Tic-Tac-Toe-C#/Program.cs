namespace Lab04TicTacToeCsharp
{
    //creating class for players since they have two data types associated with them
    class Player
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




            Player currentPlayer = playerOne;//declare winner
            string winner = null; //either player one or two will win; so we use string because that's how we set our players up
            while (winner == null) // while there is no winner, keep going
            {
                Console.WriteLine(" It's {0}'s Turn", currentPlayer.Name);//each time the game loop runs, let user know who's turn it is

                //on each player's turn, display game board and give option to choose slot
                Console.WriteLine("Choose a Slot");
                DisplayBoard();
                string selectedSlot = Console.ReadLine();

                // as a user, I want to mark a spot that I select
                if (selectedSlot == "1")
                {
                    Board[0][0] = currentPlayer.Marker;

                }
                else if (selectedSlot == "2")
                {
                    Board[0][1] = currentPlayer.Marker;

                }
                else if (selectedSlot == "3")
                {
                    Board[0][2] = currentPlayer.Marker;
                }
                else if (selectedSlot == "4")
                {
                    Board[1][0] = currentPlayer.Marker;

                }
                else if (selectedSlot == "5")
                {
                    Board[1][1] = currentPlayer.Marker;

                }
                else if (selectedSlot == "6")
                {
                    Board[1][2] = currentPlayer.Marker;

                }
                else if (selectedSlot == "7")
                {
                    Board[2][0] = currentPlayer.Marker;

                }
                else if (selectedSlot == "8")
                {
                    Board[2][1] = currentPlayer.Marker;

                }
                else if (selectedSlot == "9")
                {
                    Board[2][2] = currentPlayer.Marker;
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

            //use a method to abstract away repeated logic
            static void DisplayBoard()
            {
                //display board to use display property
                Console.WriteLine("|{0}| |{1}| |{2}|", Board[0][0], Board[0][1], Board[0][2]);
                Console.WriteLine("|{0}| |{1}| |{2}|", Board[1][0], Board[1][1], Board[1][2]);
                Console.WriteLine("|{0}| |{1}| |{2}|", Board[2][0], Board[2][1], Board[2][2]);
            }
        }
    }
}
