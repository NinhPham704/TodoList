using Newtonsoft.Json;

namespace TodoList
{
    public partial class Form1 : Form
    {
        #region property
        private int color = 0;
        private ListTask listAllTask;
        private List<Task> listPendingTask;
        private List<Task> listDoneTask;
        private List<UC_Todo> listTodo;
        private string filepath = "D:\\C#\\TodoList\\TodoList\\Resource\\data.json";
        public ListTask ListAllTask { get => listAllTask; set => listAllTask = value; }
        public List<Task> ListPendingTask { get => listPendingTask; set => listPendingTask = value; }
        public List<Task> ListDoneTask { get => listDoneTask; set => listDoneTask = value; }
        public List<UC_Todo> ListTodo { get => listTodo; set => listTodo = value; }
        #endregion
        #region Initialize
        public Form1()
        {
            InitializeComponent();
            SetDefaultListTask();
            try
            {
                ListAllTask.Tasks = DeserializefromJson(filepath);
            }
            catch
            {
            }
            ShowAllTask();
            ResetColorButton();
        }
        #endregion
        #region methods
        private void SerializetoJson(List<Task> task, string filepath)
        {
            FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Write);
            
            using (StreamWriter sw = new StreamWriter(fs))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(sw, task);
            }
        }
        private List<Task> DeserializefromJson(string filepath)
        {
            try
            {
                string data = File.ReadAllText(filepath);
                List<Task> result = JsonConvert.DeserializeObject<List<Task>>(data);
                File.Delete(filepath);
                return result;
            }
            catch {
                return new List<Task>();
            }
            
        }
        void SetDefaultListTask()
        {
            ListAllTask = new ListTask();
            ListAllTask.Tasks = new List<Task>();
        }
        void ShowAllTask()
        {
            listTodo = new List<UC_Todo>();
            flpListTodo.Controls.Clear();
            if (ListAllTask != null)
            {
                if(ListAllTask.Tasks.Count == 0 || ListAllTask.Tasks == null)
                {
                    flpListTodo.Controls.Add(new Label() { Text = "Bạn chưa có task nào" });
                }
                else
                {
                    foreach (Task item in ListAllTask.Tasks)
                    {
                        UC_Todo uC_Todo = new UC_Todo(item);
                        ListTodo.Add(uC_Todo);
                        flpListTodo.Controls.Add(uC_Todo);
                        uC_Todo.Tag = item;
                        uC_Todo.CheckedChanged += UC_Todo_CheckedChanged;
                        uC_Todo.Delete += UC_Todo_Delete;
                    }
                }
            }
        }
        void ShowPendingTask()
        {
            flpListTodo.Controls.Clear();
            if (ListTodo.Count == 0)
            {
                flpListTodo.Controls.Add(new Label() { Text = "Bạn chưa có task nào" });
            }
            else
            {
                foreach(UC_Todo item in ListTodo)
                {
                    Task task = item.Tag as Task;
                    if (task.Done)
                    {
                        item.Visible= false;
                    }
                    else
                    {
                        item.Visible= true;
                    }
                    flpListTodo.Controls.Add(item);
                }
            }            
        }
        void ShowCompletedTask()
        {
            flpListTodo.Controls.Clear();
            if (ListTodo.Count == 0)
            {
                flpListTodo.Controls.Add(new Label() { Text = "Bạn chưa có task nào" });
            }
            else
            {
                foreach (UC_Todo item in ListTodo)
                {
                    Task task = item.Tag as Task;
                    if (!task.Done)
                    {
                        item.Visible = false;
                    }
                    else
                    {
                        item.Visible = true;                        
                    }
                    flpListTodo.Controls.Add(item);
                }
            }
        }
        void ResetColorButton()
        {
            switch (color)
            {                    
                case 1:
                    btnAll.BackColor = Color.White;
                    btnCompleted.BackColor = Color.White;
                    btnPending.BackColor = Color.DeepPink;
                    break;
                case 2:
                    btnAll.BackColor = Color.White;
                    btnCompleted.BackColor = Color.DeepPink;
                    btnPending.BackColor = Color.White;
                    break;
                default:
                    btnAll.BackColor = Color.DeepPink;
                    btnCompleted.BackColor = Color.White;
                    btnPending.BackColor = Color.White;
                    break;
            }
        }
        void ShowTaskByClickButton()
        {
            switch (color)
            {
                case 1:
                    ShowPendingTask();
                    break;
                case 2:
                    ShowCompletedTask();
                    break;
                default:
                    ShowAllTask();
                    break;
            }
        }
        void DeleteTask(UC_Todo todo)
        {
            ListTodo.Remove(todo);
            ListAllTask.Tasks.Remove(todo.Tag as Task);
            ShowTaskByClickButton();
        }
        #endregion
        #region events
        private void UC_Todo_Delete(object? sender, EventArgs e)
        {
            DeleteTask(sender as UC_Todo);
        }
        private void UC_Todo_CheckedChanged(object? sender, EventArgs e)
        {
            UC_Todo uc_Todo = sender as UC_Todo;
            Task item = uc_Todo.Tag as Task;
            if(item != null)
            {
                var check = ListAllTask.Tasks.IndexOf(item);
                ListAllTask.Tasks[check].Done = true;
            }
            ShowTaskByClickButton();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SerializetoJson(ListAllTask.Tasks, filepath);
            if (MessageBox.Show("Bạn có muốn thoát không?","Thông báo", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Task task = new Task() { Status = txtDoSomething.Text};
            ListAllTask.Tasks.Add(task);
            color = 0;
            ResetColorButton();
            ShowAllTask();
            txtDoSomething.Text = "Add a new task";
        }
        private void btnAll_Click(object sender, EventArgs e)
        {
            color = 0;
            ResetColorButton();
            ShowAllTask();
        }
        private void btnPending_Click(object sender, EventArgs e)
        {
            color = 1;
            ResetColorButton();
            ShowPendingTask();
        }
        private void btnCompleted_Click(object sender, EventArgs e)
        {
            color = 2;
            ResetColorButton();
            ShowCompletedTask();
        }
        private void btnClearAll_Click(object sender, EventArgs e)
        {
            ListAllTask.Tasks.Clear();
            ShowAllTask();
        }
        #endregion
    }
}