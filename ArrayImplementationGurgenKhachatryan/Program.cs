using System;

namespace ArrayImplementationGurgenKhachatryan
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayImplement<int> arrayImplement = new ArrayImplement<int>();
            ArrayImplement<char> arrayImplement2 = new ArrayImplement<char>();
            Random random = new Random();
            arrayImplement.Add(79);
            for (int i = 0; i < 7; i++)
            {
                int number = random.Next(100);
                arrayImplement.Add(number);
            }

            arrayImplement.Add(69);
            arrayImplement.Add(79);

            Console.WriteLine("Count=" + arrayImplement.Count());
            Console.WriteLine("Get(index=2)=" + arrayImplement.Get(2));
            Console.WriteLine("IndexOf(69)=" + arrayImplement.IndexOf(69));
            Console.WriteLine("Insert(2, 555)="); arrayImplement.Insert(2, 555);
            Console.WriteLine("RemoveAt(3)="); arrayImplement.RemoveAt(3);
            Console.WriteLine("Remove(69)="); arrayImplement.Remove(69);
            Console.WriteLine("Swap(5, 6)="); arrayImplement.Swap(5, 6);              ///new Method
            Console.WriteLine("Replace(79,111=)"); arrayImplement.Replace(79, 111);   ///new Method

        }
    }
}
