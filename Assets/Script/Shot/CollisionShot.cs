using UnityEngine;

public class CollisionShot : MonoBehaviour
{
    //Delete this gameobject if the enemy is find
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
