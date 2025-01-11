using UnityEngine;

public class CollisionShot : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
