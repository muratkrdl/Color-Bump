using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform targetPos;
    [SerializeField] float lerpValue = 1f;

    public bool moveable;

    void Update() 
    {
        if(!moveable) { return; }

        Vector3 newPos = transform.position;

        newPos.z = Mathf.Lerp(newPos.z, targetPos.position.z, Time.deltaTime * lerpValue);

        if(transform.position.z >= 20 && transform.position.z <= 40)
            lerpValue = 0.04f;
        else if(transform.position.z >= 40 && transform.position.z <= 60)
            lerpValue = 0.05f;
        else if(transform.position.z >= 60 && transform.position.z <= 80)
            lerpValue = 0.06f;
        else if(transform.position.z >= 80 && transform.position.z <= 100)
            lerpValue = 0.07f;
        else if(transform.position.z >= 100 && transform.position.z <= 120)
            lerpValue = 0.08f;
        else if(transform.position.z >= 120 && transform.position.z <= 140)
            lerpValue = 0.09f;
        else if(transform.position.z >= 140 && transform.position.z <= 200)
            lerpValue = 0.10f;

        Vector3 lastPosition = new Vector3(0, 8f, newPos.z);
        transform.position = lastPosition;
    }

}
