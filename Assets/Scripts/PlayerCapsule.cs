using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCapsule : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    

    void Update()
    {
        transform.Translate(Axis.normalized.magnitude * Vector3.forward * moveSpeed * Time.deltaTime);

        if(Axis != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(Axis);
        }
        

    }
}
