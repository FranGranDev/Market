using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Models
{
    class ToDoModel
    {
        private bool isDone;
        private string text;



        public DateTime CreationTime { get; private set; } = DateTime.Now;       
        public bool IsDone
        {
            get => isDone;
            set
            {
                isDone = value;
            }
        }
        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        
    }
}
