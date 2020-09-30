using System;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

partial class Abiturient
{
    public static int Amount = 0;
    const int DEFAULT_MARKS_AMOUNT = 3;

    readonly int _id;
    int[] _marks;
    string _name;
    string _surname;
    string _father;
    string _adress;
    string _phone;

    public int Id
    {
        get { return _id; }
    }

    public int[] Marks
    {
        get
        {
            return _marks;
        }
        set
        {
            _marks = value;
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
            bool flag = true;
            if (value != null)
            {
                for (int i = 0; i < value.Length; i++)
                {
                    if ((value[i] >= 48 && value[i] <= 57) || value[i] == 32 || value[i] == 43 || value[i] == 45)
                    {
                        continue;
                    }
                    else
                    {
                        flag = false;
                        break;
                    }
                }
            }
            else
            {
                flag = false;
            }

            if (flag)
            {
                _phone = value;
            }

        }
    }

    static Abiturient()
    {
        Console.WriteLine("Создан первый абитуриент");
        Amount = 0;
    }

    public Abiturient() : this(null) { }
    public Abiturient(int[] marks, string name, string surname) : this(marks, name, surname, null) { }
    public Abiturient(int[] marks = null, string name = "Kolya", string surname = "Bovkun", string father = "Fatherless", string adress = "BGTU", string phone = "911") : this(10, marks, name, surname, father, adress, phone) { }
    Abiturient(int id, int[] marks, string name, string surname, string father, string adress, string phone)
    {
        Random rrr = new Random();
        _id = rrr.Next() * Amount;

        if (marks != null)
        {
            Marks = marks;
        }
        else
        {
            Marks = new int[DEFAULT_MARKS_AMOUNT];
        };

        Name = name;
        Surname = surname;
        Father = father;
        Adress = adress;
        Phone = phone;
        Amount++;
    }


    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        Abiturient person = (Abiturient)obj;
        bool flag;
        flag = (Name == person.Name) && (Surname == person.Surname) && (Father == person.Father) && (Adress == person.Adress) && (Phone == person.Phone) && (Marks.Length == person.Marks.Length);

        for (int i = 0; i < Marks.Length && flag; i++)
        {
            flag = flag && (Marks[i] == person.Marks[i]);
        }
        return flag;
    }

    public override int GetHashCode()
    {
        return Id;
    }

    public override string ToString()
    {
        string marks = "";
        foreach (int x in Marks)
        {
            marks += x.ToString() + " ";
        }

        return Id.ToString() + " " + Name + " " + Surname + " " + Father + " " + Adress + " " + Phone + " " + marks;
    }

    public static int GetAmount()
    {
        return Amount;
    }
    public double GetOverage()
    {
        double num = 0; 
        foreach (int x in Marks)
        {
            num += x;
        }
        return num / Marks.Length;
    }

    public int GetMinMark()
    {
        int min = Marks[0];
        foreach(int x in Marks)
        {
            min = x < min ? x : min;
        }
        return min;
    }

    public int GetMaxMark()
    {
        int max = Marks[0];
        foreach (int x in Marks)
        {
            max = x > max ? x : max;
        }
        return max;
    }

}

class Program
{
    static void Main(string[] args)
    {
        int[] marks = { 5, 5, 10};
        
        Abiturient Kolya = new Abiturient();
        Abiturient Nastya = new Abiturient(marks, "Nastya", "S");
        Abiturient Anton = new Abiturient(marks, "Anton", "Lityagin");

        Anton.Phone = "Gertsne";
        



        Console.WriteLine(Nastya.Equals(Kolya) + "\n" + Anton.ToString());



        Abiturient.Hello();

    }
}
