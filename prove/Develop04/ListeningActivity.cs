using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

public class Listening : Activity{
    private List<string> _questions = new List<string> {"Who are people that you appreciate?",
        "What are personal strengths of yours?", "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?", "Who are some of your personal heroes?"};
    public Listening(int seconds){
        Random random = new Random();
        string random_prompt = _questions[random.Next(_questions.Count)];
        Console.WriteLine("List as many responses as you can to the following prompt:\n");
        Console.WriteLine($"--- {random_prompt} ---\n");
        Console.WriteLine("You may begin in: ");
        CountDown();
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        do{
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)){
                Console.WriteLine();
            }
        } while (stopwatch.Elapsed.TotalSeconds < seconds);
    }
}