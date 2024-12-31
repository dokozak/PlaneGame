using Unity.VisualScripting;
using UnityEngine;

public class CreateEnemies : MonoBehaviour
{
    public bool isEnable = false;
    public GameObject[] enemies;
    private float generateEnemies = 3f;
    private float elapsedTime = 0f;
    public float planeHeight;

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
        Vector3 posicionEnemigo = new Vector3(Random.Range(-2, 2), Random.Range(3, 5), Random.Range(2, 6));
        GameObject enemigoGenerar = enemies[Random.Range(0, enemies.Length)];
        GameObject nuevoEnemigo = Instantiate(enemigoGenerar, posicionEnemigo, Quaternion.identity);
        nuevoEnemigo.GetComponent<DeleteEnemy>().planoY = planeHeight;
    }
}
