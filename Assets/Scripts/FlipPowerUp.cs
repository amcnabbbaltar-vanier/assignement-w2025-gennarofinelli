using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipPowerUp : MonoBehaviour
{
    private float rotateSpeed = 50f;
    void Update()
    {
        transform.Rotate(0,0,rotateSpeed * Time.deltaTime);   
    }

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider player){
        Debug.Log("Power up has been picked up.");

        player.GetComponent<CharacterMovement>().CanFlip = true;

        gameObject.active = false;

        yield return new WaitForSeconds(30.0f);

        player.GetComponent<CharacterMovement>().CanFlip = false;
    }
}
