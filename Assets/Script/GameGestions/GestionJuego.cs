using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.ARFoundation;

public class GestionJuego : MonoBehaviour
{
    private System.Collections.Generic.List<ARPlane> planes = new System.Collections.Generic.List<ARPlane>();
    [SerializeField] private ARPlaneManager aRPlaneManager;
    private CreateEnemies generateEnemies;



    

    public void Start()
    {
        generateEnemies = GetComponent<CreateEnemies>();
        Physics.gravity = new Vector3(0,-0.2f,0);
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
                generateEnemies.planeHeight = plane.center.y;
                generateEnemies.isEnable = true;
                PlayerInformation.pointOfPlayer = 0;
            }
        }
    }

    private void DetenerDeteccionPlanos()
    {
        aRPlaneManager.requestedDetectionMode = UnityEngine.XR.ARSubsystems.PlaneDetectionMode.None;

        foreach (ARPlane plane in planes)
        {
            plane.gameObject.SetActive(false);
        }
    }
}
