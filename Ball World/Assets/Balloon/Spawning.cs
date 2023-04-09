using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public GameObject BalloonPrefab;
    private static int total = 100;
    private int id = 0;

    private float TimeRemaining = 3f;

    private GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 100; i++) {
            Spawn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        TimeRemaining -= Time.deltaTime;
        if (TimeRemaining < 0) {
            TimeRemaining = 3f;
            if (total < 100) {
                Spawn();
            }
        }
        

        // if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger)) {
        //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //     RaycastHit hit;
        //     if (Physics.Raycast(ray, out hit)) {
        //         // Check if the object hit is a balloon
        //         Destroy(hit.transform.gameObject);
        //     }
        // }
        
        //  Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //     RaycastHit hit;
        //     if (Physics.Raycast(ray, out hit)) {
        //         // Check if the object hit is a balloon
        //         Destroy(hit.transform.gameObject);
        //     }


    }

    void Spawn() {
        Vector3 NewPosition = new Vector3(Random.Range(-25f, 25f), Random.Range(1f, 25f), Random.Range(-25f, 25f));
        float RandomScale = Random.Range(2.5f, 3.5f);
        obj = (GameObject)Instantiate(BalloonPrefab, transform.position + NewPosition, Quaternion.identity);
        obj.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));
        obj.transform.localScale = new Vector3(RandomScale, RandomScale, RandomScale);
        obj.name = "Balloon" + id.ToString();
        Debug.Log(obj.name);
        id = (id + 1) % 1000;
    }

    public void Decrement(int amount) {
        total -= amount;
    }
    public static void decreaseTotal() {
        total--;
    }
}
