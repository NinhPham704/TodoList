using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TodoList
{
    public partial class UC_Todo : UserControl
    {
        #region property
        private Task task;
        private event EventHandler checkedChanged;
        public event EventHandler CheckedChanged
        {
            add { checkedChanged+=value;}
            remove { checkedChanged -= value;}
        }
        private event EventHandler delete;
        public event EventHandler Delete
        {
            add { delete += value;}
            remove { delete -= value;}
        }
        public Task Task
        { 
            get => task;
            set => task = value;
        }
        #endregion
        #region initialize
        public UC_Todo(Task task)
        {
            InitializeComponent();
            this.Task = task;
            ShowTask();
        }        
        #endregion
        #region methods
        public void ShowTask()
        {
            ckbDone.Checked = Task.Done;
            txbStatus.Text =Task.Status;
            if (ckbDone.Checked)
            {
                ckbDone.Enabled = false;
                txbStatus.Enabled = false;
            }
        }
        #endregion
        #region events
        private void btnDelete_Click(object sender, EventArgs e)
        {
            delete?.Invoke(this, new EventArgs());
        }
        private void ckbDone_CheckedChanged(object sender, EventArgs e)
        {
            if(checkedChanged != null)
            {
                checkedChanged(this, new EventArgs());
            }
            ShowTask();
        }
        #endregion
    }
}
