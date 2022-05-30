using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/*------------------------------------------
 龍側のカードをドラッグして駒や特殊玉を召喚するプログラム
-------------------------------------------*/

public class CardMoveScript : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{

    bool drag;

    public GameObject Effect0;
    public GameObject EffectS2;
    public GameObject EffectD2;
    public GameObject EffectE3;
    public GameObject EffectB4;
    public GameObject EffectT5;
    public float deleteTime = 1f;

    public Image ImgObj;
    
    public GameObject Cst;
    CostNumber script;

    public GameObject obj;
    CostXNumberScript script2;

    public GameObject obj2;
    GameController script3;
    CardShuffle script4;
    Ball script6;
    BlueYellow scriptBY;

    public GameObject aud;
    AudioScript script7;

    float b;

    float x;
    float y;

    bool bl = true;
    public bool BOMbl2;

    public int scla;

    void Start()
    {

        scla = 4;

        drag = false;

        Cst = GameObject.Find("gageM");
        script = Cst.GetComponent<CostNumber>();

        obj = GameObject.Find("Cost_X");
        script2 = obj.GetComponent<CostXNumberScript>();

        obj2 = GameObject.Find("GameObject");
        script3 = obj2.GetComponent<GameController>();
        script4 = obj2.GetComponent<CardShuffle>();
        script6 = obj2.GetComponent<Ball>();
        scriptBY = obj2.GetComponent<BlueYellow>();

        aud = GameObject.Find("Audio");
        script7 = aud.GetComponent<AudioScript>();

        Application.targetFrameRate = 30;
    }

    // カードを掴み始めた時のプログラム
    public void OnPointerDown(PointerEventData eventData)
    {
        if (drag == false)
        {
            drag = true;

            // カードの座標取得
            Vector3 tmp = this.transform.position;
            x = tmp.x;
            y = tmp.y;

            // ImgObjに掴んだオブジェクトのImageコンポーネントを取得
            ImgObj = eventData.pointerEnter.GetComponent<Image>();

            // ImgObjのタグを他のスクリプトのstringに代入
            if (ImgObj.tag == "Cost2") script3.COSTst = "Cost2";
            if (ImgObj.tag == "Cost2_2") script3.COSTst = "Cost2_2";
            if (ImgObj.tag == "Cost3") script3.COSTst = "Cost3";
            if (ImgObj.tag == "Cost4") script3.COSTst = "Cost4";
            if (ImgObj.tag == "Cost5") script3.COSTst = "Cost5";

            sc();

            scriptBY.Blue = true;
        }
    }

    // カードを掴んでいる間のプログラム
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 temp = eventData.position;
        this.transform.position = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        scriptBY.Blue = false;

        drag = false;

        bl = true;

        this.transform.position = new Vector3(x, y, 0);
        resc();

        Vector3 tmp2 = eventData.position;


        // ImgObjのタグにより、コストの変動
        if (ImgObj.tag == "Cost2")
        {
            script2.AllClear();
            script2.nowNumber = 0;
            script3.COSTst = " ";
        }

        if (ImgObj.tag == "Cost2_2")
        {
            script2.AllClear();
            script2.nowNumber = 0;
            script3.COSTst = " ";
        }

        if (ImgObj.tag == "Cost3")
        {
            script2.AllClear();
            script2.nowNumber = 0;
            script3.COSTst = " ";
        }

        if (ImgObj.tag == "Cost4")
        {
            script2.AllClear();
            script2.nowNumber = 0;
            script3.COSTst = " ";
        }

        if (ImgObj.tag == "Cost5")
        {
            script2.AllClear();
            script2.nowNumber = 0;
            script3.COSTst = " ";
        }

