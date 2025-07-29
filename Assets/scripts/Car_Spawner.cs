using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Spawner : MonoBehaviour
{
    public GameObject[] Cars;
    
    
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnerCars());
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -10)
        {
            Destroy(gameObject);
        } 
    }

    void cars()
    {
        int rand = Random.Range(0, Cars.Length);
        float randXpos = Random.Range(-7.5f, 7.5f);
        Instantiate(Cars[rand], new Vector3(randXpos, transform.position.y, transform.position.z), Quaternion.Euler(0, 0,0));
    }

    IEnumerator spawnerCars()
    {
        while (true)
        {
            yield return new WaitForSeconds (1);
            cars ();
        }
    }

}
