using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ui : MonoBehaviour
{
    public GameObject kazandinPnl,kaybettinPnl;


    public void kazandinPanelGoster()
    {
        kazandinPnl.SetActive(true);
    }

    public void kaybettinPanelGoster()
    {
        kaybettinPnl.SetActive(true);
    }

    public void DevamEtBTN()
    {
        int simdikiLevel = PlayerPrefs.GetInt("level");
        simdikiLevel++;

        PlayerPrefs.SetInt("level", simdikiLevel);

        SceneManager.LoadScene(0);
    }

    public void TekrarEtBTN()
    {
       
        SceneManager.LoadScene(0);
    }
}
