using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    //Animatorコンポーネントを取得するための変数を用意
    Animator animator;
    //Rigidbodyを取得するための変数を用意
    Rigidbody2D rigid2D;
    //地面の位置
    private float groundLevel = -3.0f;
    //ジャンプ速度減衰
    private float dump = 0.8f;
    //ジャンプ速度
    private float jumpVelocity = 20;
    //ゲームオーバーになるx座標
    private float deadLine = -9;

    // Start is called before the first frame update
    void Start()
    {
        //Animatorコンポーネントを取得する
        this.animator = GetComponent<Animator>();
        //Rigidbody2Dコンポーネントを取得する
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //AnimatorのControllerで走るアニメーションの遷移条件となっているパラメータを調整
        this.animator.SetFloat("Horizontal", 1);
        //着地状態を調べてパラメータを調整(三項演算子で変数を初期化して入れ込む)
        bool isGround = (this.groundLevel < transform.position.y) ? false : true;
        this.animator.SetBool("isGround", isGround);
        //ジャンプ状態では足音を0にする
        GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;
        //着地状態でクリックされた場合、上方向に力をかける
        if(Input.GetMouseButtonDown(0) && isGround)
        {
            this.rigid2D.velocity = new Vector2(0, this.jumpVelocity);
        }
        //クリックされていない時に上方向への力が残っている場合減衰させる
        if (Input.GetMouseButton(0) == false)
        {
            if (this.rigid2D.velocity.y > 0)
            {
                this.rigid2D.velocity *= this.dump;
            }
        }
        //デッドラインを超えた場合ゲームオーバーにする
        if (transform.position.x < this.deadLine)
        {
            //UIControllerのGameOver関数を呼び出し、画面上にGameOver表示＆距離加算の停止
            //※ 他スクリプトの関数等を呼び出す場合は、他オブジェクトのコンポーネントと同じように扱う
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();
            //Unityちゃんを破棄
            Destroy(this.gameObject);
        }
    }
}
