// using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtomInitializer : MonoBehaviour
{
    [SerializeField] private GameObject electronPrefab;
    [SerializeField] private int atomNo;
    [SerializeField] private List<ParticleSystem> rings;
    [SerializeField] private Button btn;
    [SerializeField] private Button speedUpBtn;
    [SerializeField] private Button SpeedDownBtn;
    private List<GameObject> electrons;

    [SerializeField] private Color[] trailColors;
    private int[] layerDistrubution = { 2, 8, 8, 18 };

    private void Start()
    {
        electrons = new List<GameObject>();
        atomNo = GameManager.simulatedAtom;
        AddEventListeners();
        
        foreach (ParticleSystem layer in rings) layer.gameObject.SetActive(false);
        InitElectrons();
        RotateLayers();
    }

    private void AddEventListeners()
    {
        btn.onClick.AddListener(delegate ()
        {
            GameManager.Instance.LoadPeriodicTable();
        });

        speedUpBtn.onClick.AddListener(delegate ()
        {
            GameManager.Instance.SpeedUpSimulation();
        });

        SpeedDownBtn.onClick.AddListener(delegate ()
        {
            GameManager.Instance.SpeedDownSimulation();
        });
    }

    private void InitElectrons()
    {

        int currentLayer = 1;
        while (true)
        {
            Debug.Log(rings[currentLayer - 1].gameObject.activeInHierarchy + " -- STEP -- " + currentLayer);
            rings[currentLayer - 1].gameObject.SetActive(true);
            CreateRingElectrons(currentLayer);
            ArrangeElectronSpeedForLayer(rings[currentLayer - 1]);
            currentLayer++;
            if (atomNo == 0) break;
        }


    }

    private void ArrangeElectronSpeedForLayer(ParticleSystem _ring)
    {
        _ring.gameObject.GetComponent<LayerRotate>().electronSpeed = 1000 / _ring.gameObject.transform.childCount;
    }

    private void CreateRingElectrons(int _ringNumber)
    {
        // I will decrease the _ringNumber by 1 to use it as index, the passed parameter indicates 
        // which layer should be created, starting at 1. 

        _ringNumber--;

        float ringRadius = rings[_ringNumber].shape.radius;
        float alpha = 0;

        float electronCountOnRing = (atomNo > layerDistrubution[_ringNumber]) ? layerDistrubution[_ringNumber] : atomNo;
        float increment = 360 / electronCountOnRing;

        for (int i = 0; i < electronCountOnRing; i++)
        {
            if (atomNo == 0) return;


            Vector3 pos = new Vector3();
            pos.x = Mathf.Sin(Mathf.Deg2Rad * alpha) * ringRadius;
            pos.y = 0;
            pos.z = Mathf.Cos(Mathf.Deg2Rad * alpha) * ringRadius;

            alpha += increment;

            GameObject electron = Instantiate(electronPrefab, pos, Quaternion.identity);
            electron.transform.parent = rings[_ringNumber].gameObject.transform;

            electrons.Add(electron);


            atomNo--;
        }
    }

    private void RotateLayers()
    {
        rings[0].gameObject.transform.Rotate(new Vector3(0, 0, 25), Space.World);
        rings[1].gameObject.transform.Rotate(new Vector3(0, 0, -25), Space.World);
        rings[2].gameObject.transform.Rotate(new Vector3(0, 0, 15), Space.World);
        rings[3].gameObject.transform.Rotate(new Vector3(0, 0, -15), Space.World);
        // 
    }

    
}
