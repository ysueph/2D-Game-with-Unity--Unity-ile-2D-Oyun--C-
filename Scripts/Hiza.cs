using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiza : MonoBehaviour
{
    [SerializeField] private GameObject[] yollar;
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f;

    private void Update()
    {
        if (Vector2.Distance(yollar[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= yollar.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, yollar[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
