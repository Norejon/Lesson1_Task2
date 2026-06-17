using System;
using System.Collections.Generic;
using System.Linq;

namespace MyApp.Core
{
    public class ProductCatalog
    {
        // 1. Приватний список товарів (ніхто ззовні не може змінити його напряму)
        private readonly List<string> _products = new List<string>();

        // 2. Метод додавання товару
        public void Add(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                _products.Add(name);
                Console.WriteLine($"[Core] Товар \"{name}\" успішно додано.");
            }
        }

        // 3. Метод видалення товару
        public bool Remove(string name)
        {
            if (_products.Contains(name))
            {
                _products.Remove(name);
                Console.WriteLine($"[Core] Товар \"{name}\" видалено.");
                return true;
            }
            Console.WriteLine($"[Core] Товар \"{name}\" не знайдено в каталозі.");
            return false;
        }

        // 4. Метод, що повертає весь список (як IEnumerable, щоб його не могли випадково очистити ззовні)
        public IEnumerable<string> GetAll()
        {
            return _products;
        }

        // 5. Перевантажений метод Find (Варіант 1: пошук за точним ім'ям)
        public string? Find(string name)
        {
            return _products.FirstOrDefault(p => p.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        // 6. Перевантажений метод Find (Варіант 2: пошук за індексом/номером)
        public string? Find(int index)
        {
            if (index >= 0 && index < _products.Count)
            {
                return _products[index];
            }
            return null; 
        }
    }
}