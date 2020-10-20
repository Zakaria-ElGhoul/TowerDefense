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
    public AudioClip hoverSFX;
    public AudioSource source;
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
    }
    
    void OnMouseOver()
    {
        source.PlayOneShot(hoverSFX);
        rend.material.color = HoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    void OnMouseDown()
    {
        if(turret != null)
        {
            Debug.Log("Can't build here!");
            return;
        }
        source.PlayOneShot(placeSFX);
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);
    }
}
