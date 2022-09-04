using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptGameHandler : MonoBehaviour
{

    public float speed;

    public GameObject wall;

    // Start is called before the first frame update
    void Start()
    {
        //float genSpeed = 1 + Mathf.Sqrt(speed);
        //Debug.Log(genSpeed);

        InvokeRepeating("CreateWall", 0, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateWall()
    {
        GameObject newWall = Instantiate(wall);
    }
}
