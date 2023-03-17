using System;
using System.Collections;

namespace Laba_12
{
    public class SortbyName : IComparer
    {
        int IComparer.Compare(object ob1, object ob2)
        {
            Place s1 = (Place)ob1;
            Place s2 = (Place)ob2;
            if (s1 != null && s2 != null)
                return String.Compare(s1.name, s2.name);
            return -2;
        }
    }
}

