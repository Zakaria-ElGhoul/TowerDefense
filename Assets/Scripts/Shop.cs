using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public BuildManager buildManager;
    void Start()
    {
        buildManager = BuildManager.instance;
    }

    // Update is called once per frame
    public void purchaseStandardTurret()
    {
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }
    public void purchaseMissileLauncher()
    {
        buildManager.SetTurretToBuild(buildManager.missileLaucher);
    }
}
