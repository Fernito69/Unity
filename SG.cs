using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SG : MonoBehaviour
{
    public int pelletCount = 15;
    public float spreadAngle = 5;
    public int pelletFireVelocity=3000;
    public GameObject weaponHolder;
    public GameObject pellet;
    public Transform BarrelExit;    
    List<Quaternion> pellets;


    void Awake()
    {
       //?
    }

    
    void Update()
    {

        if(Input.GetButtonDown("Fire1"))
        {
            fire();            
        }

    }

    
    void fire()
    {
        int selectedPowerLevel = weaponHolder.transform.GetComponent<WeaponSwitching>().selectedPowerLevel;
        int newPelletCount = pelletCount + (selectedPowerLevel * 5);
        float newSpreadAngle = spreadAngle + selectedPowerLevel * .75f;
        int newPelletFireVelocity = pelletFireVelocity + selectedPowerLevel * 1000;

        pellets = new List<Quaternion>(newPelletCount);

        for (int i = 0; i < newPelletCount; i++)
        {
            pellets.Add(Quaternion.Euler(Vector3.zero));
        }               

        for (int i = 0; i < newPelletCount; i++)
        {
            pellets[i] = Random.rotation;
            GameObject p = Instantiate(pellet, BarrelExit.position, BarrelExit.rotation);            
            p.transform.rotation = Quaternion.RotateTowards(p.transform.rotation, pellets[i], newSpreadAngle);
            p.GetComponent<Rigidbody>().AddForce(p.transform.forward * newPelletFireVelocity);
            Destroy(p, 3f);            
        }

    }
}
