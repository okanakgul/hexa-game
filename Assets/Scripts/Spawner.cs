using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnRate = 1f;

    public GameObject hexagonPrefab;

    private float nextTimeToSpawsn = 0f;

    private LineRenderer lineRenderer;

    
    Color startColor = Color.white;
    Color endColor = Color.white;

    void colorPicker()
    {
        int myRandomInt = Random.Range(0, 7);
        switch (myRandomInt)
        {
            case 0: startColor = Color.cyan; break;
            case 1: startColor = Color.green; break;
            case 2: startColor = Color.blue; break;
            case 3: startColor = Color.red; break;
            case 4: startColor = Color.magenta; break;
            case 5: startColor = Color.yellow; break;
            case 6: startColor = Color.grey; break;
        }
        lineRenderer = hexagonPrefab.GetComponent<LineRenderer>();
        lineRenderer.material = new Material( Shader.Find("Sprites/Default"));
        lineRenderer.SetColors(startColor, endColor);
    }

    void rotationPicker()
    {
        int rotationDir = Random.Range(0, 2);
        hexagonPrefab.GetComponent<Hexagon>().clockwise = rotationDir;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Time.time >= nextTimeToSpawsn)
        {

            colorPicker();
            rotationPicker();



            // lineRenderer = hexagonPrefab.GetComponent<LineRenderer>();
            // lineRenderer.sharedMaterial.color = Color.green;
            Instantiate(hexagonPrefab, Vector3.zero, Quaternion.identity);
            nextTimeToSpawsn = Time.time + 1f / spawnRate;
          

        }
    }
}
