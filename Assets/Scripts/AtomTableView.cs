using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Atom", menuName = "Atom", order = 1)]
public class AtomTableView : ScriptableObject
{
    public int atomNumber;
    public string atomSymbol;
    public string atomName;
    public float atomMass;

}
