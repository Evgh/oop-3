using System;

partial class Abiturient
{
	public static void Hello()
    {
        Console.WriteLine("Hello from another file!");
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

        return Id.ToString() + " " + Name + " " + Surname + " " + Father + " " + Adress + " " + Phone + " |Marks: " + marks;
    }

    public static int GetAmount()
    {
        return Amount;
    }

    public double GetOverage(out double sum, ref bool isGood)
    {
        sum = 0;
        isGood = true;
        foreach (int x in Marks)
        {
            sum += x;
            isGood = isGood && x >= 4;
        }
        return sum / Marks.Length;
    }

    public int GetMinMark()
    {
        int min = Marks[0];
        foreach (int x in Marks)
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
