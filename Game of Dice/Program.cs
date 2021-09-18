using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool playAgain = true;
            int pix = 500;
            int round = 0;
            int Bonus = 0;
            int reward;
            int answer;
            bool invalidBet = true;
            Console.WriteLine("You start with " + pix + " pix to spend.");

            while (playAgain == true)
            {
                round++;
                invalidBet = true;

                Console.WriteLine("How much do you want to bet? (Bet atleast 50 pix)");

                int.TryParse(Console.ReadLine(), out int bet);

                while (invalidBet == true)
                {
                    if (bet < 50)
                    {
                        Console.WriteLine("Your bet is invalid. Please bet 50 pix or more.");
                        int.TryParse(Console.ReadLine(), out bet);
                    }

                    else if (bet > pix)
                    {
                        Console.WriteLine("Your bet is invalid. You cannot bet more than your current pix.");
                        int.TryParse(Console.ReadLine(), out bet);
                    }
                    else invalidBet = false;
                }


                Console.WriteLine("Your bet is " + bet + ". Please write your lucky number between 1-6 and I will roll 3 dice for you");

                int.TryParse(Console.ReadLine(), out int luckyNumber);

                while (luckyNumber >= 7 || luckyNumber < 1)
                {
                    Console.WriteLine("Please write a number between 1-6.");
                    int.TryParse(Console.ReadLine(), out luckyNumber);
                }

                Random diceRoll = new Random();
                int diceResult1 = diceRoll.Next(1, 6);
                int diceResult2 = diceRoll.Next(1, 6);
                int diceResult3 = diceRoll.Next(1, 6);

                Console.Clear();
                Console.WriteLine("The dice results are " + diceResult1 + ", " + diceResult2 + " and " + diceResult3 + ".");

                if (diceResult1 == luckyNumber) Bonus++;
                if (diceResult2 == luckyNumber) Bonus++;
                if (diceResult3 == luckyNumber) Bonus++;

                if (Bonus == 0)
                {
                    pix = pix - bet;
                    Console.WriteLine("None of the dice shows your lucky number " + luckyNumber + ". You lost " + bet + " pix.");

                    if (pix < 50)
                    {
                        Console.WriteLine("You have less than 50 pix, your have lost the game. :(");
                        playAgain = false;
                    }
                }

                else if (Bonus == 1)
                {
                    reward = bet * 2;
                    pix = pix + reward;
                    Console.WriteLine(Bonus + " of the dice shows your lucky number " + luckyNumber + ". You won " + reward + "!");
                }

                else if (Bonus == 2)
                {
                    reward = bet * 3;
                    pix = pix + reward;
                    Console.WriteLine(Bonus + " of the dice shows your lucky number " + luckyNumber + ". You won " + reward + "!");
                }

                else if (Bonus == 3)
                {
                    reward = bet * 4;
                    pix = pix + reward;
                    Console.WriteLine(Bonus + " of the dice shows your lucky number " + luckyNumber + ". You won " + reward + "!");
                }

                Console.WriteLine("You currently have " + pix + " pix");

                Console.WriteLine("Do you want to play another round? (Type 1 for yes and any other key for no)");

                int.TryParse(Console.ReadLine(), out answer);

                int earnings = pix - 500;

                if (answer == 0 || answer > 1)
                {
                    Console.Clear();
                    Console.WriteLine("You walked out with " + pix + " pix on round " + round + ".");
                    Console.WriteLine("You have earned a total of " + earnings + " pix! Congratulations!");
                    playAgain = false;
                }
                else if (answer == 1) playAgain = true;
            }
        }
    }
}
