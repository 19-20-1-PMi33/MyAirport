using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PI.Models;

namespace PI.Helpers
{
    /// <summary>
    /// �� ���� Clients.
    /// ������ ��� � ���� ����� ��� �볺��� �� ������ ������.
    /// </summary>
    class Clients
    {
        public static List<PersonalInformation> ListOfClients = new List<PersonalInformation>();
        public static int EconomicClass { get; set; }
        public static int BusinessClass { get; set; }
        public static int FirstClass { get; set; }
        public static int Sum = 0;
        /// <summary>
        /// ���� �������� query � ������ �볺���(ListOfQueries)
        /// ������ ����(sum)
        /// </summary>
        /// <param name="information">���������� ��� �볺���</param>
        /// <param name="sum">�������� ���� �� �����</param>
        public static void Add(PersonalInformation information, int sum)
        {
            ListOfClients.Add(information);
            Sum += sum;
        }
        /// <summary>
        /// ������� �� ��� � ������ �� ������� �������� ������.
        /// </summary>
        public static void Clear()
        {
            EconomicClass = BusinessClass = FirstClass = Sum = 0;
            ListOfClients.Clear();
        }
    }
}
