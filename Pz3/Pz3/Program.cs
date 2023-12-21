using System;

class TrainSchedule
{
    static void Main()
    {
        Console.WriteLine("Введите день недели (1-7):");
        int dayOfWeek = int.Parse(Console.ReadLine());

        switch (dayOfWeek)
        {
            case 1:
                DisplayRoutesAndFares("Понедельник", "Маршрут 1", 500);
                break;
            case 2:
                DisplayRoutesAndFares("Вторник", "Маршрут 2", 600);
                break;
            case 3:
                DisplayRoutesAndFares("Среда", "Маршрут 3", 550);
                break;
            case 4:
                DisplayRoutesAndFares("Четверг", "Маршрут 4", 700);
                break;
            case 5:
                DisplayRoutesAndFares("Пятница", "Маршрут 5", 450);
                break;
            case 6:
                DisplayRoutesAndFares("Суббота", "Маршрут 6", 800);
                break;
            case 7:
                DisplayRoutesAndFares("Воскресенье", "Маршрут 7", 750);
                break;
            default:
                Console.WriteLine("Некорректный день недели.");
                break;
        }
    }

    static void DisplayRoutesAndFares(string day, string route, int fare)
    {
        Console.WriteLine($"Маршруты поездов в {day}:");
        Console.WriteLine(route);
        Console.WriteLine($"Стоимость билета: {fare} рублей");
    }
}
