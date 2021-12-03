using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    RaycastHandler raycastHandler;
    Pathfinding pathfinding;
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;

    Quaternion targetRotation;
    Quaternion rotation;
    Quaternion finalRotation;


    // Start is called before the first frame update
    void Start()
    {
        raycastHandler = GetComponent<RaycastHandler>();
        pathfinding = GetComponent<Pathfinding>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }



    public void Move()
    {
        pathfinding.SetPath(transform.position, raycastHandler.GetPositionClicked());

        if (Vector3.Distance(transform.position, pathfinding.GetCorner()) > 0)
        {
            if (pathfinding.GetCorner() - transform.position != Vector3.zero)
            {
                //Calculates the rotation we want the player to look at when moving
                targetRotation = Quaternion.LookRotation(pathfinding.GetCorner() - transform.position);
            }

        }

        // Smooth rotation towards the target point.
        rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        finalRotation = Quaternion.Euler(new Vector3(0f, rotation.eulerAngles.y, 0f));
        //Rotate
        transform.rotation = finalRotation;

        transform.position = Vector3.MoveTowards(transform.position, pathfinding.GetCorner(), speed * Time.deltaTime);

    }
}
