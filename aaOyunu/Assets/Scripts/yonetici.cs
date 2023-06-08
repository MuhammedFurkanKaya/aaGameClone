using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class yonetici : MonoBehaviour
{
    public GameObject topPrefab;
    int toplamTopSayisi;
    List<Rigidbody2D> tumToplar = new List<Rigidbody2D>();

    float hiz = 20f;
    float ilkTopunYPozisyonu = -3f;

    public TextMeshProUGUI levelTxt;

    int level;

    ui ui;
    // Start is called before the first frame update
    void Start()
    {
        ui = GameObject.FindObjectOfType<ui>();


        levelKontrol();
        ilkToplariEkle();
    }


    void levelKontrol()
    {
        if (PlayerPrefs.HasKey("level"))
        {
            level = PlayerPrefs.GetInt("level");
        }
        else
        {
            level = 1;
            PlayerPrefs.SetInt("level", level);
        }

        levelTxt.text = level.ToString();
    }

    void ilkToplariEkle()
    {
        toplamTopSayisi = level * 3;

        for(int i=0; i<toplamTopSayisi; i++)
        {
            GameObject yeniTop = Instantiate(topPrefab);
            if (i == 0)
            {
                yeniTop.transform.position = new Vector2(0, ilkTopunYPozisyonu);
            }
            else
            {
                yeniTop.transform.position = new Vector2(0, tumToplar[i - 1].transform.position.y - (tumToplar[i - 1].GetComponent<CircleCollider2D>().bounds.size.y * 1.5f));
            }

            yeniTop.GetComponentInChildren<TextMeshProUGUI>().text = (toplamTopSayisi - i).ToString();
            tumToplar.Add(yeniTop.GetComponent<Rigidbody2D>());
        }
    }





    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && tumToplar.Count > 0)
        {
            tumToplar[0].velocity = Vector2.up * hiz;

            tumToplar.RemoveAt(0);

           
        }
        else if(tumToplar.Count <= 0)
        {
            Kazandin();
        }
    }

   public void toplarinPozisyonlariniGuncelle()
    {
        for (int i = 0; i < tumToplar.Count; i++)
        {
            if (i == 0)
            {
                tumToplar[0].transform.position = new Vector2(0, ilkTopunYPozisyonu);
            }
            else
            {
                tumToplar[i].transform.position = new Vector2(0, tumToplar[i - 1].transform.position.y - (tumToplar[i - 1].GetComponent<CircleCollider2D>().bounds.size.y * 2f));
            }
        }
    }
    void Kazandin()
    {
        ui.kazandinPanelGoster();
        this.enabled = false;
    }

   public void Kaybettin()
    {
        ui.kaybettinPanelGoster();
        this.enabled = false;
    }
}
