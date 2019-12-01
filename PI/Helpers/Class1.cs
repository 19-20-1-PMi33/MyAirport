using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PI.Models;

namespace PI.Helpers
{
    class Class1
    {
        public static List<PersonalInformation> ListOfQueries = new List<PersonalInformation>();
        public static int Sum = 0;
        public static void Add(PersonalInformation query, int sum)
        {
            ListOfQueries.Add(query);
            Sum += sum;
        }
        public static void Clear()
        {
            Sum = 0;
            ListOfQueries.Clear();
        }
    }
}
