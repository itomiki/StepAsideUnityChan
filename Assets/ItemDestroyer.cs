using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--------------------Tuujou_Kadai-------------------------
public class ItemDestroyer : MonoBehaviour{

    //UnityChan_no_object
    private GameObject unitychan;
    //UnityChan_no_position
    private float unitychanPos;

    // Start is called before the first frame update
    void Start(){

        //UnityChan_no_object_wo_syutoku
        this.unitychan = GameObject.Find("unitychan");
    }

    // Update is called once per frame
    void Update(){
        //UnityChan_no_Z-position
        this.unitychanPos = unitychan.transform.position.z;

        //UnityChan_ga_toori_sugita_object_wo_syoukyo
        if(tag == "CarTag" && this.transform.position.z < unitychanPos - 10.0f){
            Destroy(this.gameObject);

        }else if(tag == "TrafficConeTag" && this.transform.position.z < unitychanPos - 10.0f){
            Destroy(this.gameObject);

        }else if(tag == "CoinTag" && this.transform.position.z < unitychanPos - 10.0f){
            Destroy(this.gameObject);

        }
    }
}
