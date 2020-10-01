using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.ComTypes;

partial class Abiturient
{
    public static int Amount = 0;
    static int hashNum;
    const int DEFAULT_MARKS_AMOUNT = 3;

    readonly int _id;
/*    int[] _marks;
    string _name;
    string _surname;
    string _father;
    string _adress;*/
    string _phone;

    public int Id { get; }
    public int[] Marks { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Father { get; set; }
    public string Adress { get; set; }
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
        Amount = 0;
        Random rrr = new Random();
        hashNum = rrr.Next();
    }

    public Abiturient() : this(null) { }
    public Abiturient(string name, string surname, int[] marks) : this(marks, name, surname, null, null, null) { }
    public Abiturient(int[] marks = null, string name = "Kolya", string surname = "Bovkun", string father = "Fatherless", string adress = "BGTU", string phone = "911") : this(10, marks, name, surname, father, adress, phone) { }
    Abiturient(int id, int[] marks, string name, string surname, string father, string adress, string phone)
    {
        _id = hashNum+Amount;

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

}

class Program
{
    static void Main(string[] args)
    {
        int[] antonMarks = { 5, 7, 10 };
        int[] nastyaMarks = { 5, 5, 9 };
        int[] denisMarks = { 9, 9, 9 };

        Abiturient defaultA = new Abiturient();
        Abiturient anton = new Abiturient("Anton", "Lityagin", antonMarks);        
        Abiturient nastya = new Abiturient(nastyaMarks, "Nastya", "Pnevmoniya");
        Abiturient denis = new Abiturient(denisMarks, "Denis", "Bozhko", "Orlovich", "Brest", "Sss");

        Console.WriteLine(defaultA.ToString() + "\n" + anton.ToString() + "\n" + nastya.ToString() + "\n" + denis.ToString() + "\n");
        Console.WriteLine("Doues Anton equals Denis? - " + anton.Equals(denis));
        Console.WriteLine("What type has default abiturient? - " + defaultA.GetType());
        Console.WriteLine("What Nastya's mark is highest? - " + nastya.GetMaxMark());
        Console.WriteLine();

        //////////////////////////////////////////////////////////////////////////////////////////////////////

        Abiturient[] friends = new Abiturient[Abiturient.Amount];
        friends[0] = defaultA;
        friends[1] = anton;
        friends[2] = nastya;
        friends[3] = denis;

        Console.WriteLine("\tThey have bad marks");
        foreach(Abiturient person in friends)
        {
            double sum;
            bool isGood = true;
            person.GetOverage(out sum, ref isGood);

            if (!isGood){
                Console.WriteLine(person.ToString());
            }
        }
        Console.WriteLine();

        double aim = 20;
        Console.WriteLine($"\tThey're score >= {aim}");
        foreach (Abiturient person in friends)
        {
            bool isGood = true;
            double sum;
            person.GetOverage(out sum, ref isGood);

            if(sum >= aim)
            {
                Console.WriteLine(person.ToString());
            }
        }
        Console.WriteLine();

        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        int[] arr = { 4, 4, 0 };
        string Name = "Anton";
        var surdov = new {Id = 0, Marks = arr, Name, Surname = "Surdov", Father = "Loh", Adress = "Army", Phone = "911"};

        Console.WriteLine(surdov.ToString());
    }
}
