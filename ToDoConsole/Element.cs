using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoConsole
{
    internal class Element
    {

        private string name;
        private bool isCompleted;

        public Element(string name)
        {
            if (name != null)
            {
                this.name = name;
                this.isCompleted = false;
            }
            else
            {
                Console.WriteLine("you don't specified a name for your element, so if you want to rename it, type : /rename error <the nam>");
                this.name = "error";
            }
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetIsCompleted()
        {
            this.isCompleted = true;
        }

        public string GetName()
        {
            return this.name;
        }

        public string GetIsCompleted()
        {
            return this.isCompleted.ToString();
        }
    }
}
