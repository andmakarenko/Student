using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

class Student : Person, IComparable<Student>
{
    public static int ID_gen = 0;
    private static Random rand = new Random();

    public List<int> Marks
    {
        get;
    }

    public List<int> Hw
    {
        get;
    }

    public List<int> Exams
    {
        get;
    }

    public int Id
    { 
        get; 
    }

    public Student() :
        this("defName", "defLastName")
    { }

    public Student(string name, string lastName) :
        this(name, lastName, new Address(), DateTime.Now)
    { }

    public Student(string name, string lastName, Address address, DateTime birthDate):
        base(name, lastName, address, birthDate)
    {

        Marks = new List<int>();
        Hw = new List<int>();
        Exams = new List<int>();


        generateCollections();

        Id = ++ID_gen;
    }

    private void generateCollections()
    {
        try
        {
            for (int i = 0; i < 10; i++)
            {
                Marks.Add(rand.Next(2, 12));
                Hw.Add(rand.Next(2, 12));
                Exams.Add(rand.Next(2, 12));
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Generation failed: {e.Message}");
        }

    }

    public float getExamsAvg()
    {
        float avg = 0;

        try
        {
            foreach (int mark in Exams)
            {
                avg += (float)mark;
            }

            avg /= Exams.Count;
        }
        catch (Exception e)
        {
            Console.WriteLine($"GetExamsAvg failed: {e.Message}");
        }

        return avg;
    }

    public float getMarkAvg()
    {
        float avg = 0;

        try
        {
            foreach (int mark in Marks)
            {
                avg += (float)mark;
            }

            avg /= Marks.Count;
        }
        catch (Exception e)
        {
            Console.WriteLine($"GetMrksAvg failed: {e.Message}");
        }

        return avg;
    }
    
    public float GetHwAvg()
    {
        float avg = 0;

        try
        {
            foreach(int hw in Hw)
            {
                avg += (float)hw;
            }

            avg /= Hw.Count;
        }
        catch(Exception e)
        {
            Console.WriteLine($"GetHwAvg failed: {e.Message}");
        }

        return avg;
    }

    public override string ToString()
    {
        return base.ToString() + $"Marks: {string.Join(" ", Marks)}\nHw: {string.Join(" ", Hw)}\nExams: {string.Join(" ", Exams)}";
    }

    public static Boolean operator ==(Student left, Student right)
    {
        if (ReferenceEquals(left, right))
            return true;

        else if ((Object)right != null)
        {
            return (left.getMarkAvg() == right.getMarkAvg());
        }

        return false;
    }

    public static Boolean operator !=(Student left, Student right)
    {
        return !(left == right);
    }

    public override Boolean Equals(object obj)
    {

        if (obj != null)
        {
            Student m = obj as Student;
            if (m != null)
            {
                return (m.getMarkAvg() == getMarkAvg());
            }
        }

        return false;
    }

    public int CompareTo(Student other)
    {
        if (other == null)
            throw new ArgumentNullException("Comparison to a null reference.");

        if (GetHwAvg() < other.GetHwAvg())
            return -1;

        if (GetHwAvg() == other.GetHwAvg())
            return 0;

        else
            return 1;

    }
}
