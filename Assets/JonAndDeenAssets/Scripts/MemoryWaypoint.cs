using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryWaypoint : MonoBehaviour
{

    GameManager GM;
    // Indicator icon
    public Image img;
    public Image imgTV;
    public Image imgTissueBox;
    public Image imgPillow;
    public Image imgLPCar;
    public Image imgLPBoot;
    public Image imgBalloon;
    // The target (location, enemy, etc..)
    public Transform target;
    public Transform targetTV;
    public Transform targetTissueBox;
    public Transform targetPillow;
    public Transform targetLPCar;
    public Transform targetLPBoot;
    public Transform targetBalloon;
    // UI Text to display the distance
    public Text meter;
    public Text meterTV;
    public Text meterTissueBox;
    public Text meterPillow;
    public Text meterLPCar;
    public Text meterLPBoot;
    public Text meterBalloon;
    // To adjust the position of the icon
    public Vector3 offset;

    void Start()
    {
        GM = GameObject.FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        // Giving limits to the icon so it sticks on the screen
        // Below calculations witht the assumption that the icon anchor point is in the middle
        // Minimum X position: half of the icon width
        float minX = img.GetPixelAdjustedRect().width / 2;
        // Maximum X position: screen width - half of the icon width
        float maxX = Screen.width - minX;

        // Minimum Y position: half of the height
        float minY = img.GetPixelAdjustedRect().height / 2;
        // Maximum Y position: screen height - half of the icon height
        float maxY = Screen.height - minY;

        // Temporary variable to store the converted position from 3D world point to 2D screen point
        Vector2 pos = Camera.main.WorldToScreenPoint(target.position + offset);

        // Check if the target is behind us, to only show the icon once the target is in front
        if (Vector3.Dot((target.position - transform.position), transform.forward) < 0)
        {
            // Check if the target is on the left side of the screen
            if (pos.x < Screen.width / 2)
            {
                // Place it on the right (Since it's behind the player, it's the opposite)
                pos.x = maxX;
            }
            else
            {
                // Place it on the left side
                pos.x = minX;
            }
        }

        // Limit the X and Y positions
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        // Update the marker's position
        img.transform.position = pos;
        // Change the meter text to the distance with the meter unit 'm'
        meter.text = ((int)(Vector3.Distance(target.position, transform.position)) / 10).ToString() + "m";

        if (GM.currentItem == 0)
        {
            target = targetTV;
            meter = meterTV;
        }
        else if (GM.currentItem == 1)
        {
            target = targetTissueBox;
            meter = meterTissueBox;
        }
        else if (GM.currentItem == 2)
        {
            target = targetPillow;
            meter = meterPillow;
        }
        else if (GM.currentItem == 3)
        {
            target = targetLPCar;
            meter = meterLPCar;
        }
        else if (GM.currentItem == 4)
        {
            target = targetLPBoot;
            meter = meterLPBoot;
        }
        else if (GM.currentItem == 5)
        {
            target = targetBalloon;
            meter = meterBalloon;
        }
        
    }
}
