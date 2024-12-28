using JetBrains.Annotations;
using UnityEngine;

public class CollisionEnemy : MonoBehaviour
{
    public GameObject explosion;
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag.Equals("Shot"))
        {
            GameObject animation =  Instantiate(explosion, collision.transform.position, collision.transform.rotation);
            Destroy(gameObject);
            Destroy(animation, 2f);

        }
    }
}
