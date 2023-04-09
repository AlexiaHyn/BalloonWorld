using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    Spawning SpawningScript;
    private Vector3 InitialPosition;
    private Vector3 temp;
    // Start is called before the first frame update
    void Start()
    {
        InitialPosition = this.transform.position;
        SpawningScript = GameObject.FindGameObjectWithTag("SpawnPoint").GetComponent<Spawning>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.sqrMagnitude > 10000) {
            SpawningScript.Decrement(1);
            Destroy(gameObject);
        }
        //Upon collision with another GameObject, this GameObject will reverse direction
        
        // Collider collider = GetComponent<Collider>();
        // if (collider.gameObject.name.Contains("Cylinder")) {
        //     Destroy(collider.gameObject);
        // }
    }

    public float forceMagnitude = 10.0f;
    
    private void OnTriggerEnter(Collider other)
        {
            
            if (other.tag == "ray") {
                
            

                temp = gameObject.transform.localScale;
                float i = .5f;
                temp.x -= i;
                temp.y -= i;
                temp.z -= i;

                if (temp.x < 0 || temp.y < 0 || temp.z < 0) {
                    Destroy(gameObject);
                }

                gameObject.transform.localScale = temp;

              
            }

        }


        

}
