using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRayCast : MonoBehaviour
{
    public float range = 4;

    private void Update()
    {
        Vector3 dir = Vector3.forward;
        Ray ray = new Ray(transform.position, transform.TransformDirection(dir * range));
        Debug.DrawRay(transform.position, transform.TransformDirection(dir * range));

        if (Physics.Raycast(ray, out RaycastHit hit, range))
        {
            if (hit.collider.tag == "Enemy")
            {
                AIController stopChase = FindObjectOfType<AIController>();
                stopChase.chaseSpeed = 0f;
            }
            else
            {
                AIController stopChase = FindObjectOfType<AIController>();
                stopChase.chaseSpeed = 5f;
            }
        }
    }
}
