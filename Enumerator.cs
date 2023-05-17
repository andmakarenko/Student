using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class StudentEnumerator : IEnumerator<Student>
{
    List<Student> students;
    int position = -1;

    public StudentEnumerator(List<Student> students)
    {
        this.students = students;
    }

    public Student Current
    {
        get
        {
            if (position == -1 || position >= students.Count)
                throw new ArgumentException();
            return students[position];
        }
    }

    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
        if (position < students.Count - 1)
        {
            position++;
            return true;
        }
        else
            return false;
    }

    public void Reset() => position = -1;
    public void Dispose() { }

}
