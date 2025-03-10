public class Fraction{
    private int _first;
    private int _second;
    public Fraction(){
        _first = 1;
        _second = 1;
    }
    public Fraction(int first){
        _first = first;
        _second = 1;
    }
    public Fraction(int first, int second){
        _first = first;
        _second = second != 0 ? second : 1;
    }
    public void Display(){
        double answer = (double)_first / _second;
        Console.WriteLine($"Answer: {answer:F4}");
    }
    public void DisplayInput(){
        Console.WriteLine($"{_first}/{_second}");
    }
}