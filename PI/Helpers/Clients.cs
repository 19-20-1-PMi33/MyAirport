using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PI.Models;

namespace PI.Helpers
{
    /// <summary>
    /// Це клас Clients.
    /// Зберігає дані у базу даних про клієнтів які купили квитки.
    /// </summary>
    class Clients
    {
        public static List<PersonalInformation> ListOfClients = new List<PersonalInformation>();
        public static int EconomicClass { get; set; }
        public static int BusinessClass { get; set; }
        public static int FirstClass { get; set; }
        public static int Sum = 0;
        /// <summary>
        /// Додає параметр query в список клієнтів(ListOfQueries)
        /// Збільшує суму(sum)
        /// </summary>
        /// <param name="information">Інформація про клієнта</param>
        /// <param name="sum">Загальна сума за білети</param>
        public static void Add(PersonalInformation information, int sum)
        {
            ListOfClients.Add(information);
            Sum += sum;
        }
        /// <summary>
        /// Видаляє всі дані зі списку та занулює значення змінних.
        /// </summary>
        public static void Clear()
        {
            EconomicClass = BusinessClass = FirstClass = Sum = 0;
            ListOfClients.Clear();
        }
    }
}
