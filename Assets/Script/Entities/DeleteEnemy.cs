using UnityEngine;

public class DeleteEnemy : MonoBehaviour
{

    public int losepoints;
    private bool isDestoy;

    //If the plane is found delete the enemy and lose point
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("plane"))
        {
            if (!isDestoy)
                PlayerInformation.pointOfPlayer -= losepoints;
            isDestoy = true;
            Destroy(gameObject);
        }
    }
}
