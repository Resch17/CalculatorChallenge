using System;

Main();

void Main()
{
  int userSelection = MenuPrompt();
  NumbersInput userNumbers = NumberPrompt(userSelection);
  if (userNumbers != null)
  {
    Result result = Operate(userSelection, userNumbers.Num1, userNumbers.Num2, userNumbers.Operator);
    if (userSelection == Operations.DIV && userNumbers.Num2 == 0)
    {
      Console.WriteLine("Nah, you can't divide by zero.");
    }
    else if (userSelection <= Operations.ADV)
    {
      Console.WriteLine(result.Message);
    }
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
    Console.Clear();
    Main();
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
5) Square one number
6) Square root of one number
7) ADVANCED MODE
0) Exit");
  string userInput = Console.ReadLine();
  int userSelection = 99;
  if (userInput == "1" || userInput == "2" || userInput == "3" || userInput == "4" || userInput == "5" || userInput == "6" || userInput == "7" || userInput == "0")
  {
    userSelection = Int32.Parse(userInput);
  }
  else
  {
    InvalidEntry();
    MenuPrompt();
  }
  if (userSelection == 0)
  {
    Console.WriteLine("Goodbye!");
    Environment.Exit(0);
  }
  return userSelection;
}

NumbersInput NumberPrompt(int userMode)
{
  Console.Clear();
  if (userMode <= Operations.DIV)
  {
    double firstNumber = 0;
    double secondNumber = 0;
    Console.Write("Please enter two numbers with a space in-between: ");
    string userInput = Console.ReadLine();
    try
    {
      string[] words = userInput.Split(' ');
      firstNumber = Double.Parse(words[0]);
      secondNumber = Double.Parse(words[1]);
      return new NumbersInput(
          firstNumber, secondNumber, null
      );
    }
    catch
    {
      InvalidEntry();
      return null;
    }
  }
  else if (userMode == Operations.SQ || userMode == Operations.SQRT)
  {
    double firstNumber = 0;
    Console.Write("Please enter the number: ");
    string userInput = Console.ReadLine();
    try
    {
      firstNumber = Double.Parse(userInput);
      return new NumbersInput(firstNumber, 0, null);
    }
    catch
    {
      InvalidEntry();
      return null;
    }
  }
  else if (userMode == Operations.ADV)
  {
    double firstNumber = 0;
    double secondNumber = 0;
    string op = null;
    Console.Write("Please enter two numbers with spaces and a valid operator in-between (e.g. \"2 + 2\"): ");
    string userInput = Console.ReadLine();
    try
    {
      string[] splitUp = userInput.Split(' ');
      firstNumber = Double.Parse(splitUp[0]);
      op = splitUp[1];
      secondNumber = Double.Parse(splitUp[2]);
      if (op != "+" && op != "-" && op != "*" && op != "/")
      {
        throw new Exception("Invalid operator.");
      }
      else
      {
        return new NumbersInput(firstNumber, secondNumber, op);
      }
    }
    catch
    {
      InvalidEntry();
      return null;
    }
  }
  else
  {
    return null;
  }
}

Result Operate(int operation, double firstNumber, double secondNumber, string userOperator)
{
  Result answer = new Result(null, 0, null);
  string stdMessage(string op, double result)
  {
    return $"The result of {op} {firstNumber} and {secondNumber} is {result}.";
  }

  switch (operation)
  {
    case Operations.ADD:
      answer.Value = Calculator.Add(firstNumber, secondNumber);
      answer.Operation = "adding";
      break;
    case Operations.SUB:
      answer.Value = Calculator.Subtract(firstNumber, secondNumber);
      answer.Operation = "subtracting";
      break;
    case Operations.MULT:
      answer.Value = Calculator.Multiply(firstNumber, secondNumber);
      answer.Operation = "multiplying";
      break;
    case Operations.DIV:
      answer.Value = Calculator.Divide(firstNumber, secondNumber);
      answer.Operation = "dividing";
      break;
    case Operations.SQ:
      answer.Value = Calculator.Square(firstNumber);
      answer.Message = $"The result of squaring {firstNumber} is {answer.Value}.";
      break;
    case Operations.SQRT:
      answer.Value = Calculator.Sqrt(firstNumber);
      answer.Message = $"The square root of {firstNumber} is {answer.Value}.";
      break;
    case Operations.ADV:
      int opInput = 0;
      opInput = userOperator switch
      {
        "+" => Operations.ADD,
        "-" => Operations.SUB,
        "*" => Operations.MULT,
        "/" => Operations.DIV,
        _ => 0
      };
      answer = Operate(opInput, firstNumber, secondNumber, userOperator);
      break;
  }
  if (operation <= Operations.DIV)
  {
    answer.Message = stdMessage(answer.Operation, answer.Value);
  }
  return answer;
}

void InvalidEntry()
{
  Console.WriteLine("Invalid entry. Please try again.");
  Console.WriteLine("Press any key to continue...");
  Console.ReadKey();
  Console.Clear();
}

public class NumbersInput
{
  public double Num1 { get; set; }
  public double Num2 { get; set; }
  public string Operator { get; set; }
  public NumbersInput(double number1, double number2, string op)
  {
    this.Num1 = number1;
    this.Num2 = number2;
    this.Operator = op;
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
  public static double Square(double num1)
  {
    return num1 * num1;
  }
  public static double Sqrt(double num1)
  {
    return Math.Sqrt(num1);
  }
}

public class Result
{
  public string Operation { get; set; }
  public double Value { get; set; }
  public string Message { get; set; }
  public Result(string operation, double value, string message)
  {
    this.Operation = operation;
    this.Value = value;
    this.Message = message;
  }
}

public class Operations
{
  public const int ADD = 1;
  public const int SUB = 2;
  public const int MULT = 3;
  public const int DIV = 4;
  public const int SQ = 5;
  public const int SQRT = 6;
  public const int ADV = 7;
}