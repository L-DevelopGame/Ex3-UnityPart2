using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTrigger2D : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(triggeringTag) && enabled)
        {
            Debug.Log("Collusion with " + other.tag);
            Destroy(other.gameObject);
        }
    }
}
