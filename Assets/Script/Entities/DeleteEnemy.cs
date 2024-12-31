using UnityEngine;

public class DeleteEnemy : MonoBehaviour
{

    public float planoY;
    public int losepoints;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime);
        if (planoY-2 > transform.position.y)
        {
            PlayerInformation.pointOfPlayer -= losepoints;
            Destroy(gameObject);
        }
    }
}
