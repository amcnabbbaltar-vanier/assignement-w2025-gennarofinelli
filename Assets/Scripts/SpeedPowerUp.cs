using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    private float rotateSpeed = 50f;
    private Vector3 startPos;
    private MeshRenderer[] meshes;
    private Collider collider;
    
    void Start(){
        startPos = transform.position;
        meshes = GetComponentsInChildren<MeshRenderer>();
        collider = GetComponent<Collider>();
    }
    void Update()
    {
        transform.Rotate(0,rotateSpeed * Time.deltaTime,0);
        float newY = Mathf.Sin(Time.time * 5) * 0.25f;
        transform.position = new Vector3(startPos.x, startPos.y + newY, startPos.z); 
    }
    
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider player){
        player.GetComponent<CharacterMovement>().speedMultiplier *= 2;

        foreach (MeshRenderer m in meshes)
        {
            m.enabled = false;
        }
        collider.enabled = false;

        yield return new WaitForSeconds(5.0f);

        player.GetComponent<CharacterMovement>().speedMultiplier /= 2;
    }
}
