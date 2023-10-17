using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GettingAway : MonoBehaviour
{
    public float FOVinDEG = 90;
    private float cosOfFOVover2InRAD;
    public float detectionDistance = 5;
    public GameObject player;
    public float maxSpeed = 2; //2m/s 

    public Material enemyMaterial1;
    public Material enemyMaterial2;


    // Start is called before the first frame update
    void Start()
    {
        cosOfFOVover2InRAD = Mathf.Cos(FOVinDEG / 2f * Mathf.Deg2Rad);
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        HandleGettingAway();
    }

    private void HandleGettingAway()
    {
        if (Utilities.CheckDistanceLess(this.transform.position, player.transform.position, detectionDistance))
        {
            GetComponent<Renderer>().material = enemyMaterial2;
            //GeettingAway();
            GettingAwayApproach();
        }
        else
        {
            GetComponent<Renderer>().material = enemyMaterial1;
        }
    }

    private void GeettingAway()
    {
        //this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position*detectionDistance*-1, maxSpeed * Time.deltaTime);
        this.transform.position =
            Vector3.MoveTowards(this.transform.position, player.transform.position, -maxSpeed * Time.deltaTime);

    }

    private void GettingAwayApproach()
    {
        if (player.GetComponent<PlayerController>().HasPowerUp)
        {
            this.transform.position =
                Vector3.MoveTowards(this.transform.position, player.transform.position, maxSpeed * Time.deltaTime);
        }
        else
        {
            this.transform.position =
                Vector3.MoveTowards(this.transform.position, player.transform.position, -maxSpeed * Time.deltaTime);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Vector3 from = this.transform.position;
        Vector3 to = this.transform.position + this.transform.forward * detectionDistance;
        Vector3 to1 = this.transform.position - this.transform.forward * detectionDistance;
        Gizmos.DrawLine(from, to);
        Gizmos.DrawLine(from, to1);
        


        /*for (int i = 0; i < 360; i++)
        {
            Gizmos.DrawLine(from, new Vector3(this.transform.position.x+i, this.transform.position.y+i,this.transform.position.z+i));
        }*/
    }
}
