using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptParallax : MonoBehaviour
{
    [SerializeField] private float speed;
    
    public scriptGameHandler gameHandler;
    public GameObject leftLimit;
    public GameObject rightLimit;

    // Update is called once per frame
    void Update()
    {
        // Si el objeto est� por detr�s del l�mite izquierdo, lo mueve al punto de origen a la derecha
        if (transform.position.x <= leftLimit.transform.position.x)
        {
            transform.position = new Vector3(rightLimit.transform.position.x, transform.position.y, 0);
        }
        // Movimiento seg�n el tiempo, la velocidad general del juego, y la velocidad relativa seg�n la distancia
        transform.position += Vector3.left * gameHandler.speed * speed * Time.deltaTime;
    }
}
