using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FollowScript : MonoBehaviour
{
    [SerializeField] private float attackDamage = 10f;
    [SerializeField] private float attackSpeed = 1f;
    private float canAttack;
    public float speed = 5.0f;
    public Transform targetObj;


    void Start()
    {
        
    }


    void Update()
    {
        transform.position = Vector3.MoveTowards(this.transform.position, targetObj.position, speed * Time.deltaTime);
    }

    private void OnCollisionStay(Collision other) {
        if (other.gameObject.tag == "Player") {
            if (attackSpeed <= canAttack) {
            other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
            canAttack = 2f;
        } else {
                canAttack += Time.deltaTime;
        }
    }
    }
}
