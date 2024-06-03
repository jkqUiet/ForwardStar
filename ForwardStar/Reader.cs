using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOA_Zadanie
{
    internal class Reader
    {
        StreamReader file;
        string line = "";
        public Reader()
        { }
        public void openFile(string fileName)
        {
            file = new StreamReader("C:/Users/jozef/source/repos/IOA Zadanie/IOA Zadanie/"+fileName);
        }
        public string read()
        {
            if (file == null) return null;
            if ((line = file.ReadLine()) != null)
            {
                return line;
            }
            return null;
        }
        public void closeFile()
        {
            file.Close();
        }
    }
}
