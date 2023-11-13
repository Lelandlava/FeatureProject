using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject rocketPrefab;
    public Rigidbody rb;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Firing");
            Shoot();
        }
    }
    void Shoot()
    {
        Instantiate(rocketPrefab, FirePoint.position, FirePoint.rotation);
    }
}
