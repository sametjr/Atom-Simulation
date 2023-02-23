using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager instance = null;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("GameManager").AddComponent<GameManager>();
            }
            return instance;
        }
    }

    private void OnEnable()
    {
        instance = this;
    }

    #endregion
    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }
    public static int simulatedAtom = 0;
    public static void AtomClicked(int b)
    {
        simulatedAtom = b;
        SceneManager.LoadScene("model");
        // Debug.Log("loading model scene!");
        // Debug.Log("Clicked atom --> " + b);
    }

    public void LoadPeriodicTable()
    {
        SceneManager.LoadScene("PeriodicTable");
    }

    public void SpeedUpSimulation()
    {
        Time.timeScale += .2f;
    }

    public void SpeedDownSimulation()
    {
        Time.timeScale -= .2f;
    }
    
}
