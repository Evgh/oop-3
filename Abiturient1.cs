using System;

partial class Abiturient
{
	public static void Hello()
    {
        Console.WriteLine("Hello from another file!");
    }

    public override bool Equals(object obj)
    {
        return this.GetHashCode() == obj.GetHashCode();
    }
    public override int GetHashCode()
    {
        int hash = hashNum;
        hash = Name != null ? Name.GetHashCode() : hash;
        hash = Surname != null ? hash * Surname.GetHashCode() : hash;
        hash = Father != null ? hash * Father.GetHashCode() : hash;
        hash = Adress != null ? hash * Adress.GetHashCode() : hash;
        hash = Phone != null ? hash * Phone.GetHashCode() : hash;

        if (Marks != null)
        {
            hash += Marks.Length;
            foreach(int x in Marks) 
            {
                hash += x;
            }
        }
        return  hash;
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
