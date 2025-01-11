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
        //Change the gravity of the game
        Physics.gravity = new Vector3(0, -0.2f, 0);
    }





    //Add planes
    private void OnEnable()
    {
        aRPlaneManager.planesChanged += PlanesFound;
    }

    //Remove planes
    private void OnDisable()
    {
        aRPlaneManager.planesChanged -= PlanesFound;
    }

   
    private void PlanesFound(ARPlanesChangedEventArgs datosPlanos)
    {
        
        if (datosPlanos.added != null && datosPlanos.added.Count > 0)
        {
            planes.AddRange(datosPlanos.added);
        }

        foreach (ARPlane plane in planes)
        {   //Check this condition and if is true start the game
            if (plane.extents.x * plane.extents.y >= 0.3)
            {
                DetenerDeteccionPlanos();
                generateEnemies.plane = plane;
                generateEnemies.isEnable = true;
                PlayerInformation.pointOfPlayer = 0;
                //Activate the main plane
                plane.gameObject.SetActive(true);
            }
        }
    }

    private void DetenerDeteccionPlanos()
    {
        aRPlaneManager.requestedDetectionMode = UnityEngine.XR.ARSubsystems.PlaneDetectionMode.None;
        //deactive all planes
        foreach (ARPlane plane in planes)
        {
            plane.gameObject.SetActive(false);
        }
    }
    

}
