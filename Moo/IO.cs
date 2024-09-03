namespace Moo
{
    public class IO
    {
        Iui ui;
        public IO(Iui ui)
        {
            this.ui = ui; 
        }

        public void ShowTopList()
        {
            List<PlayerData> results = new List<PlayerData>();
            ConsoleUI ui = new ConsoleUI();
            results = ReadPlayersFromFile("result.txt");
            results.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
            ui.Write("Player   games average");
            ViewPlayerResults(results);
        }

        public void UpdateTopList(string playerName, int numberOfGuesses)
        {
            StreamWriter output = new StreamWriter("result.txt", append: true);
            output.WriteLine(playerName + "#&#" + numberOfGuesses);
            output.Close();
        }

        public void ViewPlayerResults(List<PlayerData> results)
        {
            foreach (PlayerData player in results)
            {
                ui.Write(string.Format("{0,-9}{1,5:D}{2,9:F2}", player.Name, player.NumberOfGames, player.Average()));
            }
        }

        public List<PlayerData> ReadPlayersFromFile(string file)
        {
            List<PlayerData> results = new();
            StreamReader input = new StreamReader(file);
            string line;
            while ((line = input.ReadLine()) != null)
            {
                string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
                string name = nameAndScore[0];
                int guesses = Convert.ToInt32(nameAndScore[1]);
                PlayerData pd = new PlayerData(name, guesses);
                int position = results.IndexOf(pd);
                if (position < 0)
                {
                    results.Add(pd);
                }
                else
                {
                    results[position].Update(guesses);
                }
            }
            input.Close();
            return results;
        }
    }
}
