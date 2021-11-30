using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    private float Speed = 1.5f;
    private Vector3 targetPos;
    private BaseEntiny unit;
    private BaseEntiny unitTarget;
    private Vector3 direction;
    private bool stopMove = false;
    private ParticleSystem hit;
    private ParticleSystem beam;

    private void Start()
    {
        unit = transform.parent.GetComponent<BaseEntiny>();
        unitTarget = unit.currentTarget;
        Speed = unit.Speed_projectile;
        
    }

    void FixedUpdate()
    {
        if (unitTarget == null) Destroy(gameObject);

        if (!stopMove)
        {
            MoveToTarget();
            FollowTarget();
        }
        else
        {
            DesTroy_After_Play();
        }
        
    }


    private void FollowTarget()
    {
        if (unitTarget == null) Destroy(gameObject);

        direction =  targetPos - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
       
    }

    
    private void MoveToTarget()
    {
        var currentNode = unit.currentTarget.GetCurrentNode();
        targetPos = currentNode.worldPosition;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, (Speed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Unit" &&
           collider.transform.GetComponent<BaseEntiny>().UnitTeam() !=
           unit.UnitTeam())
        {
            stopMove = true;

            transform.Find("Projectile").GetComponent<ParticleSystem>().Stop();
            hit = transform.Find("Hit").GetComponent<ParticleSystem>();
            if(hit != null)
            {
                unit.currentTarget.TakeDamage(unit.Str);
                hit.Play();
            }
            
        }
    }

    private void DesTroy_After_Play()
    {   
        if (hit.isPlaying)
        {
            return;
        }
        else { Destroy(gameObject); }
        
    }


}
