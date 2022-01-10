using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour{

    //carPrefab_wo_ireru
    public GameObject carPrefab;
    //coinPrefab_wo_ireru
    public GameObject coinPrefab;
    //conePrefab_wo_ireru
    public GameObject conePrefab;
    //Start_point
    private int startPos = 80;
    //Goal_point
    private int goalPos = 360;
    //Item_wo_dasu_X_houkou_no_hani
    private float posRange = 3.4f;

    //-------------------------Hatten_Kadai-------------------------
    //UnityChan_no_object
    private GameObject unitychan;
    //UnityChan_no_position
    private float unitychanPos;
    //--------------------------------------------------------------

    // Start is called before the first frame update
    void Start(){
    //-------------------------Hatten_Kadai-------------------------
        //UnityChan_no_object_wo_syutoku
        this.unitychan = GameObject.Find("unitychan");
    //--------------------------------------------------------------

    /*-----Hatten_Kadai_no_tame_comment__Kokokara
        //Ittei_no_kyori_goto_ni_item_wo_seisei
        for(int i = startPos; i < goalPos; i += 15){
            //Dono_item_wo_dasunoka_wo_random_ni_settei
            int num = Random.Range(1, 11);

            if(num <= 2){
                //Cone_wo_ittyokusen_ni_seisi
                for(float j = -1; j <= 1; j += 0.4f){
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
                }

            }else{
                //Lane_goto_ni_item_wo_seisei
                for(int j = -1; j <= 1; j++){
                    //Item_no_syurui_wo_kimeru
                    int item = Random.Range(1, 11);
                    //Item_wo_oku_Z-zahyou_no_offset_wo_random_ni_settei
                    int offsetZ = Random.Range(-5, 6);

                    //60%_coin: 30%_car: 10%_nothing
                    if(1 <= item && item <= 6){
                        //Coin_wo_seisei
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);

                    }else if(7 <= item && item <= 9){
                        //Car_wo_seisei
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
                    }
                }
            }
        }
    Kokomade-----*/ 
    }

    // Update is called once per frame
    void Update(){
    //-------------------------Hatten_Kadai-------------------------
        //UnityChan_no_Z-position
        this.unitychanPos = unitychan.transform.position.z;
        //Unitychan_no_45~50m_zenpou_ni_objecto_wo_haiti
        if((this.unitychanPos >= this.startPos - 50) && (this.unitychanPos >= this.startPos - 45.0) && (this.startPos < this.goalPos)){
            //ItemGenerate_kansuu_wo_yobidasu
            ItemGenerate(this.startPos);
        }
    //--------------------------------------------------------------
    }

    //-------------------------Hatten_Kadai-------------------------
	//Ittei_no_kyori_goto_ni_item_wo_seisei
	void ItemGenerate(float i){     //Hikisuu = this.startPos

		//Dono_item_wo_dasunoka_wo_random_ni_settei
		int num = Random.Range(1, 11);

		if(num <= 2){
			//Cone_wo_ittyokusen_ni_seisi
			for(float j = -1; j <= 1; j += 0.4f){
				GameObject cone = Instantiate(conePrefab);
				cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
			}

		}else{
			//Lane_goto_ni_item_wo_seisei
			for(int j = -1; j <= 1; j++){
				//Item_no_syurui_wo_kimeru
				int item = Random.Range(1, 11);
				//Item_wo_oku_Z-zahyou_no_offset_wo_random_ni_settei
				int offsetZ = Random.Range(-5, 6);

				//60%_coin: 30%_car: 10%_nothing
				if(1 <= item && item <= 6){
						//Coin_wo_seisei
						GameObject coin = Instantiate(coinPrefab);
						coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);

				}else if(7 <= item && item <= 9){
						//Car_wo_seisei
						GameObject car = Instantiate(carPrefab);
						car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
				}
			}
		}
        //StartPos_wo_kousin
        this.startPos += 15;
	}
    //--------------------------------------------------------------
}
