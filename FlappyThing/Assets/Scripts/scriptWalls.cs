using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptWalls : MonoBehaviour
{
    public GameObject leftLimit;
    public GameObject rightLimit;

    public scriptGameHandler GameHandler;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(rightLimit.transform.position.x, Random.Range(-4, -0.20f), 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= leftLimit.transform.position.x)
        {
            Debug.Log("left limit");
            //transform.position = new Vector3(rightLimit.transform.position.x, Random.Range(-4, -0.20f),0);
            Destroy(transform.root.gameObject);
        }

        transform.position += Vector3.left * GameHandler.speed * Time.deltaTime;

    }

}
