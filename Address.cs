using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Address
{
    string country;
    string city;
    string street;
    int stNum;

    public Address() :
        this("defCountry", "defCity", "defStreet", 0)
    {
    }

    public Address(string country, string city, string street, int stNum)
    {
        this.country = country;
        this.city = city;
        this.street = street;
        this.stNum = stNum;
    }

    public override string ToString()
    {
        return ($"{this.country}, {this.city}, {this.street} {this.stNum}");
    }
}
