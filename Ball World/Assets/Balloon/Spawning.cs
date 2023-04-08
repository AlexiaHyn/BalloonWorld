using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public GameObject BalloonPrefab;

    private int total = 250;

    private float TimeRemaining = 10f;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 250; i++) {
            Spawn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        TimeRemaining -= Time.deltaTime;
        if (TimeRemaining < 0) {
            TimeRemaining = 10f;
            if (total < 250) {
                Spawn();
            }
        }
    }

    void Spawn() {
        Vector3 NewPosition = new Vector3(Random.Range(-45f, 45f), Random.Range(5f, 45f), Random.Range(-45f, 45f));
        float RandomScale = Random.Range(0.5f, 1.5f);
        GameObject obj = (GameObject)Instantiate(BalloonPrefab, transform.position + NewPosition, Quaternion.identity);
        obj.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        obj.transform.localScale = new Vector3(RandomScale, RandomScale, RandomScale);
    }

    public void Decrement(int amount) {
        total -= amount;
    }
}
