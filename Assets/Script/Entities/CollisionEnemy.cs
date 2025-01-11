using JetBrains.Annotations;
using UnityEngine;

public class CollisionEnemy : MonoBehaviour
{
    public GameObject explosion;
    public int pointWin;

    //If the shot is found gain the points
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Shot"))
        {
            PlayerInformation.pointOfPlayer += pointWin;
            Destroy(gameObject);


        }
    }
}
