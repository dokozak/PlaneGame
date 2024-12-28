using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.ARFoundation;

public class GestionJuego : MonoBehaviour
{
    private System.Collections.Generic.List<ARPlane> planes = new System.Collections.Generic.List<ARPlane> ();
    [SerializeField] private ARPlaneManager aRPlaneManager;
    private bool isGenerarEnemigos = false;
    private float alturaPlanoDetectado;

    public GameObject[] enemigos;
    public float generarEnemigo = 1f;
    float elapsedTime = 0f;
    public GameObject shot;
    public GameObject arCamera;
    

    public void Start()
    {
        Physics.gravity = new Vector3(0,-0.2f,0);
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime > generarEnemigo && isGenerarEnemigos)
        {
            elapsedTime = 0f;
            //Generate a new enemy
            generateRandomEnemy();
        }



    }

    public void generateRandomEnemy()
    {
        Vector3 posicionEnemigo =new Vector3(Random.Range(-2, 2),Random.Range(3, 5),Random.Range(2, 6));
        GameObject enemigoGenerar = enemigos[Random.Range(0, enemigos.Length)];
        GameObject nuevoEnemigo = Instantiate(enemigoGenerar, posicionEnemigo, Quaternion.identity);
        nuevoEnemigo.GetComponent<DeleteEnemy>().planoY = alturaPlanoDetectado;
    }

    public void ShootingShot()
    {
        GameObject newShot = Instantiate(shot, arCamera.transform.position, arCamera.transform.rotation);
        newShot.GetComponent<Rigidbody>().AddForce(arCamera.transform.forward * 2000);
    }

    private void OnEnable()
    {
        aRPlaneManager.planesChanged += PlanesFound;
    }

    private void OnDisable()
    {
        aRPlaneManager.planesChanged -= PlanesFound;
    }

    private void PlanesFound(ARPlanesChangedEventArgs datosPlanos)
    {
        if(datosPlanos.added != null && datosPlanos.added.Count > 0)
        {
            planes.AddRange(datosPlanos.added);
        }

        foreach (ARPlane plane in planes)
        {
            if(plane.extents.x * plane.extents.y >= 0.3)
            {
                DetenerDeteccionPlanos();
                alturaPlanoDetectado = plane.center.y;
            }
        }
    }

    private void DetenerDeteccionPlanos()
    {
        aRPlaneManager.requestedDetectionMode = UnityEngine.XR.ARSubsystems.PlaneDetectionMode.None;
        isGenerarEnemigos = true;

        foreach (ARPlane plane in planes)
        {
            plane.gameObject.SetActive(false);
        }
    }
}
