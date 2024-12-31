using TMPro;
using UnityEngine;

public class PlayerInformation : MonoBehaviour
{
    public static int pointOfPlayer = -1;

    public TextMeshProUGUI textGUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pointOfPlayer = -1;
    }

    private void Update()
    {
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
