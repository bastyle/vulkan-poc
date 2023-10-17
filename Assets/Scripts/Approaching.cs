using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Approaching : MonoBehaviour
{
    public float FOVinDEG = 90;
    private float cosOfFOVover2InRAD;
    public float detectionDistance = 8;
    public GameObject player;
    public float maxSpeed = 2; //2m/s 

    void Start()
    {
        cosOfFOVover2InRAD = Mathf.Cos(FOVinDEG / 2f * Mathf.Deg2Rad);
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //
        //DoChaseEnemy();
        HandleChaseEnemy();
    }

    private void HandleChaseEnemy()
    {
        //DEFAULT
        //print("HandleChaseEnemy");


        //Check TRANSITIONS
        //T3 - Check dist<=8
        if (Utilities.CheckDistanceLess(this.transform.position, player.transform.position, detectionDistance)
            && (null != player && Utilities.isSeeingTarget(this.transform.position, player.transform.position,
                this.transform.forward, cosOfFOVover2InRAD)))
        {
            Debug.Log("CheckDistanceLess true");
            Debug.Log("See player true");
            DoChaseEnemy();
        }
    }

    private void DoChaseEnemy()
    {
        this.transform.position =
            Vector3.MoveTowards(this.transform.position, player.transform.position, maxSpeed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;

        Vector3 from = this.transform.position;
        Vector3 to = this.transform.position + this.transform.forward * detectionDistance;
        //Vector3 fovMinus=Vector3.RotateTowards(fro)
        Gizmos.DrawLine(from, to);
    }
}