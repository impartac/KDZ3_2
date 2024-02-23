using KDZ3_2;
using Libruary;
/// <summary>
/// Aparkin Matvej CS HSE SE 238
/// Variant 1
/// </summary>
class Program 
{
    static void Main()
    {
        Decomposition decomposition = new Decomposition();
        do 
        {
            Decomposition.menu.Clear();
            List<Record?>? records = new List<Record?>();
            decomposition.Start(ref records);
            do
            {
                decomposition.Solution(ref records);
            }
            while (Console.ReadKey().Key == ConsoleKey.Enter);
            decomposition.SaveFile(ref records);
            Decomposition.menu.ReadNewFile(ConsoleKey.N);
        }
        while (Console.ReadKey().Key == ConsoleKey.N);

    }
}
/*
░░░░░░░░░░░░░░░░░░░░
░░░░░ЗАПУСКАЕМ░░░░░░░
░ГУСЯ░▄▀▀▀▄░РАБОТЯГИ░░
▄███▀░◐░░░▌░░░░░░░░░
░░░░▌░░░░░▐░░░░░░░░░
░░░░▐░░░░░▐░░░░░░░░░
░░░░▌░░░░░▐▄▄░░░░░░░
░░░░▌░░░░▄▀▒▒▀▀▀▀▄
░░░▐░░░░▐▒▒▒▒▒▒▒▒▀▀▄
░░░▐░░░░▐▄▒▒▒▒▒▒▒▒▒▒▀▄
░░░░▀▄░░░░▀▄▒▒▒▒▒▒▒▒▒▒▀▄
░░░░░░▀▄▄▄▄▄█▄▄▄▄▄▄▄▄▄▄▄▀▄
░░░░░░░░░░░▌▌░▌▌░░░░░
░░░░░░░░░░░▌▌░▌▌░░░░░
░░░░░░░░░▄▄▌▌▄▌▌░░░░░
*/