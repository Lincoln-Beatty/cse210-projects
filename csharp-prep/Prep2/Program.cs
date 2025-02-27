using System;

class Program{
    static void Main(string[] args){
        Console.Write("What is your grade percentage? %");
        string userinput = Console.ReadLine();
        int number = int.Parse(userinput);
        string letter_grade;
        if (number >= 70){
            if (number <= 80)
            {
                letter_grade = "C";
            }
            else if (number <= 90)
            {
                letter_grade = "B";
            }
            else if (number <= 100)
            {
                letter_grade = "A";
            }
            else{
                letter_grade = "invalid";
            }
            Console.WriteLine($"You passed with a {letter_grade}!");
        }
        else{
            if (number >= 60)
            {
                letter_grade = "C";
            }
            else 
            {
                letter_grade = "F";
            }
            Console.WriteLine($"You failed with a {letter_grade}.");
        }
    }
}