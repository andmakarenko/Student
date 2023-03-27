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
    Address address;
    DateTime birthDate;
    List<int> marks;
    List<int> hw;
    List<int> exams;
    int id;

    public Student() :
        this("defName", "defLastName")
    { }

    public Student(string name, string lastName) :
        this(name, lastName, new Address(), DateTime.Now)
    { }

    public Student(string name, string lastName, Address address, DateTime birthDate)
    {
        setName(name);
        setLastName(lastName);
        setAddress(address);
        setBirthDate(birthDate);

        marks = new List<int>();
        hw = new List<int>();
        exams = new List<int>();


        generateCollections();

        id = ++ID_gen;
    }

    private void generateCollections()
    {

        Random rand = new Random();

        try
        {
            for (int i = 0; i < 10; i++)
            {
                marks.Add(rand.Next(2, 12));
                hw.Add(rand.Next(2, 12));
                exams.Add(rand.Next(2, 12));
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
            foreach (int mark in getExams())
            {
                avg += (float)mark;
            }

            avg /= getExams().Count;
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
            foreach (int mark in getMarks())
            {
                avg += (float)mark;
            }

            avg /= getMarks().Count;
        }
        catch (Exception e)
        {
            Console.WriteLine($"GetMrksAvg failed: {e.Message}");
        }

        return avg;
    }

    public string getName()
    { return name; }

    public void setName(string name)
    { this.name = name; }

    public string getLastName()
    { return lastName; }

    public void setLastName(string lastName)
    { this.lastName = lastName; }

    public Address getAddress()
    { return address; }

    public void setAddress(Address address)
    { this.address = address; }

    public DateTime getBirthDate()
    { return birthDate; }

    public void setBirthDate(DateTime birthDate)
    { this.birthDate = birthDate; }

    public List<int> getMarks()
    { return marks; }

    public void setMarks(List<int> marks)
    { this.marks = marks; }
    
    public List<int> getHw()
    { return hw; }

    public void setHw(List<int> hw)
    { this.hw = hw; }

    public List<int> getExams()
    { return exams; }

    public void setExams(List<int> exams)
    { this.exams = exams; }

    public int getID()
    { return id; }

    public override string ToString()
    {
        return ($"{string.Join(" ", lastName)} {string.Join(" ", name)} |Address:{address.ToString()}|Date of Birth: {birthDate.ToString()}\nMarks: {string.Join(" ", marks)}\nHw: {string.Join(" ", hw)}\nExams: {string.Join(" ", exams)}");
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
