using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;




namespace StudentClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Testing Group and Student methods

            //Group g1 = new Group();
            //Group g2 = new Group();
            //Group g3 = new Group();
            //
            //g1.GroupName = "Group 1";
            //g1.Specialization = "Computer Science";
            //g2.GroupName = "Group 2";
            //g2.Specialization = "Visual Computing";
            //
            //Console.WriteLine(g1.ToString());
            //
            //Student s1 = new Student("Henry", "EDWARDS");
            //Student s2 = new Student("Second", "STUDENT");
            //g1.addStudent(s1);
            //Console.WriteLine(g1.ToString());
            //
            //g1.changeGroups(9, ref g2);
            //
            //Console.WriteLine(g1.ToString());
            //Console.WriteLine(g2.ToString());
            //
            //g2.exmatriculate();
            //g2.exmatriculateWorst();
            //
            //Console.WriteLine(g2.ToString());
            //
            //if (g1 == g3)
            //    Console.WriteLine("Groups 1 and 3 have the same number of students.");
            //
            //
            //if (s1 != s2)
            //    Console.WriteLine("Students 1 and 2 have different average scores.");
            //
            //Console.WriteLine(g1.Equals(g2));
            //Console.WriteLine(s1.Equals(s2));

            #endregion

            #region Testing Exceptions

            Student testStudent = new Student("Christoph", "JAMES");
            Group testGroup = new Group();
            Group testGroup2 = new Group();
            Group testGroupNull = null;
            Student testStudentNull = null;
            List<int> testList = new List<int>{1,2,3,4,5,6,7,8,9,10,11 };
            List<int> testListNull = null;


            Console.WriteLine($"{testStudent.getExamsAvg()}"); //cant get avg if exams list is null
            testGroup.addStudent(testStudentNull);             // cant add null obj
            testGroup.changeGroups(1, ref testGroupNull);      // second group null
            testGroup.changeGroups(3000, ref testGroup2);      // student id 3000 - out of range 
            testGroup.exmatriculate();                         // if students == null throw nullref



            #endregion


            #region Testing indexers

            testGroup[1] = testStudent;
            Console.WriteLine(testGroup.ToString());
            Console.WriteLine(testStudent.ToString());
            //Console.WriteLine(testGroup[54]);         // index out of range exception
            Console.WriteLine(testGroup["Christoph"]);

            #endregion

            Console.Read();
        }
    }
}
