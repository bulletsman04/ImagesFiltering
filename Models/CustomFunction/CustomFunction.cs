using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.CustomFunction
{
    public class CustomFunction
    {
        public int[] FunctionTable { get; set; }

        public CustomFunction()
        {
            InitializeTable();
        }

        private void InitializeTable()
        {
            FunctionTable = new int[256];
            for (int i = 0; i < 256; i++)
            {
                FunctionTable[i] = i;
            }
        }
    }
}
