using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

class Person
{
    string name;
    string lastName;


    public Person() :
        this("defName", "defLastName")
    { }

    public Person(string name, string lastName) :
        this(name, lastName, new Address(), DateTime.Now)
    { }

    public Person(string name, string lastName, Address address, DateTime birthDate)
    {
        Name = name;
        LastName = lastName;
        Address = address;
        BirthDate = birthDate;
    }


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

    public Address Address
    {
        get; set;
    }

    public DateTime BirthDate
    {
        get; set;
    }

    public override string ToString()
    {
        return ($"{string.Join(" ", LastName)} {string.Join(" ", Name)} |Address:{Address.ToString()}|Date of Birth: {BirthDate.ToString()}\n");
    }
}

