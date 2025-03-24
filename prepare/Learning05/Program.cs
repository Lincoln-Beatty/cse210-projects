using System;
using System.Drawing;
class Program{
    static void Main(string[] args){
        List<Shape> shapes = new List<Shape>();
        shapes.Add(new Square(4, "blue"));       
        shapes.Add(new Rectangle(4, 6, "red")); 
        shapes.Add(new Circle(1, "orange"));      
        foreach (Shape shape in shapes){
            Console.WriteLine($"Shape Color: {shape.GetColor()}, Area: {shape.GetArea()}");
        }
    }
}
public class Shape{
    private string _color { get; set; }
    public string GetColor(){
        return _color;
    }
    public Shape(string color){
        _color = color;
    }
    public virtual double GetArea(){
        return 0;
    }
}
public class Rectangle : Shape{
    private double _width;
    private double _length;
    public Rectangle(double width, double length, string color) : base(color){
        _width = width;
        _length = length;
    }
    public override double GetArea(){
        return _width * _length;
    }
}
public class Square : Shape{
    private double _side;
    public Square(double side, string color) : base(color){
        _side = side;
    }
    public override double GetArea(){
        return _side * _side;
    }
}
public class Circle : Shape{
    private double _radius;
    public Circle(double radius, string color) : base(color){
        _radius = radius;
    }
    public override double GetArea(){
        double area = Math.PI * Math.Pow(_radius, 2);
        return area;
    }
}