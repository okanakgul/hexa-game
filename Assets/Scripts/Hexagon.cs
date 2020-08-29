using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexagon : MonoBehaviour
{
    public Rigidbody2D rb;
    public float shrinkSpeed = 3f;
    public int clockwise;
    // Start is called before the first frame update
    void Start()
    {
        rb.rotation = Random.Range(0f, 360f);
        transform.localScale = Vector3.one * 10f;
    }


    // Update is called once per frame
    void Update()
    {

        transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;
        if(clockwise == 0) transform.Rotate(Vector3.forward, Time.deltaTime * 15f);
        else transform.Rotate(Vector3.forward, Time.deltaTime * -15f);

        if (transform.localScale.x <= .05f)
        {
            Destroy(gameObject);
        }
    }
}
