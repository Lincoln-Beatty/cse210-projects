using System;
class Program{
    static void Main(string[] args){
        Console.Write("What divition would you like? ");
        string user_input = Console.ReadLine();
        string[] parts = user_input.Split("/");
        if (parts.Length == 1){
            int first = int.Parse(parts[0]);
            Fraction f = new Fraction(first);
            f.Display();
        }else if (parts.Length == 2){
            int first = int.Parse(parts[0]);
            int second = int.Parse(parts[1]);
            Fraction f = new Fraction(first, second);
            f.Display();
        }else if (parts.Length == 0){
            Fraction f = new Fraction();
            f.Display();
        }else{
            Console.WriteLine("Sorry but you need to enter in number/number format.");
            return;
        }
    }
}
