using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Pathfinding : MonoBehaviour
{
    //Private Vars
    private NavMeshPath path;
    private Vector3 myPosition;
    private Vector3 myTarget;
    private Vector3 corner;



    // Start is called before the first frame update
    void Start()
    {
        path = new NavMeshPath();
    }

    // Update is called once per frame
    void Update()
    {
        // Calculates a path from my_Position to target_Position and outputs a Path(Vector[]"array") in the Var path
        NavMesh.CalculatePath(myPosition, myTarget, NavMesh.AllAreas, path);

        for (int i = 0; i < path.corners.Length - 1; i++)
        {
            Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.green);
        }
    }

    public Vector3 GetCorner()
    {
        /*  Path.corners[0] is always == my_Position Vector3 - Loops throught the Array from the index 1
            Returns the path with all the available corners
        */
        for (int i = 1; i < path.corners.Length;)
        {
            corner = path.corners[i];
            if (Vector3.Distance(myPosition, corner) > 0)
            {
                return corner;
            }
            else
            {
                i++;
            }
        }
        return myPosition;
    }
    public void SetPath(Vector3 myPosition, Vector3 myTarget)
    {
        //Method for setting the Vars 
        this.myPosition = myPosition;
        this.myTarget = myTarget;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(corner, 0.3f);
    }
}
