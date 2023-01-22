using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    public class Task
    {
        private bool done = false;

        private string status;

        public bool Done { get => done; set => done = value; }
        public string Status { get => status; set => status = value; }
    }
}
