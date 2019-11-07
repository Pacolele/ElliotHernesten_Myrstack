using System;
using System.Collections.Generic;
using System.Text;

class Ants
{
    private string name;
    private int legs;

    public Ants(string name, int legs)
    {
        this.name = name;
        this.legs = legs;
    }
    
    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }

    public int Legs
    {
        get
        {
            return legs;
        }
        set
        {
            legs = value;
        }
    }
    public override string ToString()
    {
        name = name.Substring(0, 1).ToUpper() + name.Substring(1).ToLower();
        return name + ", " + legs;
    }
    
}