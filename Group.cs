using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


class Group
{
    const int DEFAULT_STUDENT_NUM = 10;
    const int MIN_EXAM_MARK = 7;

    string groupName;

    public string GroupName
    {
        get
        {
            return groupName;
        }
        set
        {
            if (value.Length < 3)
                throw new Exception("Group name under 3 characters not allowed.");

            groupName = value;
        }
    }

    public string Specialization
    {
        get; set;
    }

    public int CourseId
    {
        get; private set;
    }

    public List<Student> Students
    {
        get; set;
    }

    private void generateStudents()
    {
        string[] firstNames = new string[] { "James", "Robert", "John", "Michael", "David", "William", "Richard", "Joseph", "Thomas", "Charles" };
        string[] lastNames = new string[] { "SMITH", "JOHNSON", "WILLIAMS", "BROWN", "JONES", "GARCIA", "MILLER", "DAVIS", "RODRIGUEZ", "MARTINEZ" };

        Random rand = new Random();

        for (int i = 0; i < DEFAULT_STUDENT_NUM; i++)
        {
            Students.Add(new Student(firstNames[rand.Next(0, firstNames.Length - 1)], lastNames[rand.Next(0, lastNames.Length - 1)]));
        }
    }

    public Group() :
        this("GroupName", "Spec", 0)
    {
        Students = new List<Student>();
        generateStudents();
    }

    public Group(string name, string spec, int courseID)
    {
        GroupName = name;
        Specialization = spec;
        CourseId = courseID;
    }

    public Group(List<Student> students) :
        this("GroupName", "Spec", 0)
    {
        Students = students;
    }

    public Group(Group group) :
        this(group.GroupName, group.Specialization, group.CourseId)
    {
        Students = group.Students;
    }

    private string GetStudentNames()
    {
        string output = "";
        string[] names = new string[Students.Count];

        try
        {
            for (int i = 0; i < names.Length; i++)
            {
                names[i] = Students[i].LastName + " " + Students[i].Name + "| ID - " + Students[i].Id;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"GetStudentNames failed: {e.Message}");
            return output;
        }

        Array.Sort(names);

        foreach (string name in names)
        {
            output += $"{name}\n";
        }


        return output;
    }

    public override string ToString()
    {
        string output = "";

        output += $"\t\tGroup Info:\nGroup Name: {groupName}|Specialization: {Specialization}\n";
        output += "Students:\n";
        output += GetStudentNames();

        return output;
    }

    public void addStudent(Student student)
    {


        try
        {
            if (student == null)
                throw new Exception("Cant add a null object to the student list.");


            if (Students.Contains(student))
            {
                Console.WriteLine("The student is already in the group.");
                return;
            }
            Students.Add(student);
        }
        catch (Exception e)
        {
            Console.WriteLine($"AddStudent failed: {e.Message}");
        }

    }

    public void changeGroups(int ID, ref Group second)
    {
        
        try
        {
            if (second == null)
                throw new NullReferenceException();

            if (ID > Students.Count || ID < 1)
                throw new IndexOutOfRangeException();

            for (int i = 0; i < Students.Count; i++)
            {
                if (Students[i].Id == ID)
                {
                    second.Students.Add(Students[i]);
                    Students.Remove(Students[i]);
                }
            }

        }
        catch (NullReferenceException)
        {
            Console.WriteLine("Cant change groups: Second group is null.");
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Cant change groups: Index out of range.");
        }
    }

    public void exmatriculate()
    {
        try
        {
        for (int i = 0; i < Students.Count; i++)
        {
            if (Students[i].getExamsAvg() < MIN_EXAM_MARK)
            {
                Students.Remove(Students[i]);
            }
        }
        }
        catch (NullReferenceException e)
        {
            Console.WriteLine($"Exmatriculate failed: {e.Message}");
        }

}

public void exmatriculateWorst()
    {

        try
        {
            int indWorst = 0;

            for (int i = 1; i < Students.Count; i++)
            {
                if (Students[i].getMarkAvg() < Students[indWorst].getMarkAvg())
                {
                    indWorst = i;
                }
            }
            Students.Remove(Students[indWorst]);
        }
        catch(NullReferenceException e)
        {
            Console.WriteLine($"ExmatriculateWorst failed: {e.Message}");
        }
    }

   

    public static Boolean operator ==(Group left, Group right)
    {
        if (ReferenceEquals(left, right))
        {
            return true;
        }

        else if ((Object)right != null)
        {
            return (left.Students.Count == right.Students.Count);
        }

        return false;
    }

    public static Boolean operator !=(Group left, Group right)
    {
        return !(left == right);
    }

    public override Boolean Equals(object obj)
    {
        if (obj != null)
        {
            Group m = obj as Group;
            if (m != null)
            {
                return (m.Students.Count == Students.Count);
            }
        }

        return false;
    }

}

