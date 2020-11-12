using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField]
    public Color HoverColor;
    public Color startColor;

    private Renderer rend;

    private GameObject turret;

    public BuildManager buildManager;

    public AudioClip placeSFX;
    public AudioSource source;
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
        buildManager = BuildManager.instance;   
    }
    
    void OnMouseOver()
    {
        if (buildManager.GetTurretToBuild() == null)
            return;
        rend.material.color = HoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    void OnMouseDown()
    {
        if(buildManager.GetTurretToBuild() == null)
            return;

        if(turret != null)
        {
            Debug.Log("Can't build here!");
            return;
        }
        source.PlayOneShot(placeSFX);
        GameObject turretToBuild = buildManager.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);
    }
}
