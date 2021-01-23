using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSec : MonoBehaviour
{
    public float timeInSec = 1f;

    private void Start()
    {
        DestroyAfter();
    }

    private void DestroyAfter()
    {
        Destroy(gameObject, timeInSec);
    }
}