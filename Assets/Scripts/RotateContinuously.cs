using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateContinuously : MonoBehaviour
{
    public float speedRot = 1f;

    void Update()
    {
        float rot = Time.deltaTime * speedRot;
        gameObject.transform.Rotate(new Vector3(0f, rot, 0f), Space.World);
    }
}
