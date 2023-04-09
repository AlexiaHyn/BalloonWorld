using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Dummiesman; //Load OBJ Model

public class main : MonoBehaviour
{
    public GameObject model;

    string objPath = "Assets/mm/an_object.obj";
    string error = string.Empty;
    GameObject loadedObject;
    

    void OnGUI() {
        objPath = GUI.TextField(new Rect(0, 0, 256, 32), objPath);

        GUI.Label(new Rect(0, 0, 256, 32), "Obj Path:");
        if(GUI.Button(new Rect(256, 32, 64, 32), "Load File"))
        {
            //file path
            if (!File.Exists(objPath))
            {
                error = "File doesn't exist.";
            }else{
                if(loadedObject != null)            
                    Destroy(loadedObject);
                loadedObject = new OBJLoader().Load(objPath);
                error = string.Empty;
            }
        }

        if(!string.IsNullOrWhiteSpace(error))
        {
            GUI.color = Color.red;
            GUI.Box(new Rect(0, 64, 256 + 64, 32), error);
            GUI.color = Color.white;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        OnGUI();
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject myObject = GameObject.Find("an_object");

        myObject.transform.position += new Vector3(0, 0, 0.1f);
    }
}
