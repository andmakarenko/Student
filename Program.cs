﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace StudentClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Group g1 = new Group();
            Group g2 = new Group();
            Group g3 = new Group();

            g1.setGroupName("Group 1");
            g1.setSpec("Computer Science");
            g2.setGroupName("Group 2");
            g2.setSpec("Visual Computing");

            Console.WriteLine(g1.ToString());

            Student s1 = new Student("Henry", "EDWARDS");
            Student s2 = new Student("Second", "STUDENT");
            g1.addStudent(s1);
            Console.WriteLine(g1.ToString());

            g1.changeGroups(9, ref g2);

            Console.WriteLine(g1.ToString());
            Console.WriteLine(g2.ToString());

            g2.exmatriculate();
            g2.exmatriculateWorst();

            Console.WriteLine(g2.ToString());

            if (g1 == g3)
                Console.WriteLine("Groups 1 and 3 have the same number of students.");


            if (s1 != s2)
                Console.WriteLine("Students 1 and 2 have different average scores.");

            Console.WriteLine(g1.Equals(g2));
            Console.WriteLine(s1.Equals(s2));


            Console.Read();
        }
    }
}