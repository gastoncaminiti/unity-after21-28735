using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Bullet")){
            GetComponent<Rigidbody>().angularVelocity = new Vector3(0f,5f,0f); //ROTATE FORCE
            GetComponent<Enemy>().enabled = false; //DISABLE MOVEMENT COMPONENT
            Invoke("DelayDestroy",2f); //DESTRUIR LUEGO DE DOS SEGUNDOS
            Destroy(other.gameObject);
        }
    }

    void DelayDestroy(){
        Destroy(gameObject);
    }
}
