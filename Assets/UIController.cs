using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    //ゲームオーバー(Text)のオブジェクトを取得するための変数を用意
    private GameObject gameOverText;
    //走行距離(Text)のオブジェクトを取得するための変数を用意
    private GameObject runLengthText;
    //走行距離
    private float len = 0;
    //走行速度
    private float speed = 5f;
    //ゲームオーバー判定
    private bool isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        //オブジェクトを取得
        this.gameOverText = GameObject.Find("GameOver");
        this.runLengthText = GameObject.Find("RunLength");
    }

    // Update is called once per frame
    void Update()
    {
        //ゲームオーバー状態でないときは距離を更新し続ける
        if(this.isGameOver == false)
        {
            //走行距離の更新
            this.len += this.speed * Time.deltaTime;
            //走行距離の表示
            this.runLengthText.GetComponent<Text>().text = "Distance: " + len.ToString("F2") + "m";
        }
        //ゲームオーバーになった場合
        if (this.isGameOver == true)
        {
            //クリックされたらシーンをロードする
            if (Input.GetMouseButtonDown(0))
            {
                //SampleSceneを読み込む(リロード)
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
    public void GameOver()
    {
        //ゲームオーバー時に画面にゲームオーバーを表示(距離の更新を止めるためisGameOverをTrueにする)
        this.gameOverText.GetComponent<Text>().text = "Game Over";
        this.isGameOver = true;
    }
}
