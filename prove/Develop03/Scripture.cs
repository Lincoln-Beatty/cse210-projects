public class Scripture{
    private List<string> scripture_list;
    public Scripture(){
        scripture_list = new List<string>
        {
            "And", "if", "men", "come", "unto", "me", "I", "will", "show", "unto", "them", "their", "weakness.",
            "I", "give", "unto", "men", "weakness", "that", "they", "may", "be", "humble;", "and", "my", "grace", 
            "is", "sufficient", "for", "all", "men", "that", "humble", "themselves", "before", "me;", "for", "if",
            "they", "humble", "themselves", "before", "me,", "and", "have", "faith", "in", "me,", "then", "will",
            "I", "make", "weak", "things", "become", "strong", "unto", "them."
        };
    }
    public List<string> GetScripture(){
        return scripture_list;
    }
}