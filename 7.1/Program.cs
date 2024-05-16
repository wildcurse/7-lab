using System;

public class Car
{
    public string Make { get; }
    public string Model { get; }
    public string LicensePlate { get; }
    public string Color { get; }
    public bool IsStarted { get; private set; }
    public int Speed { get; private set; }
    public int Gear { get; private set; } 

    public Car(string make, string model, string licensePlate, string color)
    {
        Make = make;
        Model = model;
        LicensePlate = licensePlate;
        Color = color;
        IsStarted = false;
        Speed = 0;
        Gear = 0;
    }

    public void Start()
    {
        if (Gear != 0 && Gear != 1)
        {
            Console.WriteLine("Cannot start the car. Gear must be in neutral (0) or first (1).");
            return;
        }
        IsStarted = true;
        Console.WriteLine("Car started.");
    }

    public void Stop()
    {
        IsStarted = false;
        Speed = 0;
        Console.WriteLine("Car stopped.");
    }

    public void Accelerate()
    {
        if (!IsStarted)
        {
            Console.WriteLine("Cannot accelerate. The car is not started.");
            return;
        }
        if (Gear == 0)
        {
            Console.WriteLine("Cannot accelerate. The car is in neutral.");
            return;
        }

        Speed += 10;
        Console.WriteLine($"Accelerating. Speed is now {Speed} km/h.");
    }

    public void Brake()
    {
        if (Speed > 0)
        {
            Speed -= 10;
            Console.WriteLine($"Braking. Speed is now {Speed} km/h.");
        }
        else
        {
            Console.WriteLine("Car is already stopped.");
        }
    }

    public void ChangeGear(int newGear)
    {
        if (!IsStarted)
        {
            Console.WriteLine("Cannot change gear. The car is not started.");
            return;
        }

        if (newGear < -1 || newGear > 5)
        {
            Console.WriteLine("Invalid gear.");
            return;
        }

        if (newGear == -1 && Speed != 0)
        {
            Console.WriteLine("Cannot change to reverse gear while moving.");
            Stop();
            return;
        }

        if ((newGear == 1 && (Speed < 0 || Speed > 30)) ||
            (newGear == 2 && (Speed < 20 || Speed > 50)) ||
            (newGear == 3 && (Speed < 40 || Speed > 70)) ||
            (newGear == 4 && (Speed < 60 || Speed > 90)) ||
            (newGear == 5 && (Speed < 80 || Speed > 120)))
        {
            Console.WriteLine($"Invalid speed for {newGear} gear. The car is stopping.");
            Stop();
            return;
        }

        Gear = newGear;
        Console.WriteLine($"Gear changed to {Gear}.");
    }
}

// Пример использования
public class Program
{
    public static void Main()
    {
        Car mercedes = new Car("Mercedes", "Maybach S Class", "MB1234", "Black");

        mercedes.Start();          // Завести машину
        mercedes.ChangeGear(1);    // Поменять передачу на 1
        mercedes.Accelerate();     // Разогнаться
        mercedes.ChangeGear(2);    // Поменять передачу на 2
        mercedes.Accelerate();     // Разогнаться
        mercedes.Brake();          // Притормозить
        mercedes.ChangeGear(1);    // Поменять передачу на 1
        mercedes.Stop();           // Заглушить машину
    }
}
