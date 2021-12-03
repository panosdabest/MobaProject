using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastHandler : MonoBehaviour
{
    private RaycastHit hitHover;
    private RaycastHit hitLast;
    private Vector3 positionClicked;

    [SerializeField] LayerMask hoverLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        RaycastHover();
    }

    public void RaycastHover()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitHover, Mathf.Infinity, hoverLayer))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (LayerCheck(hitHover, "Ground"))
                {
                    positionClicked = hitHover.point;
                }
                
            }
        }
    }

    //Checks if a hit has a layer
    public bool LayerCheck(RaycastHit hit, string layerName)
    {
        if (LayerMask.NameToLayer(layerName).Equals(hit.transform.gameObject.layer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //Returns the position Clicked
    public Vector3 GetPositionClicked()
    {
        return positionClicked;
    }
}
