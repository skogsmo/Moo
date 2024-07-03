namespace MOO.Business;

public class Game
{
    Iui ui;
    Player player;
    public Game(Iui ui, Player player)
    {
        this.ui = ui;
        this.player = player;
    }

    public void Run()
    {
        bool playOn = true;
        ui.Write("Enter your user name:\n");
        string name = ui.Read();

        while (playOn)
        {
            string goal = makeGoal();


            ui.Write("New game:\n");
            //comment out or remove next line to play real games!
            ui.Write("For practice, number is: " + goal + "\n");
            string guess = ui.Read();

            int nGuess = 1;
            string bbcc = checkBC(goal, guess);
            ui.Write(bbcc + "\n");
            while (bbcc != "BBBB,")
            {
                nGuess++;
                guess = ui.Read();
                ui.Write(guess + "\n");
                bbcc = checkBC(goal, guess);
                ui.Write(bbcc + "\n");
            }
            StreamWriter output = new StreamWriter("result.txt", append: true);
            output.WriteLine(name + "#&#" + nGuess);
            output.Close();
            player.showTopList();
            Console.WriteLine("Correct, it took " + nGuess + " guesses\nContinue?");
            string answer = Console.ReadLine();
            if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
            {
                playOn = false;
            }
        }
    }

    static string makeGoal()
    {
        Random randomGenerator = new Random();
        string goal = "";
        for (int i = 0; i < 4; i++)
        {
            int random = randomGenerator.Next(10);
            string randomDigit = "" + random;
            while (goal.Contains(randomDigit))
            {
                random = randomGenerator.Next(10);
                randomDigit = "" + random;
            }
            goal = goal + randomDigit;
        }
        return goal;
    }

    static string checkBC(string goal, string guess)
    {
        int cows = 0, bulls = 0;
        guess += "    ";     // if player entered less than 4 chars
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (goal[i] == guess[j])
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


