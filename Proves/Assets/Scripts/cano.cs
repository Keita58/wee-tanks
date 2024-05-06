using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cano : MonoBehaviour
{
    public float speedBullet;
    public GameObject bullet;
    public GameObject tank;
    private int totalBales;
    private int balesUsades;

    // Start is called before the first frame update
    void Start()
    {
        this.totalBales = 5;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] bales = GameObject.FindGameObjectsWithTag("BalaBona");
        balesUsades = bales.Length;

        // Agafa les coordenades del ratol� (estigui on estigui) i les transforma a coordenades del mapa
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Restem la posici� actual del ratol� entre la posici� actual del tanc
        Vector2 direction = mousePosition - (Vector2)transform.position;

        // Assignem la direcci� del can� a la calculada anteriorment
        transform.up = direction;  

        if(Input.GetMouseButtonDown(0)) 
        {
            if (balesUsades < 5)
            {
                GetComponent<AudioSource>().Play();
                // Per a evitar que les bales apareguin dins del tanc podem sumar el seu punt d'aparici� per la direcci� calculada
                // anteriorment, el que ens d�na un radi pel que les bales dispararan
                // Per� aquesta direcci� no est� normalitzada i les bales surten del mapa, pel que necessitem normalitzar-la abans
                direction.Normalize();
                // Dividim la direcci� per a redu�r el radi d'on apar�ixen les bales (el n�mero escollit �s perqu� �s el radi m�s petit que no toca
                // el tanc i que sembla que surti directament del can�)
                GameObject bulletNew = Instantiate(bullet, new Vector2(tank.transform.position.x + (direction.x / 1.38f), tank.transform.position.y + (direction.y / 1.38f)), transform.rotation);
                bulletNew.GetComponent<Rigidbody2D>().velocity = transform.up * speedBullet;
            }
        }
    }

    internal int getBales()
    {
        return totalBales - balesUsades;
    }
}
