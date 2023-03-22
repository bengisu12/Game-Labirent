using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopKonrtol : MonoBehaviour
{
    public UnityEngine.UI.Button btn;
    public UnityEngine.UI.Text zaman,can,durum;
    private Rigidbody rg;
    public float hız=1.5f;
    float zamanSayacı=20;
    int canSayacı=3;
    bool oyunDevam=true;
    bool oyunTamam=false;
    // Start is called before the first frame update
    void Start()
    {
        can.text=canSayacı + "";
        rg = GetComponent <Rigidbody>();        
    }

    // Update is called once per frame
    void Update()
    {
        if(oyunDevam && !oyunTamam){
            zamanSayacı-= Time.deltaTime;
            zaman.text = (int)zamanSayacı + "";
            }else if(!oyunTamam){
                durum.text="OYUN TAMAMLANAMADI";
                btn.gameObject.SetActive(true);
        }
        if (zamanSayacı<0) 
        oyunDevam=false;
        
    }
    void FixedUpdate(){
        if(oyunDevam && !oyunTamam){
        float yatay = Input.GetAxis("Horizontal");
        float dikey= Input.GetAxis("Vertical");
        Vector3 kuvvet = new Vector3 (yatay,0,dikey);
        rg.AddForce(kuvvet*hız);
        }else{
            rg.velocity=Vector3.zero;
            rg.angularVelocity=Vector3.zero;
        }

    }
    void OnCollisionEnter(Collision cls){
        string ojbIsmi = cls.gameObject.name;
        if (ojbIsmi.Equals ("bitiş")){
            oyunTamam=true;
            durum.text="TEBRİKLER. OYUN TAMAMLANDI";
            btn.gameObject.SetActive(true);
            //print("Oyun Tamamlandı.");
        }
        else if(!ojbIsmi.Equals("labirent zemin")&& !ojbIsmi.Equals("zemin")){
            canSayacı-=1;
            can.text=canSayacı+"";
            if(canSayacı==0)
            oyunDevam=false;
        }
    }
}
