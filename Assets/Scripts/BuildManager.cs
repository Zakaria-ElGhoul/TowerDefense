using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    public GameObject standardTurretPrefab;
    public GameObject missileLaucher;

    private GameObject turretToBuild;
    void Awake()
    {
        if(instance != null)
        {
            Debug.Log("Cant have more than 1!");
            return;
        }
        instance = this; 
    }


    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }
}
