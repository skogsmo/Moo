using System.Text.RegularExpressions;

namespace Moo
{
    public class Game
    {
        Iui ui;
        IO io;
        public Game(Iui ui, IO io) 
        {
            this.ui = ui;
            this.io = io;
        }

        public void Run()
        {
            bool playOn = true;
            ui.Write("Enter your user name:\n");
            string playerName = ui.Read();

            while (playOn)
            {
                string target = GenerateTarget();


                ui.Write("New game:\n");
                
                ShowTarget(target);
                string playerGuess = ReadUserGuess();

                int numberOfGuesses = 1;
                string bullsAndCows = CheckBullsAndCows(target, playerGuess);
                ui.Write(bullsAndCows + "\n");
                while (bullsAndCows != "BBBB,")
                {
                    numberOfGuesses++;
                    playerGuess = ui.Read();
                    ui.Write(playerGuess + "\n");
                    bullsAndCows = CheckBullsAndCows(target, playerGuess);
                    ui.Write(bullsAndCows + "\n");
                }
                io.UpdateTopList(playerName, numberOfGuesses);
                io.ShowTopList();
                ui.Write("Correct, it took " + numberOfGuesses + " guesses\nContinue?");
                string answer = ui.Read();
                if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
                {
                    playOn = false;
                }
            }
        }

        public static string GenerateTarget()
        {
            Random randomGenerator = new Random();
            string target = "";
            for (int i = 0; i < 4; i++)
            {
                int random = randomGenerator.Next(10);
                string randomDigit = "" + random;
                while (target.Contains(randomDigit))
                {
                    random = randomGenerator.Next(10);
                    randomDigit = "" + random;
                }
                target = target + randomDigit;
            }
            return target;
        }

        public void ShowTarget(string target)
        {
            ui.Write("For practice, number is: " + target + "\n");
        }

        public string ReadUserGuess()
        {
            while (true)
            {
                var userInput = ui.Read();
                if (userInput.Length == 4 && Regex.IsMatch(userInput, "[0-9]"))
                {
                    return userInput;
                }
                else
                {
                    ui.Write("Please only input digits. Four of them. Thaaanks.");
                }
            }
        }

        public static string CheckBullsAndCows(string target, string playerGuess)
        {
            int cows = 0, bulls = 0;
            if (playerGuess.Length < 4)
            {
                playerGuess += "    ";
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (target[i] == playerGuess[j])
                    {
                        if (i == j)
                        {
                            bulls++;
                        }
                        else
                        {
                            cows++;
                        }
                    }
                }
            }
            return "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);
        }
    }
}

    

