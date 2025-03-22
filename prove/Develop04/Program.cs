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