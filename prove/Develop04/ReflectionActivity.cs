public class Reflection : Activity{
    private List<string> questions = new List<string> {"Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.", "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."};
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
            if (rotations <= reflection_questions.Count){
                for (int i = 0; i < rotations; i++){
                    int random_reflection;
                    do{
                        random_reflection = random.Next(reflection_questions.Count);
                    } while (indexes.Contains(random_reflection));
                    indexes.Add(random_reflection);
                }
            }else{
                int times = rotations / reflection_questions.Count;
                for (int i = 0; i < times; i++){
                    foreach (string b in reflection_questions){
                        indexes.Add(reflection_questions.IndexOf(b));
                    }
                }
                int remainder = rotations % reflection_questions.Count();
                for (int i = 0; i < remainder; i++){
                    int random_reflection;
                    random_reflection = random.Next(reflection_questions.Count);
                    indexes.Add(random_reflection);
                }
            }
        }
        foreach (int b in indexes){
            Console.Write($"{reflection_questions[b]} ");
            SpinnerThing();
            SpinnerThing();
            Console.WriteLine();
        }
    }
}