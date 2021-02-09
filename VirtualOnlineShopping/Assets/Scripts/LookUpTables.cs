using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookUpTables : MonoBehaviour
{
    public Dictionary<int, int> InchesDefault = new Dictionary<>() { get; }
    public HashSet<int> ReservedKeys { get; }

    public void LookupTable()
    {
        inchesDefault.Add(0, 31, 24, 33);
        inchesDefault.Add(1, 32, 25, 34);
        inchesDefault.Add(2, 33, 26, 35);
        inchesDefault.Add(3, 35, 28, 37);
        inchesDefault.Add(4, 37, 30, 39);
        inchesDefault.Add(5, 39, 31, 41);
        inchesDefault.Add(6, 41, 33, 43);
        inchesDefault.Add(7, 44, 36, 46);

        ReservedKeys = new HashSet<int>();
    }

    public string Lookup(int key)
    {
        return (ReservedKeys.Contains(key))
           ? null
           : inchesDefault[key];
    }
}
