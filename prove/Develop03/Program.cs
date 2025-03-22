using System;
using System.Runtime.InteropServices;

class Program{
    static void Main(string[] args){
        List<string> scripture_list = new List<string>
        {
            "And", "if", "men", "come", "unto", "me", "I", "will", "show", "unto", "them", "their", "weakness.",
            "I", "give", "unto", "men", "weakness", "that", "they", "may", "be", "humble;", "and", "my", "grace", 
            "is", "sufficient", "for", "all", "men", "that", "humble", "themselves", "before", "me;", "for", "if",
            "they", "humble", "themselves", "before", "me,", "and", "have", "faith", "in", "me,", "then", "will",
            "I", "make", "weak", "things", "become", "strong", "unto", "them."
        };
        List<int> remaining_list = new List<int>
        {
            0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 
            21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 
            39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57
        };
        bool done = false;
        foreach (string word in scripture_list){
            Console.Write($"{word} ");
        }
        do{
            Console.WriteLine();
            string user_input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(user_input)){
                RemoveWords remove = new RemoveWords(scripture_list, remaining_list);
                foreach (string word in scripture_list){
                    Console.Write($"{word} ");
                }
                
            }else if (user_input.Trim().ToLower() == "p"){
                done = true;
            }
        }while (!done);
    }
}

public class RemoveWords{
    public RemoveWords(List<string> scripture_list,  List<int> remaining_list){
        Random random = new Random();
        for (int i = 0; i < 3; i++){
            int word_index;
            int scripture_index;
            if (remaining_list.Count > 0){
            word_index = random.Next(remaining_list.Count);
            scripture_index = remaining_list[word_index];
            Console.WriteLine(scripture_index);
            remaining_list.Remove(scripture_index);
            scripture_list[scripture_index] = new string('-', scripture_list[scripture_index].Length);
            }
        }
    }
}