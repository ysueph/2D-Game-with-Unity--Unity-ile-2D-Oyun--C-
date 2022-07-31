using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kameraHareket : MonoBehaviour
{
    [SerializeField] private Transform hero;
    void Update()
    {
        transform.position = new Vector3(hero.position.x, hero.position.y, transform.position.z);
    }
}

