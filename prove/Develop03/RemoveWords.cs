public class RemoveWords{
    public RemoveWords(List<string> scripture_list,  List<int> remaining_list){
        Random random = new Random();
        for (int i = 0; i < 3; i++){
            int word_index;
            int scripture_index;
            if (remaining_list.Count > 0){
            word_index = random.Next(remaining_list.Count);
            scripture_index = remaining_list[word_index];
            remaining_list.Remove(scripture_index);
            scripture_list[scripture_index] = new string('-', scripture_list[scripture_index].Length);
            }
        }
    }
}
