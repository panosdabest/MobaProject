using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerDetection : MonoBehaviour {
    [SerializeField] LayerMask layerOfInterest;
    [SerializeField] float maxDistance;
    Hero hero;
    public bool detectedObject;
    Ray ray;
    RaycastHit raycastHit;
    GameObject hitResult;
    private void Start() {
        hero = GetComponent<Hero>();    
    }
    // Update is called once per frame
    void Update() {
        if (hero.activeHero) {
            DetectObject();
        }
    }
    public void DetectObject() {
        ray = new Ray(transform.position, transform.forward);
        detectedObject = Physics.Raycast(ray, out raycastHit, maxDistance, layerOfInterest);
        if(detectedObject) {
            hitResult = raycastHit.collider.gameObject;
        }
    }
    public GameObject otherHero() {
        if(hitResult != null) {
            return hitResult;
        }
        return default;
    }
    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.forward);
    }
}
