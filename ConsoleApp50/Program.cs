using System;

public interface IBuilder
{
    void Reset();
    void SetSeats(int number);
    void SetEngine(string engine);
    void SetTripComputer();
    void SetGPS();
}


public class Car
{
    public int Seats { get; set; }
    public string Engine { get; set; }
    public bool TripComputer { get; set; }
    public bool GPS { get; set; }

    public override string ToString()
    {
        return $"Автомобиль: \nSeats: {Seats} \nEngine: {Engine} \nTrip Computer: {TripComputer} \nGPS: {GPS}";
    }
}

public class Manual
{
    public string Description { get; private set; } = "";

    public void AddDescription(string text) => Description += text + "\n";

    public override string ToString() => Description;
}

public class CarBuilder : IBuilder
{
    private Car _car = new Car();

    public void Reset() => _car = new Car();

    public void SetSeats(int number) => _car.Seats = number;
    public void SetEngine(string engine) => _car.Engine = engine;
    public void SetTripComputer() => _car.TripComputer = true;
    public void SetGPS() => _car.GPS = true;

    public Car GetResult() => _car;
}

public class CarManualBuilder : IBuilder
{
    private Manual _manual = new Manual();

    public void Reset() => _manual = new Manual();

    public void SetSeats(int number) => _manual.AddDescription($"Количество сидений: {number}");
    public void SetEngine(string engine) => _manual.AddDescription($"Двигатель: {engine}");
    public void SetTripComputer() => _manual.AddDescription("Включен Trip Computer");
    public void SetGPS() => _manual.AddDescription("Включен GPS");

    public Manual GetResult() => _manual;
}

public class Director
{
    public void MakeSUV(IBuilder builder)
    {
        builder.Reset();
        builder.SetSeats(5);
        builder.SetEngine("SUV Engine");
        builder.SetGPS();
    }

    public void MakeSportsCar(IBuilder builder)
    {
        builder.Reset();
        builder.SetSeats(2);
        builder.SetEngine("Sport Engine");
        builder.SetTripComputer();
        builder.SetGPS();
    }
}

class Program
{
    static void Main()
    {
        var director = new Director();


        CarBuilder carBuilder = new CarBuilder();
        director.MakeSportsCar(carBuilder);
        Car sportsCar = carBuilder.GetResult();
        Console.WriteLine(sportsCar);

        CarManualBuilder manualBuilder = new CarManualBuilder();
        director.MakeSportsCar(manualBuilder);
        Manual sportsManual = manualBuilder.GetResult();
        Console.WriteLine(sportsManual);
    }
}
