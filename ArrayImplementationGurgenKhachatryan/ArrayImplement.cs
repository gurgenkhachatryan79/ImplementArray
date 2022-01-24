using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayImplementationGurgenKhachatryan
{
    //Որպեսզի պահպանեմ Interface Segregation principle-ը յուր․ մեթոդ գրել եմ առանին ինտերֆեյսի մեջ
    class ArrayImplement<T> : IAdd<T>, ICount, IGet<T>, IIndexOf<T>, IInsert<T>, IRemove<T>, IRemoveAt, ISwap,IReplace<T>
    {
        int capacity;
        double percent;//օգտագործում եմ capacity-ն մեծացնելու համար,քանի որ հենց էլեմենտների քանակը հավասարվում է 
                       // 70% capacity-ն մեծանում է 2 անգամ։         
        T[] array;
        static int indexpointer;

        public ArrayImplement()
        {
            capacity = 10;
            percent = 0.7;
            array = new T[capacity];
            indexpointer = 0;
        }


        //Ստեղծելեմ Copy և ChekIndex ,ChekCapacity
        // քանի որ երեքն էլ  օգտագործվում են անընդհատ տարբեր մեթոդներում  DRY   պահպանելու համար

        public void ChekIndex(int index)
        {
            if (index < 0 || index > indexpointer)
            {
                throw new ArgumentOutOfRangeException("The given index is not within the array");
                // Console.WriteLine("The given index is not within the array");
            }

        }
        public void ChekCapacity()
        {
            if (indexpointer >= array.Length * percent)
            {
                capacity *= 2;
                T[] newarray = new T[capacity];
                Copy(array, 0, array.Length - 1, newarray, 0);
                array = newarray;
            }

        }
        public void Copy(T[] array, int arrayLeftIndex, int arrayRigthIndex, T[] newarray, int newarrayLeftIndex)
        {
            for (int i = arrayLeftIndex; i <= arrayRigthIndex; i++, newarrayLeftIndex++)
            {
                newarray[newarrayLeftIndex] = array[i];
            }
        }


        public void Add(T obj)
        {
            ChekCapacity();
            array[indexpointer] = obj;
            new ShowInfo<T>().Print(array, indexpointer);
            indexpointer++;
        }

        public int Count()
        {
            return indexpointer;
        }

        public T Get(int index)
        {

            ChekIndex(index);

            return array[index];

            //return null;
        }

        public int IndexOf(T obj)
        {
            for (int i = 0; i < indexpointer; i++)
            {
                if (array[i].Equals(obj))
                { return i; }
            }
            return -1;
        }

        public void Insert(int index, T obj)
        {
            ChekIndex(index);
            ChekCapacity();
            T[] newarray = new T[capacity + 1];
            Copy(array, 0, index - 1, newarray, 0);
            newarray[index] = obj;
            Copy(array, index, indexpointer - 1, newarray, index + 1);
            array = newarray;
            new ShowInfo<T>().Print(array, indexpointer);
            indexpointer++;
        }
        public void RemoveAt(int index)
        {
            ChekIndex(index);
            T[] newarray = new T[indexpointer - 1];
            Copy(array, 0, index - 1, newarray, 0);
            Copy(array, index + 1, indexpointer - 1, newarray, index);
            array = newarray;
            indexpointer--;
            new ShowInfo<T>().Print(array, indexpointer - 1);

        }

        public void Remove(T obj)
        {
            int index = IndexOf(obj);
            RemoveAt(index);
        }

        public void Swap(int index1, int index2)
        {
            ChekIndex(index1);
            ChekIndex(index2);
            T obj = array[index1];
            array[index1] = array[index2];
            array[index2] = obj;
            new ShowInfo<T>().Print(array, indexpointer - 1);
        }

        public void Replace(T obj1, T obj2)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Equals(obj1))
                {
                    array[i] = obj2;
                }
            }
            new ShowInfo<T>().Print(array, indexpointer - 1);
        }
    }
}
