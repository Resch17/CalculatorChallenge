using System;
using System.Threading;

Main();

void Main()
{
  int userSelection = MenuPrompt();
  NumbersInput userNumbers = NumberPrompt();
  int result = Operate(userSelection, userNumbers.Num1, userNumbers.Num2);
  Console.WriteLine($"Your answer is {result}.");
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
    Thread.Sleep(2000);
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
  Console.Write("Please enter the first number: ");
  string num1Input = Console.ReadLine();
  Console.Write("Please enter the second number: ");
  string num2Input = Console.ReadLine();
  int firstNumber = Int32.Parse(num1Input);
  int secondNumber = Int32.Parse(num2Input);

  return new NumbersInput(
      firstNumber, secondNumber
  );
}

int Operate(int operation, int firstNumber, int secondNumber)
{
  int result = 0;
  switch (operation)
  {
    case 1:
      result = firstNumber + secondNumber;
      break;
    case 2:
      result = firstNumber - secondNumber;
      break;
    case 3:
      result = firstNumber * secondNumber;
      break;
    case 4:
      result = firstNumber / secondNumber;
      break;
  }
  return result;
}

public class NumbersInput
{
  public int Num1 { get; set; }
  public int Num2 { get; set; }

  public NumbersInput(int number1, int number2)
  {
    this.Num1 = number1;
    this.Num2 = number2;
  }
}