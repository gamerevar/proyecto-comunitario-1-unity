using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAttack : MonoBehaviour
{
    public GameObject laserPrefab;
    public GameObject crystalPrefab;

    const float laserAttackRate = 1f;
    const float crystalAttackRate = 4f;
    
    private float laserAttackCounter;
    private float crystalAttackCounter;

    private Transform shootPivot;

    void Start()
    {
        laserAttackCounter = laserAttackRate;
        crystalAttackCounter = crystalAttackRate;
        shootPivot = GetComponentInChildren<RotateTowardsMouse>().transform;
    }

    void Update()
    {
        if (laserAttackCounter < laserAttackRate) 
            laserAttackCounter += Time.deltaTime;
        
        if (crystalAttackCounter < crystalAttackRate) 
            crystalAttackCounter += Time.deltaTime;

        // Left click
        if (Input.GetMouseButtonDown(0))
        {
            if(laserAttackCounter >= laserAttackRate)
            {
                Instantiate(laserPrefab, shootPivot.position, shootPivot.rotation);
                laserAttackCounter = 0;
            }
        }

        // Right click
        if (Input.GetMouseButtonDown(1))
        {
            if (crystalAttackCounter >= crystalAttackRate)
            {
                Instantiate(crystalPrefab, shootPivot.position, shootPivot.rotation);
                crystalAttackCounter = 0;
            }
        }
    }
}
