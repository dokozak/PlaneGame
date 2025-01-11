using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class CreateEnemies : MonoBehaviour
{
    public bool isEnable = false;
    public GameObject[] enemies;
    private float generateEnemies = 3f;
    private float elapsedTime = 0f;
    public ARPlane plane;

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > generateEnemies && isEnable)
        {
            elapsedTime = 0f;
            //Generate a new enemy
            generateRandomEnemy();
        }



    }


    public void generateRandomEnemy()
    {
        //Get the posicion in a map
        Vector3 posicionEnemigo = GetRandomPointInPlane(plane);
        //Get the random height
        posicionEnemigo.y += Random.Range(3, 5);
        //Get a random enemy
        GameObject enemigoGenerar = enemies[Random.Range(0, enemies.Length)];
        //Generate the enemy
        Instantiate(enemigoGenerar, posicionEnemigo, Quaternion.identity).transform.Rotate(0, 180, 0);
    }

    //This method return a random place in a plane
    Vector3 GetRandomPointInPlane(ARPlane plane)
    {
        var boundary = plane.boundary;

        int randomTriangleIndex = Random.Range(0, boundary.Length - 2);
        Vector3 v1 = plane.transform.TransformPoint(boundary[randomTriangleIndex]);
        Vector3 v2 = plane.transform.TransformPoint(boundary[randomTriangleIndex + 1]);
        Vector3 v3 = plane.transform.TransformPoint(boundary[randomTriangleIndex + 2]);
        return RandomPointInTriangle(v1, v2, v3);
    }

    Vector3 RandomPointInTriangle(Vector3 v1, Vector3 v2, Vector3 v3)
    {
        float a = Random.value;
        float b = Random.value;
        if (a + b > 1)
        {
            a = 1 - a;
            b = 1 - b;
        }
        return v1 + a * (v2 - v1) + b * (v3 - v1);
    }
}
