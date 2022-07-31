using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KapiActive : MonoBehaviour
{

    public void KapiAcik()
    {
        gameObject.SetActive(false);
   
    }

 public void KapiKapali()
    {
        gameObject.SetActive(true);
    }

}
