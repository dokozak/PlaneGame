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
        Vector3 posicionEnemigo = GetRandomPointInPlane(plane);
        posicionEnemigo.y += Random.Range(5, 10);
        GameObject enemigoGenerar = enemies[Random.Range(0, enemies.Length)];
        Instantiate(enemigoGenerar, posicionEnemigo, Quaternion.identity).transform.Rotate(0, 180, 0);
    }


    Vector3 GetRandomPointInPlane(ARPlane plane)
    {
        // Obtén los límites del plano en su espacio local
        var boundary = plane.boundary;

        if (boundary.Length < 3)
        {
            Debug.LogWarning("Plane boundary too small!");
            return plane.transform.position;
        }

        // Selecciona un triángulo aleatorio dentro de los límites
        int randomTriangleIndex = Random.Range(0, boundary.Length - 2);

        // Obtén los vértices del triángulo
        Vector3 v1 = plane.transform.TransformPoint(boundary[randomTriangleIndex]);
        Vector3 v2 = plane.transform.TransformPoint(boundary[randomTriangleIndex + 1]);
        Vector3 v3 = plane.transform.TransformPoint(boundary[randomTriangleIndex + 2]);

        // Genera un punto aleatorio dentro del triángulo
        return RandomPointInTriangle(v1, v2, v3);
    }

    Vector3 RandomPointInTriangle(Vector3 v1, Vector3 v2, Vector3 v3)
    {
        float a = Random.value;
        float b = Random.value;

        // Asegúrate de que el punto esté dentro del triángulo
        if (a + b > 1)
        {
            a = 1 - a;
            b = 1 - b;
        }

        return v1 + a * (v2 - v1) + b * (v3 - v1);
    }
}
