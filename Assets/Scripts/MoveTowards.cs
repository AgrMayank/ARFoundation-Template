using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    public Transform target;

    public float speed = 0.5f;

    void Start()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("MainCamera").transform;
        }
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x, target.position.y - 5, target.position.z), speed * Time.deltaTime);
    }
}