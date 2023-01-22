using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    [Serializable]
    public class ListTask
    {
        private List<Task> tasks;

        public List<Task> Tasks { get => tasks; set => tasks = value; }
    }
}
