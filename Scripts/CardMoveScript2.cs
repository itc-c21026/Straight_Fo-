using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/*------------------------------------------
 鳳側のカードをドラッグして駒や特殊玉を召喚するプログラム
 各プログラムの説明は龍側(CardMoveScript)に記載
------------------------------------------*/

public class CardMoveScript2 : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
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
    CostNumber2 script;

    public GameObject obj;
    CostXNumberScript1 script2;

    public GameObject obj2;
    GameController script3;
    CardShuffle script4;
    Ball2 script5;
    BlueYellow scriptBY;

    public GameObject aud;
    AudioScript script6;

    float x;
    float y;

    bool bl = true;

    public int scla;

    void Start()
    {
        scla = 4;

        drag = false;

        Cst = GameObject.Find("gageM2");
        script = Cst.GetComponent<CostNumber2>();

        obj2 = GameObject.Find("GameObject");
        script3 = obj2.GetComponent<GameController>();
        script4 = obj2.GetComponent<CardShuffle>();
        script5 = obj2.GetComponent<Ball2>();
        scriptBY = obj2.GetComponent<BlueYellow>();

        obj = GameObject.Find("Cost_X2");
        script2 = obj.GetComponent<CostXNumberScript1>();

        aud = GameObject.Find("Audio");
        script6 = aud.GetComponent<AudioScript>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (drag == false)
        {
            drag = true;
            Vector3 tmp = this.transform.position;
            x = tmp.x;
            y = tmp.y;

            ImgObj = eventData.pointerEnter.GetComponent<Image>();

            if (ImgObj.tag == "Cost2") script3.COSTst2 = "Cost2";
            if (ImgObj.tag == "Cost2_2") script3.COSTst2 = "Cost2_2";
            if (ImgObj.tag == "Cost3") script3.COSTst2 = "Cost3";
            if (ImgObj.tag == "Cost4") script3.COSTst2 = "Cost4";
            if (ImgObj.tag == "Cost5") script3.COSTst2 = "Cost5";

            sc();

            scriptBY.Yellow = true;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 temp = eventData.position;
        this.transform.position = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        scriptBY.Yellow = false;

        drag = false;

        bl = true;

        this.transform.position = new Vector3(x, y, 0);
        resc();

        Vector3 tmp2 = eventData.position;

        if (ImgObj.tag == "Cost2")
        {
            script2.AllClear();
            script2.nowNumber = 0;
            script3.COSTst2 = " ";
        }

        if (ImgObj.tag == "Cost2_2")
        {
            script2.AllClear();
            script2.nowNumber = 0;
            script3.COSTst2 = " ";
        }

        if (ImgObj.tag == "Cost3")
        {
            script2.AllClear();
            script2.nowNumber = 0;
            script3.COSTst2 = " ";
        }

        if (ImgObj.tag == "Cost4")
        {
            script2.AllClear();
            script2.nowNumber = 0;
            script3.COSTst2 = " ";
        }

        if (ImgObj.tag == "Cost5")
        {
            script2.AllClear();
            script2.nowNumber = 0;
            script3.COSTst2 = " ";
        }

        if (tmp2.x >= 930 && tmp2.x <= 1130 && tmp2.y >= 150 && tmp2.y <= 650)
        {
            if (ImgObj.tag == "Cost0")
            {
                card();

                script4.cms2 = 0;

                Effect0 = GameObject.Find("001_Shimple");
                GameObject prefab = (GameObject)Resources.Load("KOMA_Yellow");
                Instantiate(prefab, new Vector3((tmp2.x - 640) / 35, 1, (tmp2.y - 400) / 35), Quaternion.identity);

                GameObject clone = Instantiate(Effect0, new Vector3((tmp2.x - 640) / 35, 0.5f, (tmp2.y - 400) / 35), Quaternion.identity);
                clone.transform.Rotate(new Vector3(90, -90, 0));
                Destroy(clone, deleteTime);

                Cst.GetComponent<CostNumberImage2>().AllClear();
                Cst.GetComponent<CostNumberImage2>().Set1();
            }

            if (script.Cost >= 2)
            {
                if (ImgObj.tag == "Cost2")
                {

                    script.Cost -= 2;

                    card();

                    script4.cms2 = 1;

                    EffectD2 = GameObject.Find("003_Double");
                    GameObject prefab = (GameObject)Resources.Load("KOMA_Yellow");
                    Instantiate(prefab, new Vector3((tmp2.x - 640) / 35, 1, (tmp2.y - 400) / 35), Quaternion.identity);
                    Instantiate(prefab, new Vector3((tmp2.x - 640) / 35, 1, (tmp2.y - 400) / 35 - 1), Quaternion.identity);

                    GameObject clone = Instantiate(EffectD2, new Vector3((tmp2.x - 640) / 35, 0.5f, (tmp2.y - 400) / 35), Quaternion.identity);
                    clone.transform.Rotate(new Vector3(90, -90, 0));
                    Destroy(clone, deleteTime);

                    Cst.GetComponent<CostNumberImage2>().AllClear();
                    Cst.GetComponent<CostNumberImage2>().Set1();
                }

                if (ImgObj.tag == "Cost2_2")
                {
                    script.Cost -= 2;

                    card();

                    script4.cms2 = 2;

                    EffectS2 = GameObject.Find("002_Speed");
                    GameObject prefab = (GameObject)Resources.Load("KOMA_Yellow_S");
                    Instantiate(prefab, new Vector3((tmp2.x - 640) / 35, 1, (tmp2.y - 400) / 35), Quaternion.identity);
                    script5.S = true;

                    GameObject clone = Instantiate(EffectS2, new Vector3((tmp2.x - 640) / 35, 0.5f, (tmp2.y - 400) / 35), Quaternion.identity);
                    clone.transform.Rotate(new Vector3(90, -90, 0));
                    Destroy(clone, deleteTime);

                    Cst.GetComponent<CostNumberImage2>().AllClear();
                    Cst.GetComponent<CostNumberImage2>().Set1();
                }
            }

            if (script.Cost >= 3)
            {
                if (ImgObj.tag == "Cost3")
                {
                    script.Cost -= 3;

                    card();

                    script4.cms2 = 3;

                    // パックマン生成
                    EffectE3 = GameObject.Find("004_Eat");
                    GameObject prefab = (GameObject)Resources.Load("Pac_Prefab2");
                    Instantiate(prefab, new Vector3((tmp2.x - 640) / 35, 0, (tmp2.y - 400) / 35), Quaternion.identity);
                    // パックマン制御 true
                    script3.pacmanbl2_2 = true;

                    script6.audioSource.PlayOneShot(script6.sound1);

                    GameObject clone = Instantiate(EffectE3, new Vector3((tmp2.x - 640) / 35, 0.5f, (tmp2.y - 400) / 35), Quaternion.identity);
                    clone.transform.Rotate(new Vector3(90, -90, 0));
                    Destroy(clone, deleteTime);

                    Cst.GetComponent<CostNumberImage2>().AllClear();
                    Cst.GetComponent<CostNumberImage2>().Set1();
                }
            }

            if (script.Cost >= 4)
            {
                if (ImgObj.tag == "Cost4")
                {
                    script.Cost -= 4;

                    card();

                    script4.cms2 = 4;

                    // ボム生成
                    EffectB4 = GameObject.Find("006_Bom");
                    GameObject prefab = (GameObject)Resources.Load("bom2_1");
                    Instantiate(prefab, new Vector3((tmp2.x - 640) / 35, 0, (tmp2.y - 400) / 35), Quaternion.identity);

                    script6.audioSource.PlayOneShot(script6.sound4);

                    GameObject clone = Instantiate(EffectB4, new Vector3((tmp2.x - 640) / 35, 0.5f, (tmp2.y - 400) / 35), Quaternion.identity);
                    clone.transform.Rotate(new Vector3(90, -90, 0));
                    Destroy(clone, deleteTime);

                    Cst.GetComponent<CostNumberImage2>().AllClear();
                    Cst.GetComponent<CostNumberImage2>().Set1();
                }
            }

            if (script.Cost >= 5)
            {
                if (ImgObj.tag == "Cost5")
                {
                    script.Cost -= 5;

                    card();

                    script4.cms2 = 5;

                    // トラック生成
                    EffectT5 = GameObject.Find("001_Syoukan");
                    GameObject prefab = (GameObject)Resources.Load("track2");
                    Instantiate(prefab, new Vector3((tmp2.x - 640) / 35, -0.3f, (tmp2.y - 400) / 35), Quaternion.identity);
                    // トラック制御 true
                    script3.trackbl2_2 = true;

                    script6.audioSource.PlayOneShot(script6.sound6);

                    GameObject clone = Instantiate(EffectT5, new Vector3((tmp2.x - 640) / 35, 0.5f, (tmp2.y - 400) / 35), Quaternion.identity);
                    clone.transform.Rotate(new Vector3(90, -90, 0));
                    Destroy(clone, deleteTime);

                    Cst.GetComponent<CostNumberImage2>().AllClear();
                    Cst.GetComponent<CostNumberImage2>().Set1();
                }
            }
        }
    }
 
    void card()
    {
        script4.prefab2[script4.Taiki2[0]].transform.Rotate(new Vector3(0, 0, 0));
        this.transform.position += new Vector3(1000, 0, 0);

        script4.x2 = x;
        script4.y2 = y;
        script4.bl3 = true;

        script6.audioSource.PlayOneShot(script6.sound7);
    }

    void sc()
    {
        if (ImgObj.tag == "Cost0")
        {
            script4.prefab2[1].SetActive(false);
            script4.prefab2[2].SetActive(false);
            script4.prefab2[3].SetActive(false);
            script4.prefab2[4].SetActive(false);
            script4.prefab2[5].SetActive(false);
        }

        if (ImgObj.tag == "Cost2")
        {
            script4.prefab2[0].SetActive(false);
            script4.prefab2[2].SetActive(false);
            script4.prefab2[3].SetActive(false);
            script4.prefab2[4].SetActive(false);
            script4.prefab2[5].SetActive(false);
        }

        if (ImgObj.tag == "Cost2_2")
        {
            script4.prefab2[1].SetActive(false);
            script4.prefab2[0].SetActive(false);
            script4.prefab2[3].SetActive(false);
            script4.prefab2[4].SetActive(false);
            script4.prefab2[5].SetActive(false);
        }

        if (ImgObj.tag == "Cost3")
        {
            script4.prefab2[1].SetActive(false);
            script4.prefab2[2].SetActive(false);
            script4.prefab2[0].SetActive(false);
            script4.prefab2[4].SetActive(false);
            script4.prefab2[5].SetActive(false);
        }

        if (ImgObj.tag == "Cost4")
        {
            script4.prefab2[1].SetActive(false);
            script4.prefab2[2].SetActive(false);
            script4.prefab2[3].SetActive(false);
            script4.prefab2[0].SetActive(false);
            script4.prefab2[5].SetActive(false);
        }

        if (ImgObj.tag == "Cost5")
        {
            script4.prefab2[1].SetActive(false);
            script4.prefab2[2].SetActive(false);
            script4.prefab2[3].SetActive(false);
            script4.prefab2[4].SetActive(false);
            script4.prefab2[0].SetActive(false);
        }
    }

    void resc()
    {
        if (ImgObj.tag == "Cost0")
        {
            script4.prefab2[1].SetActive(true);
            script4.prefab2[2].SetActive(true);
            script4.prefab2[3].SetActive(true);
            script4.prefab2[4].SetActive(true);
            script4.prefab2[5].SetActive(true);
        }

        if (ImgObj.tag == "Cost2")
        {
            script4.prefab2[0].SetActive(true);
            script4.prefab2[2].SetActive(true);
            script4.prefab2[3].SetActive(true);
            script4.prefab2[4].SetActive(true);
            script4.prefab2[5].SetActive(true);
        }

        if (ImgObj.tag == "Cost2_2")
        {
            script4.prefab2[1].SetActive(true);
            script4.prefab2[0].SetActive(true);
            script4.prefab2[3].SetActive(true);
            script4.prefab2[4].SetActive(true);
            script4.prefab2[5].SetActive(true);
        }

        if (ImgObj.tag == "Cost3")
        {
            script4.prefab2[1].SetActive(true);
            script4.prefab2[2].SetActive(true);
            script4.prefab2[0].SetActive(true);
            script4.prefab2[4].SetActive(true);
            script4.prefab2[5].SetActive(true);
        }

        if (ImgObj.tag == "Cost4")
        {
            script4.prefab2[1].SetActive(true);
            script4.prefab2[2].SetActive(true);
            script4.prefab2[3].SetActive(true);
            script4.prefab2[0].SetActive(true);
            script4.prefab2[5].SetActive(true);
        }

        if (ImgObj.tag == "Cost5")
        {
            script4.prefab2[1].SetActive(true);
            script4.prefab2[2].SetActive(true);
            script4.prefab2[3].SetActive(true);
            script4.prefab2[4].SetActive(true);
            script4.prefab2[0].SetActive(true);
        }
    }
}
