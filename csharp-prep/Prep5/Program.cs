using System;

class Program{
    static void Main(string[] args){
        welcome();
        string name = Your_name();
        int number = Fav_number();
        int square = Squared(number);
        Display_results(name, square);
    }
    static void welcome(){
        Console.WriteLine("Welcome to the program!");
    }
    static string Your_name(){
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }
    static int Fav_number(){
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }
    static int Squared(int number){
        int square = number * number;
        return square;
    }
    static void Display_results(string name, int square){
        Console.WriteLine($"{name}, the square of your number is {square}");
    }
}