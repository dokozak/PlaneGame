using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject shot;
    public GameObject arCamera;

    public void ShootingShot()
    {
        GameObject newShot = Instantiate(shot, arCamera.transform.position,  arCamera.transform.rotation* shot.transform.rotation);
        newShot.GetComponent<Rigidbody>().AddForce(arCamera.transform.forward * 2000);
    }
}
