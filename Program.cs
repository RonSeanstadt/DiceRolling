
using System;

class DiceSimulator
{
    static void Main()
    {
        // Welcome the user to the game
        Console.WriteLine("Welcome to the dice throwing simulator!\n");

        // Get the number of dice rolls from the user
        Console.Write("How many dice rolls would you like to simulate? ");
        int numRolls = int.Parse(Console.ReadLine());

        // Create an instance of the DiceRoller class
        DiceRoller diceRoller = new DiceRoller();

        // Simulate dice rolls and get the results array
        int[] results = diceRoller.SimulateRolls(numRolls);

        // Display the results as a histogram
        DisplayHistogram(results, numRolls);

        Console.WriteLine("\nThank you for using the dice throwing simulator. Goodbye!");
    }

    static void DisplayHistogram(int[] results, int totalRolls)
    {
        // Write the introduction to the game and explain the rules
        Console.WriteLine("\nDICE ROLLING SIMULATION RESULTS");
        Console.WriteLine("Each \"*\" represents 1% of the total number of rolls.");
        Console.WriteLine($"Total number of rolls = {totalRolls}.\n");

        // Displays all the asterisks for the histogram
        for (int i = 2; i <= 12; i++)
        {
            int percentage = results[i] * 100 / totalRolls;
            string asterisks = new string('*', percentage);

            Console.WriteLine($"{i}: {asterisks}");
        }
    }
}

class DiceRoller
{
    private Random random;

    public DiceRoller()
    {
        random = new Random();
    }

    public int[] SimulateRolls(int numRolls)
    {
        int[] results = new int[13]; // Index 0 is not used, results for sums 2 to 12

        for (int i = 0; i < numRolls; i++)
        {
            int dice1 = random.Next(1, 7);
            int dice2 = random.Next(1, 7);
            int sum = dice1 + dice2;

            results[sum]++;
        }

        return results;
    }
}