using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

class Program{
    static void Main(string[] args){
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        List<int> numbers = new List<int>();
        int number;
        do{
            
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());
            if (number != 0){
                numbers.Add(number);
            }
        } while (number != 0);
        int sum = numbers.Sum();
        Console.WriteLine($"The sum is: {sum}");
        int average = sum / numbers.Count();
        Console.WriteLine($"The average is: {average}");
        int largest = numbers.Max();
        Console.WriteLine($"The largest number is: {largest}");
  //The sum is: 131
  //The average is: 18.714285714285715
  //The largest number is: 48");
    }
}