        if (tmp2.x <= 350 && tmp2.x >= 150 && tmp2.y >= 150 && tmp2.y <= 650)
        {


            if (ImgObj.tag == "Cost0")
            {
                card();

                script4.cms = 0;

                // 青い駒を生成
                GameObject prefab = (GameObject)Resources.Load("KOMA_Blue");
                Instantiate(prefab, new Vector3((tmp2.x - 640) / 35, 1, (tmp2.y - 400) / 35), Quaternion.identity);

                // "狛"エフェクト生成
                Effect0 = GameObject.Find("001_Shimple");
                GameObject clone = Instantiate(Effect0, new Vector3((tmp2.x - 640) / 35, 0.5f, (tmp2.y - 400) / 35), Quaternion.identity);
                clone.transform.Rotate(new Vector3(90, 90, 0));
                Destroy(clone, deleteTime);

                // コスト変動 ※コスト0なので変動なし
                Cst.GetComponent<CostNumberImage>().AllClear();
                Cst.GetComponent<CostNumberImage>().Set1();
            }

            if (script.Cost >= 2)
            {
                if (ImgObj.tag == "Cost2")
                {
                    // コスト消費2
                    script.Cost -= 2;

                    card();

                    script4.cms = 1;

                    // 青い駒2個生成
                    GameObject prefab = (GameObject)Resources.Load("KOMA_blue");
                    Instantiate(prefab, new Vector3((tmp2.x - 640) / 35, 1, (tmp2.y - 400) / 35), Quaternion.identity);
                    Instantiate(prefab, new Vector3((tmp2.x - 640) / 35, 1, (tmp2.y - 400) / 35 - 1), Quaternion.identity);

                    // "双"エフェクト生成
                    EffectD2 = GameObject.Find("003_Double");
                    GameObject clone = Instantiate(EffectD2, new Vector3((tmp2.x - 640) / 35, 0.5f, (tmp2.y - 400) / 35), Quaternion.identity);
                    clone.transform.Rotate(new Vector3(90, 90, 0));
                    Destroy(clone, deleteTime);

                    // コスト変動 全部非表示にさせ、コスト消費した後の数を表示
                    Cst.GetComponent<CostNumberImage>().AllClear();
                    Cst.GetComponent<CostNumberImage>().Set1();
                }

                if (ImgObj.tag == "Cost2_2")
                {
                    script.Cost -= 2;

                    card();

                    script4.cms = 2;

                    // 青い駒Sを生成
                    EffectS2 = GameObject.Find("002_Speed");
                    GameObject prefab = (GameObject)Resources.Load("KOMA_Blue_S");
                    Instantiate(prefab, new Vector3((tmp2.x - 640) / 35, 1, (tmp2.y - 400) / 35), Quaternion.identity);
                    script6.S = true;

                    // "速"エフェクト生成
                    GameObject clone = Instantiate(EffectS2, new Vector3((tmp2.x - 640) / 35, 0.5f, (tmp2.y - 400) / 35), Quaternion.identity);
                    clone.transform.Rotate(new Vector3(90, 90, 0));
                    Destroy(clone, deleteTime);

                    // コスト変動
                    Cst.GetComponent<CostNumberImage>().AllClear();
                    Cst.GetComponent<CostNumberImage>().Set1();
                }
            }

            if (script.Cost >= 3)
            {
                if (ImgObj.tag == "Cost3")
                {
                    // コスト3消費
                    script.Cost -= 3;

                    card();

                    script4.cms = 3;

                    // パックマン生成
                    EffectE3 = GameObject.Find("004_Eat");
                    GameObject prefab = (GameObject)Resources.Load("Pac_Prefab");
                    Instantiate(prefab, new Vector3((tmp2.x - 640) / 35, 0, (tmp2.y - 400) / 35), Quaternion.identity);
                    // パックマン制御 true
                    script3.pacmanbl2 = true;

                    script7.audioSource.PlayOneShot(script7.sound1);

                    // "喰"エフェクト生成
                    GameObject clone = Instantiate(EffectE3, new Vector3((tmp2.x - 640) / 35, 0.5f, (tmp2.y - 400) / 35), Quaternion.identity);
                    clone.transform.Rotate(new Vector3(90, 90, 0));
                    Destroy(clone, deleteTime);

                    // コスト変動
                    Cst.GetComponent<CostNumberImage>().AllClear();
                    Cst.GetComponent<CostNumberImage>().Set1();
                }
            }

            if (script.Cost >= 4)
            {
                if (ImgObj.tag == "Cost4")
                {
                    // コスト4消費
                    script.Cost -= 4;

                    card();

                    script4.cms = 4;

                    // ボム生成
                    EffectB4 = GameObject.Find("006_Bom");
                    GameObject prefab = (GameObject)Resources.Load("bom2");
                    Instantiate(prefab, new Vector3((tmp2.x - 640) / 35, 0, (tmp2.y - 400) / 35), Quaternion.identity);

                    script7.audioSource.PlayOneShot(script7.sound4);

                    // "爆"エフェクト生成
                    GameObject clone = Instantiate(EffectB4, new Vector3((tmp2.x - 640) / 35, 0.5f, (tmp2.y - 400) / 35), Quaternion.identity);
                    clone.transform.Rotate(new Vector3(90, 90, 0));
                    Destroy(clone, deleteTime);

                    // コスト変動
                    Cst.GetComponent<CostNumberImage>().AllClear();
                    Cst.GetComponent<CostNumberImage>().Set1();
                }
            }

            if (script.Cost >= 5)
            {
                if (ImgObj.tag == "Cost5")
                {
                    // コスト5消費
                    script.Cost -= 5;

                    card();

                    script4.cms = 5;

                    // トラック生成
                    EffectT5 = GameObject.Find("001_Syoukan");
                    GameObject prefab = (GameObject)Resources.Load("track");
                    Instantiate(prefab, new Vector3((tmp2.x - 640) / 35, -0.3f, (tmp2.y - 400) / 35), Quaternion.identity);
                    // トラック制御 true
                    script3.trackbl2 = true;

                    script7.audioSource.PlayOneShot(script7.sound6);

                    // "突"エフェクト生成
                    GameObject clone = Instantiate(EffectT5, new Vector3((tmp2.x - 640) / 35, 0.5f, (tmp2.y - 400) / 35), Quaternion.identity);
                    clone.transform.Rotate(new Vector3(90, 90, 0));
                    Destroy(clone, deleteTime);

                    // コスト変動
                    Cst.GetComponent<CostNumberImage>().AllClear();
                    Cst.GetComponent<CostNumberImage>().Set1();
                }
            }
        }

