using System;

Main();

void Main()
{
  int userSelection = MenuPrompt();
  NumbersInput userNumbers = NumberPrompt();
  if (userNumbers != null)
  {

    if (userSelection == 4 && userNumbers.Num2 == 0)
    {
      Console.WriteLine("Nah, you can't divide by zero.");
      Console.WriteLine("Press any key to continue...");
      Console.ReadKey();
      Console.Clear();
      Main();
    }
    else
    {

      Result result = Operate(userSelection, userNumbers.Num1, userNumbers.Num2);
      Console.WriteLine($"The result of {result.Operation} {userNumbers.Num1} and {userNumbers.Num2} is {result.Value}.");
      Console.WriteLine("Press any key to continue...");
      Console.ReadKey();
      Console.Clear();
      Main();
    }
  }
  else
  {
    Main();
  }
}

int MenuPrompt()
{
  Console.WriteLine(@"Welcome to Calculatron 3000!
1) Add two numbers
2) Subtract two numbers
3) Multiply two numbers
4) Divide two numbers
0) Exit");
  string userInput = Console.ReadLine();
  int userSelection = 99;

  if (userInput == "1" || userInput == "2" || userInput == "3" || userInput == "4" || userInput == "0")
  {
    userSelection = Int32.Parse(userInput);
  }
  else
  {
    Console.WriteLine("Invalid Selection");
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
    Console.Clear();
    MenuPrompt();
  }

  if (userSelection == 0)
  {
    Environment.Exit(0);
  }
  return userSelection;
}

NumbersInput NumberPrompt()
{
  Console.Clear();
  double firstNumber = 0;
  double secondNumber = 0;

  Console.Write("Please enter the first number: ");
  string num1Input = Console.ReadLine();

  Console.Write("Please enter the second number: ");
  string num2Input = Console.ReadLine();

  try
  {

    firstNumber = Double.Parse(num1Input);
    secondNumber = Double.Parse(num2Input);
    return new NumbersInput(
        firstNumber, secondNumber
    );
  }
  catch
  {
    Console.WriteLine("Invalid entry. Please try again.");
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
    Console.Clear();
    return null;
  }
}

Result Operate(int operation, double firstNumber, double secondNumber)
{
  Result answer = new Result("blank", 0);
  switch (operation)
  {
    case 1:
      answer.Value = Calculator.Add(firstNumber, secondNumber);
      answer.Operation = "adding";
      break;
    case 2:
      answer.Value = Calculator.Subtract(firstNumber, secondNumber);
      answer.Operation = "subtracting";
      break;
    case 3:
      answer.Value = Calculator.Multiply(firstNumber, secondNumber);
      answer.Operation = "multiplying";
      break;
    case 4:
      answer.Value = Calculator.Divide(firstNumber, secondNumber);
      answer.Operation = "dividing";
      break;
  }
  return answer;
}

public class NumbersInput
{
  public double Num1 { get; set; }
  public double Num2 { get; set; }

  public NumbersInput(double number1, double number2)
  {
    this.Num1 = number1;
    this.Num2 = number2;
  }
}

public static class Calculator
{
  public static double Add(double num1, double num2)
  {
    return num1 + num2;
  }
  public static double Subtract(double num1, double num2)
  {
    return num1 - num2;
  }
  public static double Multiply(double num1, double num2)
  {
    return num1 * num2;
  }
  public static double Divide(double num1, double num2)
  {
    return num1 / num2;
  }
}

public class Result
{
  public string Operation { get; set; }
  public double Value { get; set; }

  public Result(string operation, double value)
  {
    this.Operation = operation;
    this.Value = value;
  }
}