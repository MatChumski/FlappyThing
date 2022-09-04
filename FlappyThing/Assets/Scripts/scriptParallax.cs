using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptParallax : MonoBehaviour
{
    [SerializeField]
    private float speed;
    
    public scriptGameHandler gameHandler;
    public GameObject leftLimit;
    public GameObject rightLimit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= leftLimit.transform.position.x)
        {
            transform.position = new Vector3(rightLimit.transform.position.x, transform.position.y, 0);
        }
        
        transform.position += Vector3.left * gameHandler.speed * speed * Time.deltaTime;
    }
}
