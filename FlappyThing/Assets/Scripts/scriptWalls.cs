using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptWalls : MonoBehaviour
{
    public GameObject leftLimit;
    public GameObject rightLimit;

    public scriptGameHandler GameHandler;

    private float downLimit = -4f;
    private float upLimit = -0.20f;

    // Start is called before the first frame update
    void Start()
    {
        // Mueve el muro al l�mite derecho a una altura al azar
        transform.position = new Vector3(rightLimit.transform.position.x, Random.Range(downLimit, upLimit), 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Si sobrepasa el l�mite izquierdo, se destruye
        if (transform.position.x <= leftLimit.transform.position.x)
        {
            Destroy(transform.root.gameObject);
        }
        // Se mueve a una velocidad constante seg�n la general del juego
        transform.position += Vector3.left * GameHandler.speed * Time.deltaTime;

    }

}
