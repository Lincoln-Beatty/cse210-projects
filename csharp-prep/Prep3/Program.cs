using System;
using System.Collections.Concurrent;
using System.Xml.Serialization;

class Program{
    static void Main(string[] args){
        Random random = new Random();
        int random_number = random.Next(1, 100);
        // Console.Write("What is the magic number? ");
        int magic_number = random_number;
        bool correct = false;
        do{
            Console.Write("What is your guess? ");
            int guess = int.Parse(Console.ReadLine());
            if (guess > magic_number){
                Console.WriteLine("Lower");
            }else if (guess < magic_number){
                Console.WriteLine("Higher");
            }else{
                correct = true;
                Console.WriteLine("You guessed it!");
            }
        } while (correct != true);
    }
}