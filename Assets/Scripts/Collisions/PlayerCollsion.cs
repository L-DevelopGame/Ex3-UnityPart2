using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCollusion : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggerTag;

    [Tooltip("Starting point of the object that it will be respawned at after death")] 
    [SerializeField] private Vector3 startPoint;


    
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Current object doesn't collide with the target
        if (!other.CompareTag(triggerTag) || !enabled) return;
        
           Respawn(this.gameObject);   
        
    }
    
  
  
    /**
     * Function respawns the player to start point
     */
    private void Respawn(GameObject player)
    {
        player.transform.position = startPoint;
    }
}
