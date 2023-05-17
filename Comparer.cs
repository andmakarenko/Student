using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


class NameComparer : IComparer<Student>
{
    public int Compare(Student left, Student right)
    {
        return (left.Name.CompareTo(right.Name));
    }
}

class ExamsComparer : IComparer<Student>
{
    public int Compare(Student left, Student right)
    {
        if (left == null || right == null)
            throw new ArgumentNullException();

        if (left.getExamsAvg() > right.getExamsAvg())
            return -1;
        else if (left.getExamsAvg() == right.getExamsAvg())
            return 0;
        else
            return 1;
    }
}


