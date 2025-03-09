using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Net.Mail;

class Program{
    static void Main(string[] args){
        List<new_entry> journal_entries = new List<new_entry>();
        bool done = false;
        do{
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save");
        Console.WriteLine("5. Certain day's entry");
        Console.WriteLine("6. Quit");
        Console.Write("Journal Interface: ");
        int user_choice = int.Parse(Console.ReadLine());
        if (user_choice == 1){
            new_entry entry = new new_entry();
            journal_entries.Add(entry);
        }else if(user_choice == 2){
            Display display_the_journal = new Display(journal_entries);
        }else if(user_choice == 3){
            Load_jounal journal = new Load_jounal();
        }else if(user_choice == 4){
            save_data saver = new save_data();
            saver.saving(journal_entries);
        }else if(user_choice == 5){
            CertainEntry certain_entry = new CertainEntry();

        }else if(user_choice == 6){
            done = true;
        }
        }while (done != true);
    }
    
}
public class CertainEntry{
    private string[] lines = File.ReadAllLines("journal.txt");
    public class JournalEntry{
        public string _key;
        public string _value1;
        public string _value2;
        public JournalEntry(string key, string value1, string value2){
            _key = key.Trim();
            _value1 = value1.Trim();
            _value2 = value2.Trim();
        }
    }
    public CertainEntry(){
        DateTime journalDate;
        Console.WriteLine("What date would you like? (yyyy-mm-dd)");
        string journal_date = Console.ReadLine();
        bool isValidDate = DateTime.TryParseExact(journal_date, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out journalDate);
        if (!isValidDate)
        {
            Console.WriteLine("Invalid date format. Please try again.");
            return;
        }
        string formattedDate = journalDate.ToString("yyyy-MM-dd");


        List<JournalEntry> dictionary = new List<JournalEntry>();

        foreach (string line in lines){
            string[] parts = line.Split(" # ");
            string date = parts[0].Trim();
            string prompt = parts[1].Trim();
            string entry = parts[2].Trim();
            dictionary.Add(new JournalEntry($"{date}", $"{prompt}", $"{entry}"));
        }

        bool found = false;
        foreach (var entry in dictionary)
        {
            if (entry._key == formattedDate)
            {
                Console.WriteLine($"Date: {entry._key}");
                Console.WriteLine($"Prompt: {entry._value1}");
                Console.WriteLine($"Entry: {entry._value2}");
                found = true;
            }
        }
        if (!found)
        {
            Console.WriteLine("No journal entry found for this date.");
        }
    }
}
public class save_data{
    public void saving(List<new_entry> journal_entries){
        foreach (new_entry entry in journal_entries){
            //save entries code
            string formattedEntry = $"{entry._date} # {entry._prompt} # {entry._entry_text}";
            using (StreamWriter writer = new StreamWriter("journal.txt", true))
            {
                writer.WriteLine(formattedEntry);
            }
            Console.WriteLine("Journal entry saved successfully!");
        }
    }
        
}
public class Load_jounal{
    private string[] lines = File.ReadAllLines("journal.txt");
    public Load_jounal(){
        Console.WriteLine("----Journal Entries---");
        foreach (string line in lines){
            string[] parts = line.Split(" # ");
            string date = parts[0];
            string prompt = parts[1];
            string entry_text = parts[2];
            Console.WriteLine($"Date: {date}");
            Console.WriteLine($"Prompt: {prompt}");
            Console.WriteLine($"Entry: {entry_text}");
        }
    }
}
public class Display{
    public Display(List<new_entry> journal_entries){
        Console.WriteLine("----Journal Entries------");
        foreach (new_entry entry in journal_entries){
            Console.WriteLine(entry.entry_details());
        }
    }
}
public class new_entry{
    private List<string> prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What is something new I learned today?",
        "What is one small moment of joy I experienced today?",
        "How did I step outside my comfort zone today?",
        "What is one thing I am grateful for today?",
        "What is a challenge I faced today, and how did I handle it?"
    };
    public string _prompt { get; }
    public string _date { get; }
    public string _entry_text { get; }

    public new_entry(){
        Random random = new Random();
        int index = random.Next(prompts.Count);
        _prompt = prompts[index];

        _date = DateTime.Now.ToString("yyyy-MM-dd");
        Console.WriteLine($"Today's date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.Write("Entry: ");
        _entry_text = Console.ReadLine();
    }
    public new_entry(string date, string prompt, string entry_text){
        _date = date;
        _prompt = prompt;
        _entry_text = entry_text;
    }
    
    public string entry_details()
    {
        return $"[{_date}] {_prompt}\n{_entry_text}";
    }
}