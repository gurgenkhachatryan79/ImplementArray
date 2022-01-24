using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayImplementationGurgenKhachatryan
{
    class ShowInfo<T>
    {
        public void Print(T[] array,int indexpointer)
        {
            for (int i = 0; i <=indexpointer; i++)
            {
                Console.Write(array[i]+" ");
            }
            Console.WriteLine();
        }
    }
}
