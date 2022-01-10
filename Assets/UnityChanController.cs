using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnityChanController : MonoBehaviour{

    //Animation_surutame_no_component_wo_ireru
    private Animator myAnimator;

    //UnityChan_wo_idou_saseru_component_wo_ireru
    private Rigidbody myRigidbody;

    //Front-houkou_no_sokudo
    private float velocityZ = 16f;

    //Side-houkou_no_sokudo
    private float velocityX = 10f;

    //Over-houkou_no_sokudo
    private float velocityY = 10f;

    //Left_or_Right_no_idou_dekiru_hani
    private float movableRange = 3.4f;

    //Ugoki_wo_gensoku_saseru_keisuu
    private float coefficient = 0.99f;

    //Game_syuuryou_no_hantei
    private bool isEnd = false;

    //Game_syuuryou_ji_ni_hyouji_suru_text
    private GameObject stateText;

    //Score_wo_hyouji_suru_text
    private GameObject scoreText;

    //Score
    private int score = 0;

    //Left-Button_ouka_no_hantei
    private bool isLButtonDown = false;

    //Right-Button_ouka_no_hantei
    private bool isRButtonDown = false;

    //Jump-Button_ouka_no_hantei
    private bool isJButtonDown = false;

    // Start is called before the first frame update
    void Start(){

        //Animator-component_wo_syutoku
        this.myAnimator = GetComponent<Animator>();

        //Run-animation_wo_start
        this.myAnimator.SetFloat("Speed", 1);

        //Rigidbody-component_wo_syutoku
        this.myRigidbody = GetComponent<Rigidbody>();

        //Scene_tyuu_no_stateText-object_wo_syutoku
        this.stateText = GameObject.Find("GameResultText");

        //Scene_tyuu_no_scoreText-object_wo_syutoku
        this.scoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update(){

        //Game_syuuryou_nara_unitychan_no_ugoki_wo_gensui_suru
        if(this.isEnd){

            this.velocityZ *= this.coefficient;
            this.velocityX *= this.coefficient;
            this.velocityY *= this.coefficient;
            this.myAnimator.speed *= this.coefficient;
        }

        //Side-houkou_no_nyuuryoku_ni_yoru_sokudo
        float inputVelocityX = 0;
        //Over-houkou_no_nyuuryoku_ni_yoru_sokudo
        float inputVelocityY = 0;

        //UnityChan_wo_Arrow-key_or_button_ni_oujite_idou_saseru
        if((Input.GetKey(KeyCode.LeftArrow) || this.isLButtonDown) && -this.movableRange < this.transform.position.x){
            //Left-houkou_heno_sokudo_wo_dainyuu
            inputVelocityX = -this.velocityX;

        }else if((Input.GetKey(KeyCode.RightArrow) || this.isRButtonDown) && this.transform.position.x < this.movableRange){
            //Right-houkou_heno_sokudo_wo_dainyuu
            inputVelocityX = this.velocityX;
        }

        //Jump_sitenai_toki_ni_space_ga_osaretara_jump_suru
        if((Input.GetKeyDown(KeyCode.Space) || this.isJButtonDown) && this.transform.position.y < 0.5f){
            //Jump-anime_wo_saisei
            this.myAnimator.SetBool("Jump", true);
            //Over-houkou_heno_sokudo_wo_dainyuu
            inputVelocityY = this.velocityY;

        }else{
            //Genzai_no_Y-axis_no_sokudo_wo_dainyuu
            inputVelocityY = this.myRigidbody.velocity.y;
        }

        //Jump-state_no_baai_ha_Jump_ni_false_wo_set_suru
        if(this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump")){
            this.myAnimator.SetBool("Jump", false);
        }

        //UnityChan_ni_sokudo_wo_ataeru
        this.myRigidbody.velocity = new Vector3(inputVelocityX, inputVelocityY, this.velocityZ);
    }

    //Ttigger-mode_de_hoka_no_object_to_sessyoku_sita_baai_no_syori
    void OnTriggerEnter(Collider other){

        //Syougaibutu_ni_syoutotu_sita_baai
        if(other.gameObject.tag == "CarTag" || other.gameObject.tag == "TrafficConeTag"){
            this.isEnd = true;
            //stateText_ni_GAME OVER_wo_hyouji
            this.stateText.GetComponent<Text>().text = "GAME OVER";
        }

        //Goal-point_ni_toutatu_sita_baai
        if(other.gameObject.tag == "GoalTag"){
            this.isEnd = true;
            //stateText_ni_CLEAR!!_wo_hyouji
            this.stateText.GetComponent<Text>().text = "CLEAR!!";
        }

        //Coin_ni_syoutotu_sita_baai
        if(other.gameObject.tag == "CoinTag"){
            //Score_wo_kasan
            this.score += 10;
            //ScoreText_ni_kakutoku_sita_tensuu_wo_hyouji
            this.scoreText.GetComponent<Text>().text = "Score " + this.score + "pt";
            //Particle_wo_saisei
            GetComponent<ParticleSystem>() .Play();
            //Sessyoku_sita_coin_no_object_wo_haki
            Destroy(other.gameObject);
        }
    }

    //Jump-Button_wo_osita_baai_no_syori
    public void GetMyJumpButtonDown(){
        this.isJButtonDown = true;
    }

    //Jump-Button_wo_hanasita_baai_no_syori
    public void GetMyJumpButtonUp(){
        this.isJButtonDown = false;
    }

    //Left-Button_wo_osituduketa_baai_no_syori
    public void GetMyLeftButtonDown(){
        this.isLButtonDown = true;
    }

    //Left-Button_wo_hanasita_baai_no_syori
    public void GetMyLeftButtonUp(){
        this.isLButtonDown = false;
    }

    //Right-Button_wo_osituduketa_baai_no_syori
    public void GetMyRightButtonDown(){
        this.isRButtonDown = true;
    }

    //Right-Button_wo_hanasita_baai_no_syori
    public void GetMyRightButtonUp(){
        this.isRButtonDown = false;
    }
}
