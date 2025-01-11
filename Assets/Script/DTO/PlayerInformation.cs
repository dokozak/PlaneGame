using TMPro;
using UnityEngine;

public class PlayerInformation : MonoBehaviour
{
    public static int pointOfPlayer = -1;

    public TextMeshProUGUI textGUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //The initial value
        pointOfPlayer = -1;
    }

    private void Update()
    {
        //While the plane not is found this program doesn´t start, and this helps to the status of the program
        if(pointOfPlayer == -1)
        {
            textGUI.text = "Try to get a plane";
        }
        else
        {
            textGUI.text = "You have " + pointOfPlayer + " point";
        }
    }

}
