using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repeatBackground : MonoBehaviour
{
    private Vector3 startPosition;
    public float repeatWidth;

    // Start is called before the first frame update
    void Start()
    {
        //Guardamos la posición inicial del fondo.
        startPosition = transform.position;

        //Calcula la mitad exacta del fondo.
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    void Update()
    {
        //Cuando nuestro fondo se desplaza la mitad de su anchura hacia la izquierda, repetimos la imagen.
        if (transform.position.x < startPosition.x - repeatWidth)
        {
            //Volvemos a la posición inicial.
            transform.position = startPosition;
        }
    }
}
