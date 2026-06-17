
using MyApp.Core;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductCatalog catalog = new ProductCatalog();
            bool running = true;

            Console.WriteLine("=== Програма керування каталогом товарів ===");
            Console.WriteLine("Доступні команди: add, remove, list, find, exit");

            while (running)
            {
                Console.Write("\nВведіть команду: ");
                string? command = Console.ReadLine()?.Trim().ToLower();

                switch (command)
                {
                    case "add":
                        Console.Write("Введіть назву товару для додавання: ");
                        string? nameToAdd = Console.ReadLine();
                        if (!string.IsNullOrEmpty(nameToAdd)) catalog.Add(nameToAdd);
                        break;

                    case "remove":
                        Console.Write("Введіть назву товару для видалення: ");
                        string? nameToRemove = Console.ReadLine();
                        if (!string.IsNullOrEmpty(nameToRemove)) catalog.Remove(nameToRemove);
                        break;

                    case "list":
                        var products = catalog.GetAll();
                        if (!products.Any())
                        {
                            Console.WriteLine("Каталог порожній.");
                        }
                        else
                        {
                            Console.WriteLine("--- Список товарів ---");
                            int i = 0;
                            foreach (var product in products)
                            {
                                Console.WriteLine($"[{i}] {product}");
                                i++;
                            }
                        }
                        break;

                    case "find":
                        Console.Write("Введіть назву товару або його номер для пошуку: ");
                        string? searchInput = Console.ReadLine()?.Trim();

                        if (!string.IsNullOrEmpty(searchInput))
                        {
                            // Якщо користувач ввів число, шукаємо за індексом
                            if (int.TryParse(searchInput, out int searchIndex))
                            {
                                string? result = catalog.Find(searchIndex);
                                Console.WriteLine(result != null ? $"Знайдено за номером [{searchIndex}]: {result}" : "Товар з таким номером не існує.");
                            }
                            // Інакше шукаємо за текстом
                            else
                            {
                                string? result = catalog.Find(searchInput);
                                Console.WriteLine(result != null ? $"Знайдено за назвою: {result}" : "Товар не знайдено.");
                            }
                        }
                        break;

                    case "exit":
                        running = false;
                        Console.WriteLine("Вихід з програми. Гарного дня!");
                        break;

                    default:
                        Console.WriteLine("Невідома команда. Спробуйте ще раз (add, remove, list, find, exit).");
                        break;
                }
            }
        }
    }
}