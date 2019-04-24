using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //cornPrefabを入れる
    public GameObject conePrefab;

    //発展課題　unityちゃん用の変数
    public GameObject unitychan;


    //スタート地点
    private int startPos = -160;
    //ゴール地点
    private int goalpos = 120;
    //アイテムを出すx方向の範囲
    private float posRange = -3.4f;

    // Use this for initialization
    void Start()
    {
        //発展課題　unityちゃんのオブジェクトを代入
        this.unitychan = GameObject.Find("unitychan");


       
    }

// Update is called once per frame
void Update()
    {
        if (this.unitychan.transform.position.z + 40 > startPos)
        {
            //if文の真偽を切り替えて適切な距離感でオブジェクトが配置されるように
            startPos += 15;

            //どのアイテムを出すのかをランダムに設定
            int num = Random.Range(1, 11);
                if (num <= 2)
                {
                    //コーンをx軸方向に一直線に生成
                    for (float j = -1; j <= 1; j += 0.4f)
                    {
                        //ObjectとGameObjectは継承関係にある
                        //Instantiateの戻り値はObjectなので、as GameObjectでGameObjectの型に入れている
                        GameObject cone = Instantiate(conePrefab) as GameObject;
                        cone.transform.position = new Vector3(4 * j, cone.transform.position.y, this.unitychan.transform.position.z + 40);
                    }
                }

                else
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        //アイテムの種類を決める
                        int item = Random.Range(1, 11);
                        //アイテムを置くz座標のオフセットをランダムに設定
                        int offsetZ = Random.Range(-5, 6);
                        //60%コイン配置：30%車配置：10%何もなし
                        if (1 <= item && item <= 6)
                        {
                            //コインを生成
                            GameObject coin = Instantiate(coinPrefab) as GameObject;
                            coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, this.unitychan.transform.position.z + 40 + offsetZ);

                        }
                        else if (7 <= item && item <= 9)
                        {
                            //車を生成
                            GameObject car = Instantiate(carPrefab) as GameObject;
                            car.transform.position = new Vector3(posRange * j, car.transform.position.y, this.unitychan.transform.position.z + 40 + offsetZ);
                           
                        }
                    }
                }
        }

        //ゴールより奥の座標にオブジェクトが生成されないように
        else if(this.unitychan.transform.position.z + 40 > goalpos)
        {
            Destroy(this.gameObject);
        }

    }

}
