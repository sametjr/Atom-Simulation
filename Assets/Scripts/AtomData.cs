using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AtomData : MonoBehaviour
{
    public AtomTableView atomTableView;
    [SerializeField] TMP_Text atomNumber, atomSymbol, atomName, atomMass;

    public void Init()
    {

        atomNumber.text = atomTableView.atomNumber.ToString();
        atomSymbol.text = atomTableView.atomSymbol;
        atomName.text = atomTableView.atomName;
        atomMass.text = atomTableView.atomMass.ToString();

    }
}
