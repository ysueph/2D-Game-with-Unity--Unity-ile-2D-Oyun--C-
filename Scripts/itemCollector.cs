using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemCollector : MonoBehaviour
{
    private int muz = 0;

   
    [SerializeField] private Text TexMuz;
    [SerializeField] private Text TextUyari;
    [SerializeField] private KapiActive kapi;
    [SerializeField] private AudioSource collectionSoundEffect;
 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Muz"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            muz++;
            TexMuz.text = "Muzlar: " + muz;
        }

        if (muz == 5)
        {
            kapi.KapiAcik();
            TextUyari.text = "Kapý Açýldý!!";

        }
        else
        {
            kapi.KapiKapali();
            TextUyari.text = "";
        }
    }
}
