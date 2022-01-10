using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCameraController : MonoBehaviour{
    //UnityChan_no_object
    private GameObject unitychan;

    //UnityChan_to_camera_no_kyori
    private float difference;

    // Start is called before the first frame update
    void Start(){
        //UnityChan_no_object_wo_syutoku
        this.unitychan = GameObject.Find("unitychan");

        //UnityChan_to_camera_no_iti_no_sa_wo_motomeru(z-axis)
        this.difference = unitychan.transform.position.z - this.transform.position.z;
    }

    // Update is called once per frame
    void Update(){
        //UnityChan_no_iti_ni_awasete_camera_no_iti_wo_idou
        this.transform.position = new Vector3(0, this.transform.position.y, this.unitychan.transform.position.z - difference);
    }
}
