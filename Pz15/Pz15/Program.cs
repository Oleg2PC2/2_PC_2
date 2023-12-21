using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Введите полный путь к каталогу:");
            string inputPath = Console.ReadLine();

            // Проверяем, существует ли указанный каталог
            if (Directory.Exists(inputPath))
            {
                // Создаем подкаталог TEMP
                string tempDirectoryPath = Path.Combine(inputPath, "TEMP");
                Directory.CreateDirectory(tempDirectoryPath);

                // Перемещаем содержимое каталога в подкаталог TEMP
                MoveDirectoryContents(inputPath, tempDirectoryPath);

                Console.WriteLine($"Содержимое каталога успешно перемещено в подкаталог TEMP.");
            }
            else
            {
                Console.WriteLine("Указанный каталог не существует.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }

    // Метод для перемещения содержимого каталога в другой каталог
    static void MoveDirectoryContents(string sourceDirectory, string targetDirectory)
    {
        foreach (string filePath in Directory.GetFiles(sourceDirectory))
        {
            string fileName = Path.GetFileName(filePath);
            string targetFilePath = Path.Combine(targetDirectory, fileName);
            File.Move(filePath, targetFilePath);
        }
    }
}
