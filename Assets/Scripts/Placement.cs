using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placement : MonoBehaviour
{
    // Start is called before the first frame update
    public Material hoverMaterial;
    public Material render;
    public bool placeAble;
    
    void Start()
    {
        render = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        if (!placeAble || GameManager.instance.turretToBuild==null) return;
        GetComponent<Renderer>().material = hoverMaterial;
    }

    private void OnMouseExit()
    {
        GetComponent<Renderer>().material = render;
    }

    private void OnMouseDown()
    {
        if (!placeAble || GameManager.instance.turretToBuild == null) return;
        Instantiate(Resources.Load("Turret"),new Vector3(transform.position.x,0,transform.position.z),transform.rotation);
        placeAble = false;
        GameManager.instance.turretToBuild = null;
    }

}
