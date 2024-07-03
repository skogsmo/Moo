namespace Moo
{
    public class ConsoleUI : Iui
    {
        public string Read() => Console.ReadLine();
        public void Write(string message) => Console.WriteLine(message);
        public void Clear() => Console.Clear();
        public void Exit() => Environment.Exit(0);
    }
}
