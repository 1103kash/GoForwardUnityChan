using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    //キューブのPrefabを入れるための変数を用意(Inspectorから代入)
    public GameObject cubePrefab;
    //時間計測用の変数
    private float delta = 0;
    //キューブの生成間隔
    private float span = 1.0f;
    //キューブの生成位置:X座標
    private float genPosX = 12;
    //キューブの生成位置オフセット:Y
    private float offsetY = 0.3f;
    //キューブの縦方向の間隔:Y
    private float spaceY = 6.9f;
    //キューブの生成位置オフセット:X
    private float offsetX = 0.5f;
    //キューブの横方向の間隔:X
    private float spaceX = 0.4f;
    //キューブの生成個数上限
    private int maxBlockNum = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        //キューブの生成間隔となるspan秒以上の時間が経過したか調べる
        if(this.delta > this.span)
        {
            //時間計測をリセット
            this.delta = 0;
            //生成するキューブ数をランダムに決める
            int n = Random.Range(1, this.maxBlockNum + 1);
            //上記の個数キューブを生成
            for(int i = 0; i < n; i++)
            {
                //キューブの生成
                GameObject go = Instantiate(cubePrefab);
                go.transform.position = new Vector2(this.genPosX, this.offsetY + i * spaceY);
            }
            //次のキューブ生成時間を決める(生成されたキューブ数が多い程、キューブの生成感覚が広まる
            this.span = this.offsetX + this.spaceX * n;
        }
    }
}
