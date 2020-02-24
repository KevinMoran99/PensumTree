using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensumTree
{
    class Operation<T>
    {
        private bool state = true ;
        private string error = null;
        private List<T> data = new List<T>();
        private object value = null;

        public bool State { get => state; set => state = value; }
        public string Error { get => error; set => error = value; }
        public List<T> Data { get => data; set => data = value; }
        public object Value { get => value; set => this.value = value; }
    }
}
