using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


class Group
{
    const int DEFAULT_STUDENT_NUM = 10;
    const int MIN_EXAM_MARK = 7;

    string groupName;
    string specialization;
    int courseID;
    List<Student> students;

    private void generateStudents()
    {
        string[] firstNames = new string[] { "James", "Robert", "John", "Michael", "David", "William", "Richard", "Joseph", "Thomas", "Charles" };
        string[] lastNames = new string[] { "SMITH", "JOHNSON", "WILLIAMS", "BROWN", "JONES", "GARCIA", "MILLER", "DAVIS", "RODRIGUEZ", "MARTINEZ" };

        Random rand = new Random();

        for (int i = 0; i < DEFAULT_STUDENT_NUM; i++)
        {
            students.Add(new Student(firstNames[rand.Next(0, firstNames.Length - 1)], lastNames[rand.Next(0, lastNames.Length - 1)]));
        }
    }

    public Group() :
        this("GroupName", "Spec", 0)
    {
        students = new List<Student>();
        generateStudents();
    }

    public Group(string name, string spec, int courseID)
    {
        setGroupName(name);
        setSpec(spec);
        setID(courseID);
    }

    public Group(List<Student> students) :
        this("GroupName", "Spec", 0)
    {
        this.students = students;
    }

    public Group(Group group) :
        this(group.getGroupName(), group.getSpec(), group.getID())
    {
        students = group.students;
    }

    private string GetStudentNames()
    {
        string output = "";
        string[] names = new string[students.Count];

        for (int i = 0; i < names.Length; i++)
        {
            names[i] = students[i].getLastName() + " " + students[i].getName() + "| ID - " + students[i].getID();
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

        output += $"\t\tGroup Info:\nGroup Name: {groupName}|Specialization: {specialization}\n";
        output += "Students:\n";
        output += GetStudentNames();

        return output;
    }

    public void addStudent(Student student)
    {
        if (student == null)
        {
            return;
        }

        if (students.Contains(student))
        {
            Console.WriteLine("The student is already in the group.");
            return;
        }

        students.Add(student);
    }

    public void changeGroups(int ID, ref Group second)
    {
        if (second == null)
        {
            Console.WriteLine("Null reference not allowed.");
            return;
        }

        if (ID > students.Count || ID < 1)
        {
            Console.WriteLine("ID out of range.");
            return;
        }

        for (int i = 0; i < students.Count; i++)
        {
            if (students[i].getID() == ID)
            {
                second.students.Add(students[i]);
                students.Remove(students[i]);
            }
        }

    }

    public void exmatriculate()
    {
        for (int i = 0; i < students.Count; i++)
        {
            if (students[i].getExamsAvg() < MIN_EXAM_MARK)
            {
                students.Remove(students[i]);
            }
        }
    }

    public void exmatriculateWorst()
    {
        int indWorst = 0;

        for (int i = 1; i < students.Count; i++)
        {
            if (students[i].getMarkAvg() < students[indWorst].getMarkAvg())
            {
                indWorst = i;
            }
        }
        students.Remove(students[indWorst]);
    }

    public void setGroupName(string name)
    { this.groupName = name; }

    public void setSpec(string spec)
    { this.specialization = spec; }

    public void setID(int id)
    { this.courseID = id; }

    public string getGroupName()
    { return groupName; }

    public string getSpec()
    { return specialization; }

    public int getID()
    { return courseID; }

    public List<Student> GetStudents()
    { return students; }

    public static Boolean operator ==(Group left, Group right)
    {
        if (ReferenceEquals(left, right))
        {
            return true;
        }

        else if ((Object)right != null)
        {
            return (left.GetStudents().Count == right.GetStudents().Count);
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
                return (m.GetStudents().Count == GetStudents().Count);
            }
        }

        return false;
    }

}

