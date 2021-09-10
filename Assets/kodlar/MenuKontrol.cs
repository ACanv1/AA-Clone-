using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuKontrol : MonoBehaviour
{
    void Start()
    {
        //PlayerPrefs.DeleteAll();   
    }
    public void OyunaGit()
        
    {
        int KayitliLevel = PlayerPrefs.GetInt("kayit");
        if (KayitliLevel==0)
        {
            SceneManager.LoadScene(KayitliLevel+1);
        }
        else
        {
            SceneManager.LoadScene(KayitliLevel);
        }
            
    }
    public void OyundanÇik()
    {
        Debug.Log("oyundan cıktın"); 
        Application.Quit();
    }
}
