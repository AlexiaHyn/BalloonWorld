using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class left_collision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Collider[] allColliders = FindObjectsOfType<Collider>();
        
        OnTriggerEnter(GetComponent<Collider>());
    }

    void OnTriggerEnter(Collider other)
{
    // Check if the collider that entered the trigger is a game object we're interested in
    if (other.gameObject.CompareTag("SpawnPoint"))
    {
        Destroy(other.gameObject);
    }
}
}
