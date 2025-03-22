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