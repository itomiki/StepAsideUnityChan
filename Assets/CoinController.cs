using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour{

	//int count = 0;

    // Start is called before the first frame update
    void Start(){
        //Kaiten_wo_kaisi_suru_kakudo_wo_settei
        this.transform.Rotate(0, Random.Range(0, 360), 0);

    //    Debug.Log(this.transform.localEulerAngles.y);
    }

    // Update is called once per frame
    void Update(){
        //Kaiten
        this.transform.Rotate(0, 3, 0);

    //    this.count += 1;
    //    if (this.count == 119){
    //        Debug.Log(this.transform.localEulerAngles.y);
    //    }
	}
}
