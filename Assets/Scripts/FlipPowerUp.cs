using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipPowerUp : MonoBehaviour
{
    private float rotateSpeed = 50f;
    public float height = 2.5f;
    private Vector3 startPos;

    void Start(){
        startPos = transform.position;
    }

    void Update()
    {
        transform.Rotate(0,0,rotateSpeed * Time.deltaTime);
        float newY = Mathf.Sin(Time.time * 5) * height;
        transform.position = new Vector3(startPos.x, startPos.y + newY, startPos.z);
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
