using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data.Entity;
using System.Runtime.CompilerServices;
using PI.Models;
using PI.Helpers;
using PI.Commands;

namespace PI.ViewModel
{
    public class ScheduleViewModel
    {
        ApplicationContext db;
        IEnumerable<Flight> _Flights;

        public ScheduleViewModel()
        {
            db = new ApplicationContext();
        }
    }
}
