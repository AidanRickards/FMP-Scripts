using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttackingScript : MonoBehaviour
{
    public LayerMask enemy;
    public GameObject lastHit;
    public Vector3 collision = Vector3.zero;

    EnemyScript enemyScript;
    public UIScript ui;

    bool isAttacking = false;
    
    
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        var attackRay = new Ray(this.transform.position + new Vector3(0f, 1.50f, 0f), this.transform.forward);
        RaycastHit hit;

        Debug.DrawRay(this.transform.position + new Vector3(0f, 1.50f, 0f), this.transform.forward, Color.red);

        if (Physics.Raycast(attackRay, out hit, 2, enemy))
        {
            lastHit = hit.transform.gameObject;
            collision = hit.point;

            if (Input.GetMouseButtonDown(0) && isAttacking == false)
            {
                isAttacking = true;
                invulnerability();
                hit.transform.gameObject.GetComponent<EnemyScript>().takeDamage();


                Invoke("uninvulnerability", 1.5f);

            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(collision, 0.2f);
    }

    public void invulnerability()
    {
        ui.invulnerable = true;
    }
    public void uninvulnerability()
    {
        ui.invulnerable = false;
        isAttacking = false;
        print("uninvulnerable");
    }
}
