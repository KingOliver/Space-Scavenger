using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    
    public void DisablePlayerInput()
    {
        // Disable Player Movement
        gameObject.GetComponent<CharacterMovement>().enabled = false;
        gameObject.GetComponent<PlayerFallThroughPlatform>().enabled = false;

        // Disable Shooting
        gameObject.transform.GetChild(1).gameObject.GetComponent<ClickToShoot>().enabled = false;
    }

    public void EnablePlayerInput()
    {
        // Enable Player Movement
        gameObject.GetComponent<CharacterMovement>().enabled = true;
        gameObject.GetComponent<PlayerFallThroughPlatform>().enabled = true;

        // Enable Shooting
        gameObject.transform.GetChild(1).gameObject.GetComponent<ClickToShoot>().enabled = true;
    }

}
