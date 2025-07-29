using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform transform1;
    public float Speed = 5f;
    

    

    // Start is called before the first frame update
    void Start()
    {
        transform1 = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform1.position -= new Vector3(0, Speed * Time.deltaTime, 0);
        if (transform1 .position .y<=-10)
        {
            Destroy(gameObject);
        }
    }
}
