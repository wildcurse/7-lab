using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        List<Car> cars = new List<Car>
        {
            new Car("Mercedes-Benz Maybach"),
            new Car("Mercedes 600"),
            new Car("BMW M5 Competition VI")
        };

        Console.WriteLine("Выберите машину:");
        for (int i = 0; i < cars.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {cars[i].Name}");
        }

        int carChoice = int.Parse(Console.ReadLine()) - 1;
        Car selectedCar = cars[carChoice];

        while (true)
        {
            Console.WriteLine("\nВыберите действие:");
            Console.WriteLine("1. Завести машину");
            Console.WriteLine("2. Заглушить машину");
            Console.WriteLine("3. Газануть");
            Console.WriteLine("4. Притормозить");
            Console.WriteLine("5. Переключить передачу");
            Console.WriteLine("6. Выход");

            int actionChoice = int.Parse(Console.ReadLine());

            switch (actionChoice)
            {
                case 1:
                    selectedCar.Start();
                    break;
                case 2:
                    selectedCar.Stop();
                    break;
                case 3:
                    selectedCar.Accelerate();
                    break;
                case 4:
                    selectedCar.Brake();
                    break;
                case 5:
                    selectedCar.ShiftGear();
                    break;
                case 6:
                    return;
                default:
                    Console.WriteLine("Неверный выбор, попробуйте еще раз.");
                    break;
            }
        }
    }
}

class Car
{
    public string Name { get; private set; }
    private bool isRunning;

    public Car(string name)
    {
        Name = name;
        isRunning = false;
    }

    public void Start()
    {
        if (!isRunning)
        {
            isRunning = true;
            DisplayMessage($"{Name} завелась.");
        }
        else
        {
            DisplayMessage($"{Name} уже работает.");
        }
    }

    public void Stop()
    {
        if (isRunning)
        {
            isRunning = false;
            DisplayMessage($"{Name} остановилась.");
        }
        else
        {
            DisplayMessage($"{Name} уже остановлена.");
        }
    }

    public void Accelerate()
    {
        if (isRunning)
        {
            DisplayMessage($"{Name} газует.");
        }
        else
        {
            DisplayMessage($"{Name} не может газовать, она не заведена.");
        }
    }

    public void Brake()
    {
        if (isRunning)
        {
            DisplayMessage($"{Name} тормозит.");
        }
        else
        {
            DisplayMessage($"{Name} не может тормозить, она не заведена.");
        }
    }

    public void ShiftGear()
    {
        if (isRunning)
        {
            DisplayMessage($"{Name} переключает передачу.");
        }
        else
        {
            DisplayMessage($"{Name} не может переключать передачу, она не заведена.");
        }
    }

    private void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }
}
