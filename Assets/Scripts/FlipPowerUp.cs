using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipPowerUp : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider player){
        Debug.Log("Power up has been picked up.");

        player.GetComponent<CharacterMovement>().CanFlip = true;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(30.0f);

        player.GetComponent<CharacterMovement>().CanFlip = false;
    }
}
