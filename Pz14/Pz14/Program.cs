using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Получаем текущую директорию
            string currentDirectory = Directory.GetCurrentDirectory();

            // Создаем подкаталог /new
            string newDirectoryPath = Path.Combine(currentDirectory, "new");
            Directory.CreateDirectory(newDirectoryPath);

            // Пути к файлам
            string f1Path = Path.Combine(currentDirectory, "f1.txt");
            string f2Path = Path.Combine(newDirectoryPath, "f2.txt");

            // Проверяем, существует ли файл f1
            if (File.Exists(f1Path))
            {
                // Читаем содержимое файла f1
                string content = File.ReadAllText(f1Path);

                // Пишем содержимое в файл f2 в новом подкаталоге
                File.WriteAllText(f2Path, content);

                Console.WriteLine($"Файл f2 создан в подкаталоге /new с содержимым из файла f1.");
            }
            else
            {
                Console.WriteLine("Файл f1 не существует в текущей директории.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }
}
