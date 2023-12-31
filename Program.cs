﻿class Program
{
  static void Main(string[] args)
  {
    var calculator = new AbilityScoreCalculator();

    while(true)
    {
      calculator.RollResult = ReadInt(calculator.RollResult, "Starting 4d6 roll");
      calculator.DivideBy = ReadDouble(calculator.DivideBy, "Divide by");
      calculator.AddAmount = ReadInt(calculator.AddAmount, "Add amount");
      calculator.Minimum = ReadInt(calculator.Minimum, "Minimum");
      calculator.CalculateAbilityScore();
      Console.WriteLine("Calculated ability score: " + calculator.Score);
      Console.WriteLine("Press Q to quit, any other key to continue");

      char keyChar = Console.ReadKey(true).KeyChar;
      if((keyChar=='Q') || (keyChar=='q')) return;
    }

    static int ReadInt(int lastUsedValue, string prompt)
    {
      Console.Write(prompt + $" [{lastUsedValue}]: ");
      string? line = Console.ReadLine();
      if(int.TryParse(line,out int value))
      {
        Console.WriteLine("   using value " + value);
        return value;
      }
      else
      {
        Console.WriteLine("   using default value " + lastUsedValue);
        return lastUsedValue;
      }
    }
    static double ReadDouble(double lastUsedValue, string prompt)
    {
      Console.Write(prompt + $" [{lastUsedValue}]: ");
      string? line = Console.ReadLine();
      if(double.TryParse(line, out double value))
      {
        Console.WriteLine("   using value " + value);
        return value;
      }
      else
      {
        Console.WriteLine("   using default value " + lastUsedValue);
        return lastUsedValue;
      }
    }
  }
}

class AbilityScoreCalculator
{
  static Random random1 = new Random();
  static Random random2 = new Random();
  static Random random3 = new Random();
  static Random random4 = new Random();

  public int RollResult = random1.Next(1,7) + random2.Next(1,7) + random3.Next(1,7) + random4.Next(1,7);
  public double DivideBy = 1.75;
  public int AddAmount = 2;
  public int Minimum = 3;
  public int Score;

  public void CalculateAbilityScore()
  {
    double divide = RollResult / DivideBy;
    
    int added = AddAmount + (int)divide;

    if(added < Minimum)
    {
      Score = Minimum;
    }
    else
    {
      Score = added;
    }
  }
}
