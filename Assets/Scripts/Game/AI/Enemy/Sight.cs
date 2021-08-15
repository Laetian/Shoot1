using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
{
    public float distance;
    public float angle;

    public LayerMask targetLayer;
    public LayerMask obstacleLayers;

    public Collider detectedTarget;

    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, distance, targetLayer);

        detectedTarget = null; // Cleaning the condition 

        //First filter, distance
        foreach(Collider collider in colliders) // Equals to loop for
        {
            //TODO: Do things to collider

            Vector3 directionToCollider = Vector3.Normalize(collider.bounds.center - transform.position);

            //Angle between vector vision and vector objective 
            float angleToCollider = Vector3.Angle(transform.forward, directionToCollider);
            //cos(angle)= u.v / ||u||.||v||

            //If angle is minor than vision angle
            if(angleToCollider< angle)
            {
                //TODO:Object Inside the vision angle

                //Check there aren't obstacles between enemy and objective 
                if(!Physics.Linecast(transform.position, collider.bounds.center, obstacleLayers))
                {
                    //Save the reference of detected target
                    detectedTarget = collider;
                    break;//Avoiding the enemy becomes crazy between targets in case more than 1 in sight
                }
            }
        }
        /*for(int i =0; i< colliders.Length; i++)   
        {
            Collider collider = colliders[i];
            //TODO: Do things to collider
        }*/
    }
}