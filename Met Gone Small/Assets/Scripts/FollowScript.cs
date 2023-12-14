using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FollowScript : MonoBehaviour
{
    [SerializeField] public float attackDamage = 10f;
    [SerializeField] private float attackSpeed = 1f;
    private float canAttack;
    public float speed = 5.0f;
    public Transform targetObj;
    private bool canHit;

    
    void Update()
    {
        transform.position = Vector3.MoveTowards(this.transform.position, targetObj.position, speed * Time.deltaTime);

        canAttack += Time.deltaTime;

        if (attackSpeed <= canAttack)
        {
            canHit = true;
        }
        else 
        {
            canHit = false;
        }
    }

    private void OnCollisionStay(Collision other)
    {
        
        
            if (other.gameObject.tag == "Player" && canHit == true)
            {
                other.gameObject.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
                canAttack = 0f;
            } 
        

    }


    
}
