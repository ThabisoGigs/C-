using System;

public class Cars
{
    public string Color {get; set;}
    public string Model {get; set;}

    public Cars(string color, string model)
    {
        Color = color;
        Model = model;
    }
    public void Start()
    {
        Console.WriteLine($"The {Model}+{Color} car is now started.");
    }

    public void Stop()
    {
        Console.WriteLine($"The {Model}+{Color} car has been stopped");
    }
}
class Program
{
    static void Main()
    {
        Cars myCar = new Cars("Blue", "Mercedes");

        myCar.Start();

        myCar.Stop();
    }

}