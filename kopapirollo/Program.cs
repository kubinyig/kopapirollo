using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kopapirollo
{
    class Program
    {
        static void Main(string[] args)
        {
                bool continuePlaying = true;
                int playerScore = 0;
                int computerScore = 0;

                while (continuePlaying)
                {
                Console.Clear();
                Console.WriteLine("Kő-Papír-Olló Játék!");
                    Console.WriteLine("====================");
                    Console.WriteLine($"\nPontok: Játékos: {playerScore} | Gép: {computerScore}");
                    Console.WriteLine("Válassz: (1) Kő, (2) Papír, (3) Olló");

                    int playerChoice = GetPlayerChoice();

                    if (playerChoice == -1)
                    {
                        Console.WriteLine("Hibás választás! Próbáld újra.");
                        continue;
                    }

                    Random random = new Random();
                    int computerChoice = random.Next(1, 4);

                    string result = Result(playerChoice, computerChoice);
                    Console.WriteLine($"Eredmény: {result}");

                    if (result == "Győztél!")
                    {
                        playerScore++;
                    }
                    else if (result == "A gép nyert!")
                    {
                        computerScore++;
                    }

                    Console.WriteLine("\nSzeretnél még játszani? (i/n)");
                    string playAgainInput = Console.ReadLine().ToLower();

                    if (playAgainInput != "i" && playAgainInput != "igen")
                    {
                        continuePlaying = false;
                        Console.WriteLine($"\nVégeredmény: Játékos: {playerScore} - Gép: {computerScore}");
                        Console.WriteLine("Köszönöm, hogy játszottál! Viszlát!");
                    }
                }
            }

            static int GetPlayerChoice()
            {
                string input = Console.ReadLine();

                if (int.TryParse(input, out int choice))
                {
                    if (choice >= 1 && choice <= 3)
                    {
                        return choice;
                    }
                }
                return -1;
            }

            static string Result(int playerChoice, int computerChoice)
            {
                if (playerChoice == computerChoice)
                {
                    return "Döntetlen!";
                }

                switch (playerChoice)
                {
                    case 1: 
                        return computerChoice == 3 ? "Győztél!" : "A gép nyert!";
                    case 2: 
                        return computerChoice == 1 ? "Győztél!" : "A gép nyert!";
                    case 3: 
                        return computerChoice == 2 ? "Győztél!" : "A gép nyert!";
                    default:
                        return "Hibás választás!";
                }
            }
        }
}