        ImgObj = null;
    }

    void card()
    {
        this.transform.position += new Vector3(-1000, 0, 0);

        script4.x = x;
        script4.y = y;
        script4.bl = true;

        script7.audioSource.PlayOneShot(script7.sound7);
    }

    void sc()
    {
        if (ImgObj.tag == "Cost0")
        {
            script4.prefab[1].SetActive(false);
            script4.prefab[2].SetActive(false);
            script4.prefab[3].SetActive(false);
            script4.prefab[4].SetActive(false);
            script4.prefab[5].SetActive(false);
        }

        if (ImgObj.tag == "Cost2")
        {
            script4.prefab[0].SetActive(false);
            script4.prefab[2].SetActive(false);
            script4.prefab[3].SetActive(false);
            script4.prefab[4].SetActive(false);
            script4.prefab[5].SetActive(false);
        }

        if (ImgObj.tag == "Cost2_2")
        {
            script4.prefab[1].SetActive(false);
            script4.prefab[0].SetActive(false);
            script4.prefab[3].SetActive(false);
            script4.prefab[4].SetActive(false);
            script4.prefab[5].SetActive(false);
        }

        if (ImgObj.tag == "Cost3")
        {
            script4.prefab[1].SetActive(false);
            script4.prefab[2].SetActive(false);
            script4.prefab[0].SetActive(false);
            script4.prefab[4].SetActive(false);
            script4.prefab[5].SetActive(false);
        }

        if (ImgObj.tag == "Cost4")
        {
            script4.prefab[1].SetActive(false);
            script4.prefab[2].SetActive(false);
            script4.prefab[3].SetActive(false);
            script4.prefab[0].SetActive(false);
            script4.prefab[5].SetActive(false);
        }

        if (ImgObj.tag == "Cost5")
        {
            script4.prefab[1].SetActive(false);
            script4.prefab[2].SetActive(false);
            script4.prefab[3].SetActive(false);
            script4.prefab[4].SetActive(false);
            script4.prefab[0].SetActive(false);
        }
    }

    void resc()
    {
        if (ImgObj.tag == "Cost0")
        {
            script4.prefab[1].SetActive(true);
            script4.prefab[2].SetActive(true);
            script4.prefab[3].SetActive(true);
            script4.prefab[4].SetActive(true);
            script4.prefab[5].SetActive(true);
        }

        if (ImgObj.tag == "Cost2")
        {
            script4.prefab[0].SetActive(true);
            script4.prefab[2].SetActive(true);
            script4.prefab[3].SetActive(true);
            script4.prefab[4].SetActive(true);
            script4.prefab[5].SetActive(true);
        }

        if (ImgObj.tag == "Cost2_2")
        {
            script4.prefab[1].SetActive(true);
            script4.prefab[0].SetActive(true);
            script4.prefab[3].SetActive(true);
            script4.prefab[4].SetActive(true);
            script4.prefab[5].SetActive(true);
        }

        if (ImgObj.tag == "Cost3")
        {
            script4.prefab[1].SetActive(true);
            script4.prefab[2].SetActive(true);
            script4.prefab[0].SetActive(true);
            script4.prefab[4].SetActive(true);
            script4.prefab[5].SetActive(true);
        }

        if (ImgObj.tag == "Cost4")
        {
            script4.prefab[1].SetActive(true);
            script4.prefab[2].SetActive(true);
            script4.prefab[3].SetActive(true);
            script4.prefab[0].SetActive(true);
            script4.prefab[5].SetActive(true);
        }

        if (ImgObj.tag == "Cost5")
        {
            script4.prefab[1].SetActive(true);
            script4.prefab[2].SetActive(true);
            script4.prefab[3].SetActive(true);
            script4.prefab[4].SetActive(true);
            script4.prefab[0].SetActive(true);
        }
    }
}
