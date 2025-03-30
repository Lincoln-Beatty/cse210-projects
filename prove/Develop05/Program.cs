using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Security.Cryptography.X509Certificates;
class Program{
    static void Main(string[] args){
        List<Goal> goalEntries = new List<Goal>();
        List<int> points = new List<int>();
        bool done = false;
        do{
            Console.WriteLine("1. Create new goal");
            Console.WriteLine("2. List goals");
            Console.WriteLine("3. Load goals");
            Console.WriteLine("4. Save goals");
            Console.WriteLine("5. Record event");
            Console.WriteLine("6. Quit");
            Console.Write("Goal Interface: ");
            int userChoice;
            if (!int.TryParse(Console.ReadLine(), out userChoice)){
                Console.WriteLine("Invalid input. Please enter a number between 1 and 6.");
                continue;
            }
            switch (userChoice){
                case 1:
                    Goal newGoal = CreateNewGoal();
                    if (newGoal != null){
                        goalEntries.Add(newGoal);
                        Console.WriteLine("Goal added successfully!");
                    }
                    break;
                case 2:
                    Display display = new Display();
                    display.ShowGoals(goalEntries);
                    break;
                case 3:
                    LoadGoals loader = new LoadGoals();
                    loader.Load(goalEntries);
                    break;
                case 4:
                    SaveData saver = new SaveData();
                    saver.Save(goalEntries);
                    break;
                case 5:
                    RecordEvent recorder = new RecordEvent();
                    recorder.Record(goalEntries, points);
                    break;
                case 6:
                    done = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        } while (!done);
    }
    static Goal CreateNewGoal(){
        Console.WriteLine("Select goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Choice: ");
        int goalChoice;
        if (!int.TryParse(Console.ReadLine(), out goalChoice) || goalChoice < 1 || goalChoice > 3){
            Console.WriteLine("Invalid input.");
            return null;
        }
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();
        Console.Write("Enter goal points: ");
        int points = int.Parse(Console.ReadLine());
        switch (goalChoice){
            case 1:
                return new SimpleGoal(name, description, points);
            case 2:
                return new EternalGoal(name, description, points);
            case 3:
                Console.Write("Enter number of times needed to complete: ");
                int times = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                return new ChecklistGoal(name, description, points, times, bonus);
            default:
                return null;
        }
    }
}
//--------------------------------------------------------------------------------------------------
public abstract class Goal{
    protected string _name;
    protected string _description;
    protected int _points;
    public Goal(string name, string description, int points){
        _name = name;
        _description = description;
        _points = points;
    }
    public virtual string DisplayDetails(){
        return $"{_name} ({_description}) - Points: {_points}";
    }
    public abstract int Complete();
}
//--------------------------------------------------------------------------------------------------
public class SimpleGoal : Goal{
    private bool _isCompleted;
    public SimpleGoal(string name, string description, int points) : base(name, description, points){
        _isCompleted = false;
    }
    public override int Complete(){
        _isCompleted = true;
        Console.WriteLine($"Goal '{_name}' completed! Earned {_points} points.");
        return _points;
    }
    public override string DisplayDetails(){
        return $"{(_isCompleted ? "[X]" : "[ ]")} " + base.DisplayDetails();
    }
}
//--------------------------------------------------------------------------------------------------
public class EternalGoal : Goal{
    public EternalGoal(string name, string description, int points) : base(name, description, points) { }
    public override int Complete(){
        Console.WriteLine($"Eternal goal '{_name}' recorded! Earned {_points} points.");
        return _points;
    }
}

//--------------------------------------------------------------------------------------------------
public class ChecklistGoal : Goal{
    private int _timesNeeded;
    private int _timesCompleted;
    private int _bonusPoints;
    public ChecklistGoal(string name, string description, int points, int timesNeeded, int bonusPoints)
        : base(name, description, points){
        _timesNeeded = timesNeeded;
        _bonusPoints = bonusPoints;
        _timesCompleted = 0;
    }
    public override int Complete(){
        _timesCompleted++;
        Console.WriteLine($"Progress: {_timesCompleted}/{_timesNeeded}");
        if (_timesCompleted >= _timesNeeded){
            Console.WriteLine($"Checklist goal '{_name}' completed! Earned {_points + _bonusPoints} points.");
        }
        return _points + _bonusPoints;
    }
    public override string DisplayDetails(){
        return $"[✔ {_timesCompleted}/{_timesNeeded}] " + base.DisplayDetails();
    }
}
//--------------------------------------------------------------------------------------------------
public class Display{
    public void ShowGoals(List<Goal> goals){
        Console.WriteLine("------Goals------");
        foreach (Goal goal in goals){
            Console.WriteLine(goal.DisplayDetails());
        }
    }
}
//--------------------------------------------------------------------------------------------------
public class LoadGoals{
    public void Load(List<Goal> goals){
        if (!File.Exists("goals.txt")){
            Console.WriteLine("No saved goals found.");
            return;
        }
        string[] lines = File.ReadAllLines("goals.txt");
        foreach (string line in lines){
            Console.WriteLine(line);
        }
    }
}
//--------------------------------------------------------------------------------------------------
public class SaveData{
    public void Save(List<Goal> goals){
        using (StreamWriter writer = new StreamWriter("goals.txt", false)){
            foreach (Goal goal in goals){
                writer.WriteLine(goal.DisplayDetails());
            }
        }
        Console.WriteLine("Goals saved successfully!");
    }
}
//--------------------------------------------------------------------------------------------------
public class RecordEvent{
    public void Record(List<Goal> goals, List<int> points){
        Console.WriteLine("Select a goal to record progress:");
        for (int i = 0; i < goals.Count; i++){
            Console.WriteLine($"{i + 1}. {goals[i].DisplayDetails()}");
        }
        int choice;
        if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > goals.Count){
            Console.WriteLine("Invalid choice.");
            return;
        }
        points.Add(goals[choice - 1].Complete());
        int sum = 0;
        foreach (int point in points){
            sum += point;
        }
        Console.WriteLine($"Points = {sum}");
    }
}