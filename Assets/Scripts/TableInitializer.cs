using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class TableInitializer : MonoBehaviour
{
    [SerializeField] private List<AtomTableView> atomDatas;
  

    private void Start()
    {
        List<AtomData> atomData = GetComponentsInChildren<AtomData>().ToList();

        for (int i = 0; i < atomDatas.Count; i++)
        {
            atomData[i].atomTableView = atomDatas[i];
            atomData[i].Init();

            Button btn = atomData[i].GetComponent<Button>();
            int b = i;
            btn.onClick.AddListener(delegate ()
            {
                GameManager.AtomClicked(b + 1);
            });
            // atomData[i].GetComponent<Button>().onClick.Invoke();
        }

    }
}
