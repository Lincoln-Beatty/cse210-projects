using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
class Program{
    static void Main(string[] args){
        bool done = false;
        do{
        Console.WriteLine("Menu:");
        Console.WriteLine("1. Breathing activity");
        Console.WriteLine("2. Reflection activity");
        Console.WriteLine("3. Listening activity");
        Console.WriteLine("4. Quit");
        int user_choice = int.Parse(Console.ReadLine());
        if (user_choice == 1){

            Activity breathing_var = new Activity();
            string details = @"This activity will help you relax by walking your through breathing in and out slowly. 
            Clear your mind and focus on your breathing.";
            string activity = "Breathing Activity";
            int seconds = breathing_var.DisplayMessage(activity, details);
            Breathing preform_activity = new Breathing(seconds);
            breathing_var.DisplayGoodbye(activity, seconds);

        }else if (user_choice == 2){

            Activity reflection_var = new Activity();
            string details = @"This activity will help you reflect on times in your life when you have shown strength and resilience. 
            This will help you recognize the power you have and how you can use it in other aspects of your life.";
            string activity = "Reflection Activity";
            int seconds = reflection_var.DisplayMessage(activity, details);
            Reflection preform_activity = new Reflection(seconds);
            reflection_var.DisplayGoodbye(activity, seconds);

        }else if (user_choice == 3){

            Activity listening_var = new Activity();
            string details = @"This activity will help you reflect on the good things in your life by having you list as many things 
            as you can in a certain area.";
            string activity = "Listening Activity";
            int seconds = listening_var.DisplayMessage(activity, details);
            Listening prefrom_activity = new Listening(seconds);
            listening_var.DisplayGoodbye(activity, seconds);

        }else if (user_choice == 4){
            done = true;
        }
        }while (!done);
    }
}
//---------------------------------------------------------------------------------------------
public class Activity{
    public Activity(){}
    public int DisplayMessage(string activity, string details){
        string welcome = $"Welcome to the {activity}.";
        Console.WriteLine($"{welcome}\n");
        Console.WriteLine($"{details}\n");
        string time = "How long, in seconds, would you like your session to be? (devisible by 10) ";
        Console.Write(time);
        int seconds = int.Parse(Console.ReadLine());
        return seconds;
    }
    public void SpinnerThing(){
        List<string> animation_list = new List<string> {"\\", "|", "/", "-", "\\", "|", "/", "-", "\\", "|"};
        foreach (string s in animation_list){
            Console.Write(s);
            Thread.Sleep(500);
            Console.Write("\b \b");
        }
    }
    public void CountDown(){
        for (int b = 5; b > 0; b--){
            Console.Write(b);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }
    public void DisplayGoodbye(string activity, int seconds){
        Console.WriteLine("\nWell done!");
        SpinnerThing();
        Console.WriteLine();
        Console.WriteLine($"You have completed {seconds} seconds of the {activity}.");
        SpinnerThing();
        Console.WriteLine();
    }
}
//---------------------------------------------------------------------------------------------
public class Breathing : Activity{
    public Breathing(int seconds){
        int rotations = seconds / 5;
        int math = rotations / 2;
        Console.WriteLine("Get ready...");
        SpinnerThing();
        Console.WriteLine();
        for (int i = 0; i < math; i++){
            Console.Write("Breath in...");
            CountDown();
            Console.Write("Breath out...");
            CountDown();
            Console.WriteLine();
        }
    }
}
//---------------------------------------------------------------------------------------------
public class Reflection : Activity{
    private List<string> questions = new List<string> {"Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.", "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless.}"};
    private List<string> reflection_questions = new List<string> {"Why was this experience meaningful to you?",
        "Have you ever done anything like this before?", "How did you get started?",
        "How did you feel when it was complete?", "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?", "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?", "How can you keep this experience in mind in the future?"};
    private List<int> indexes = new List<int>();
    public Reflection(int seconds){
        Console.WriteLine("Get ready...");
        SpinnerThing();
        Console.WriteLine("\nConsider the following prompt:\n");
        Random random = new Random();
        string random_prompt = questions[random.Next(questions.Count)];
        Console.WriteLine($"--- {random_prompt} ---\n");
        Console.Write("When you think of something, please press enter. ");
        string input = Console.ReadLine();
        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("\nNow ponder on each of the following questions as they relate to this expirience.");
            Console.Write("You may begin in: ");
            CountDown();
            Console.WriteLine();
            int rotations = seconds / 10;
            for (int i = 0; i < rotations; i++){
                int random_reflection;
                do{
                    random_reflection = random.Next(reflection_questions.Count);
                } while (indexes.Contains(random_reflection));
                indexes.Add(random_reflection);
            }
            foreach (int b in indexes){
                Console.Write($"{reflection_questions[b]} ");
                SpinnerThing();
                SpinnerThing();
                Console.WriteLine();
            }
        }
    }
}
//---------------------------------------------------------------------------------------------
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