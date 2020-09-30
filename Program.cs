using System;

namespace oop_3
{

    class Abiturient
    {
        string name;
        string surname;
        string father;
        string adress;
        string phone;


        public int a;


        Abiturient()
        {
            a = 0;
        }
        Abiturient(int x)
        {
            a = x > 0 && x <= 10 ? x : 0;
        }
        Abiturient()
        {

        }




        static void Main(string[] args)
        {
            Console.WriteLine("Hello Classes World!");
            Abiturient aa = new Abiturient(300);
            Console.WriteLine(aa.a);
        }
    }
 
}
