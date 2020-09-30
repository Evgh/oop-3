using System;
using System.Runtime.InteropServices.ComTypes;

namespace oop_3
{
    class Abiturient
    {
        public static int Amount;
        static int DEFAULT_MARKS_AMOUNT = 3;

        int _id;
        int[] _marks;
        string _name;
        string _surname;
        string _father;
        string _adress;
        string _phone;  

        public int Id
        {
            get { return _id; } // ограничение доступа по set по заданию 
        }

        public int[] Marks // ограничение доступа по set по заданию x2
        {
            get
            {
                return _marks;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                _surname = value;
            }
        }

        public string Father
        {
            get
            {
                return _father;
            }
            set
            {
                _father = value;
            }
        }   
        
        public string Adress
        {
            get
            {
                return _adress;
            }
            set
            {
                _adress = value;
            }
        }

        public string Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                _phone = value;
            }
        }


        static Abiturient()
        {
            Console.WriteLine("Создан первый абитуриент");
            Amount = 1;
        }

        public Abiturient() : this(0) {}
        public Abiturient(int[] marks, string name, string surname) : this(0, marks, name, surname) {}
        public Abiturient(int id, int[] marks = null, string name = "Kolya", string surname = "Bovkun", string father = "Fatherless", string adress = "BGTU", string phone = "911") : this (id, marks, name, surname, father, adress, phone, 0) {}
        Abiturient (int id, int[] marks, string name, string surname, string father, string adress, string phone, int a)
        {
            Random rrr = new Random();
            _id = rrr.Next()*Amount;

            if (marks != null)
            {
                _marks = marks;
            }
            else
            {
                _marks = new int[DEFAULT_MARKS_AMOUNT];
            };

            _name = name;
            _surname = surname;
            _father = father;
            _adress = adress;

            bool flag = true;
            for (int i = 0; i < phone.Length; i++)
            {
                if ((phone[i] >= 48 && phone[i] <= 57) || phone[i] == 32 || phone[i] == 43 || phone[i] == 45)
                {
                    continue;
                }
                else
                {
                    flag = false;
                    break;
                }
            }
            _phone = flag ? phone : "911";

            Amount++;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Abiturient Anton = new Abiturient(666);
            Abiturient Kolya = new Abiturient();

            Console.WriteLine(Anton.Id + " " + Kolya.Id + " "+ Anton.Name + " " + Abiturient.Amount);

        }
    }
 
}
