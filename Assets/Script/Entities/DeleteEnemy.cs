using UnityEngine;

public class DeleteEnemy : MonoBehaviour
{

    public int losepoints;
    private bool isDestoy;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("plane"))
        {
            if(!isDestoy) 
            PlayerInformation.pointOfPlayer -= losepoints;
            isDestoy = true;
            Destroy(gameObject);
        }
    }
}
