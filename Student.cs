using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

class Student
{
    public static int ID_gen = 0;

    string name;
    string lastName;

    public Address Address
    {
        get; set;
    }

    public DateTime BirthDate
    {
        get; set;
    }

    public List<int> Marks
    {
        get; set;
    }

    public List<int> Hw
    {
        get; set;
    }

    public List<int> Exams
    {
        get; set;
    }

    public int Id
    { get; }

    public string Name
    {
        get
        {
            return name;
        }
        private set
        {
            if (value.Length < 3)
            {
                throw new Exception("Names shorter than 3 characters not allowed.");
            }
            name = value;
        }
    }

    public string LastName
    {
        get
        {
            return lastName;
        }
        private set
        {
            if (value.Length < 3)
            {
                throw new Exception("Last names shorter than 3 characters not allowed.");
            }
            lastName = value;
        }
    }

    public Student() :
        this("defName", "defLastName")
    { }

    public Student(string name, string lastName) :
        this(name, lastName, new Address(), DateTime.Now)
    { }

    public Student(string name, string lastName, Address address, DateTime birthDate)
    {
        Name = name;
        LastName = lastName;
        Address = address;
        BirthDate = birthDate;

        Marks = new List<int>();
        Hw = new List<int>();
        Exams = new List<int>();


        generateCollections();

        Id = ++ID_gen;
    }

    private void generateCollections()
    {

        Random rand = new Random();

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
    


    public override string ToString()
    {
        return ($"{string.Join(" ", lastName)} {string.Join(" ", name)} |Address:{Address.ToString()}|Date of Birth: {BirthDate.ToString()}\nMarks: {string.Join(" ", Marks)}\nHw: {string.Join(" ", Hw)}\nExams: {string.Join(" ", Exams)}");
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
}
