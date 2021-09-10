using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OyunYoneticisi : MonoBehaviour
{
    GameObject donenCember;
    GameObject anaCember;
    public Animator animator;
    public Text DonenCemberLevel;
    public Text bir;
    public Text iki;
    public Text üc;
    public int KacTaneKucukCemberOlsun;
    bool kontrol = true;
    void Start()
    {
        PlayerPrefs.SetInt("kayit", int.Parse(SceneManager.GetActiveScene().name));
        donenCember = GameObject.FindGameObjectWithTag("donencembertag");
        anaCember = GameObject.FindGameObjectWithTag("anacembertag");
        DonenCemberLevel.text = SceneManager.GetActiveScene().name;

        if (KacTaneKucukCemberOlsun<2)
        {
            bir.text = KacTaneKucukCemberOlsun + "";
        }
        else if (KacTaneKucukCemberOlsun<3)
        {
            bir.text = KacTaneKucukCemberOlsun + "";
            iki.text = (KacTaneKucukCemberOlsun - 1) + "";
        }
        else  
        {
            bir.text = KacTaneKucukCemberOlsun + "";
            iki.text = (KacTaneKucukCemberOlsun - 1) + "";
            üc.text = (KacTaneKucukCemberOlsun - 2) + "";
        }
        
    }
    public void KucukCemberlerdeTextGosterme()
    {
        KacTaneKucukCemberOlsun--;
        if (KacTaneKucukCemberOlsun < 2)
        {
            bir.text = KacTaneKucukCemberOlsun + "";
            iki.text = "";
            üc.text = "";
        }
        else if (KacTaneKucukCemberOlsun < 3)
        {
            bir.text = KacTaneKucukCemberOlsun + "";
            iki.text = (KacTaneKucukCemberOlsun - 1) + "";
            üc.text = "";
        }
        else
        {
            bir.text = KacTaneKucukCemberOlsun + "";
            iki.text = (KacTaneKucukCemberOlsun - 1) + "";
            üc.text = (KacTaneKucukCemberOlsun - 2) + "";
        }
        if (KacTaneKucukCemberOlsun==0)
        {
            StartCoroutine(yenilevel());
        }

    }
    IEnumerator yenilevel()
    {
        donenCember.GetComponent<Dondurme>().enabled = false;
        anaCember.GetComponent<Anacemberkod>().enabled = false;
        yield return new WaitForSeconds(0.5f); 
        
        if (kontrol)
        {
            animator.SetTrigger("YeniLevel");
            yield return new WaitForSeconds(1.4f);
            SceneManager.LoadScene(int.Parse(SceneManager.GetActiveScene().name) + 1);

        }
    }


    public void OyunBitti()
    {
        StartCoroutine(CagrilanMetot());
    }

    IEnumerator CagrilanMetot()
    {
        donenCember.GetComponent<Dondurme>().enabled = false;
        anaCember.GetComponent<Anacemberkod>().enabled = false;
        animator.SetTrigger("oyunbitti");
        kontrol = false;
        yield return new WaitForSeconds(1);
        
        
        SceneManager.LoadScene("anaMenu");
    }


}
