# Calculator Challenge

## Part One
Build a console application that presents the user with the following menu:

```
Welcome to Calculatron 3000!
1) Add two numbers
2) Subtract two numbers
3) Multiply two numbers
4) Divide two numbers
0) Exit

> _
```
When the user selects an option (1-4) they should be prompted to enter two numbers, one at a time.
```
Please enter the first number: _
Please enter the second number: _
```
After entering the second number the program should calculate the answer and display it to the user. The message should remind the user of the numbers they entered and the operation they chose.

For example of the user choose subtraction and entered numbers `5` and `2`, they should see this message
```
The result of subtracting 5 and 2 is 3
```
The user should be allowed to continue performing calculations until choosing the `0) Exit` option.

### Notes
* Convert text to ints with [Int32.Parse()](https://docs.microsoft.com/en-us/dotnet/api/system.int32.parse?view=netcore-2.2)
* Use a `try/catch` when parsing an int. If parsing fails, inform the user and prompt them to enter a number again.
* Use a `try/catch` to handle divide by zero errors.
* Make a separate `Calculator` class that has methods for each operation. The `Program` class should be responsible for user input and displaying output while the `Calculator` class does the math. (see: [Single Responsibility Principle](https://en.wikipedia.org/wiki/Single_responsibility_principle))


## Part Two
Enhancing user experience. 

Instead of prompting the user twice for numbers, prompt them only once.
```
Please enter two numbers with a space in between: _
```
You should not have to change your `Calculator` class to make this enhancement.


## Part Three
Add `Square` and `Square Root` operations to your calculator.

## Part Four
Add an _advanced_ option that lets users enter a simple math formula and calculates the answer.

For example:
```
2 * 2
```