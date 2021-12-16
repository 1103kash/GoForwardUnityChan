using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    //キューブの移動速度
    private float speed = -12;
    //キューブの消滅位置
    private float deadLine = -10;
    //AudioSourceコンポーネントを取得するための変数を用意
    AudioSource cubesfx;

    // Start is called before the first frame update
    void Start()
    {
        this.cubesfx = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //キューブを移動させる
        this.gameObject.transform.Translate(this.speed * Time.deltaTime, 0, 0);
        //画面外に出たら破棄
        if(transform.position.x < this.deadLine)
        {
            Destroy(this.gameObject);
        }
    }
    //衝突時にTagを判別して、地面orキューブだった場合は効果音を再生する
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "groundTag" || collision.gameObject.tag == "cubeTag")
        {
            this.cubesfx.Play();
        }
    }
}
