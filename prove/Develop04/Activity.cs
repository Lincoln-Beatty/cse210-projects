public class Activity{
    public Activity(){
        
    }
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