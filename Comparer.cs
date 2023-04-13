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

