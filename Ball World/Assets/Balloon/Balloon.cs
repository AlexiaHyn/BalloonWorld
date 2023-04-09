using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    Spawning SpawningScript;
    private Vector3 InitialPosition;
    // Start is called before the first frame update
    void Start()
    {
        InitialPosition = this.transform.position;
        SpawningScript = GameObject.FindGameObjectWithTag("SpawnPoint").GetComponent<Spawning>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.sqrMagnitude > 2500 || this.transform.position.y < -5) {
            SpawningScript.Decrement(1);
            Destroy(gameObject);
        }
    }

}
