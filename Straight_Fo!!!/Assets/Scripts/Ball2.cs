using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*--------------------------------
 鳳側の駒を投げるプログラム
 各プログラムの説明は龍側(Ball)に記載
--------------------------------*/
public class Ball2 : MonoBehaviour
{
    public GameObject aud;
    AudioScript script;

    [SerializeField]
    private Text testText;

    public float thrust;

    // フリック最小移動距離
    [SerializeField]
    private Vector2 FlickMinRange = new Vector2(30.0f, 30.0f);
    // スワイプ最小移動距離
    //[SerializeField]
    private Vector2 SwipeMinRange = new Vector2(50.0f, 50.0f);
    // TAPをNONEに戻すまでのカウント
    [SerializeField]
    private int NoneCountMax = 2;
    private int NoneCountNow = 0;
    // スワイプ入力距離
    private Vector2 SwipeRange;
    // 入力方向記録用
    private Vector2 InputSTART;
    private Vector2 InputMOVE;
    private Vector2 InputEND;
    // フリックの方向
    public enum FlickDirection
    {
        NONE,
        TAP,
        UP,
        RIGHT,
        DOWN,
        LEFT,
        UP_LEFT,
        UP_RIGHT,
        DOWN_LEFT,
        DOWN_RIGHT,
    }
    public FlickDirection NowFlick = FlickDirection.NONE;
    // スワイプの方向
    public enum SwipeDirection
    {
        NONE,
        TAP,
        UP,
        RIGHT,
        DOWN,
        LEFT,
        UP_LEFT,
        UP_RIGHT,
        DOWN_LEFT,
        DOWN_RIGHT
    }
    private SwipeDirection NowSwipe = SwipeDirection.NONE;
    Plane plane;
    bool isGrabbing;
    Transform cube;

    Rigidbody rb;

    float Flk;
    public bool S;
    public bool bom;
    public bool bom2;

    // Start is called before the first frame update
    void Start()
    {
        aud = GameObject.Find("Audio");
        script = aud.GetComponent<AudioScript>();

        bom = false;
        bom2 = false;
        plane = new Plane(Vector3.up, Vector3.up);

        thrust = 50;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && Input.mousePosition.x >= 880)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.tag == "KOMA2")
                {
                    rb = hit.collider.GetComponent<Rigidbody>();
                    isGrabbing = true;
                    cube = hit.transform;
                }


                if (hit.collider.tag == "BOM")
                {
                    // Rigidbodyコンポーネント取得
                    rb = hit.collider.GetComponent<Rigidbody>();
                    isGrabbing = true;
                    cube = hit.transform;
                    bom = true;
                }

            }

        }


        if (isGrabbing && Input.mousePosition.x >= 780)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float rayDistance;
            plane.Raycast(ray, out rayDistance);

            cube.position = ray.GetPoint(rayDistance + 1.3f);
            if (Input.GetMouseButtonUp(0))
            {
                script.audioSource.PlayOneShot(script.sound17);

                bom2 = true;
                Flk = thrust * GetSwipeRange();
                if (S == true)
                {
                    Flk *= 1.2f;
                    if (Flk > 2000)
                    {
                        Flk = 2000;
                    }
                }
                else if (Flk > 1000)
                {
                    Flk = 1000;
                }

                S = false;

                if (NowSwipe == SwipeDirection.UP)
                {
                    rb.AddForce(new Vector3(0, 0, 1) * Flk);
                }
                if (NowSwipe == SwipeDirection.RIGHT)
                {
                    rb.AddForce(new Vector3(1, 0, 0) * Flk);
                }
                if (NowSwipe == SwipeDirection.LEFT)
                {
                    rb.AddForce(new Vector3(-1, 0, 0) * Flk);
                }
                if (NowSwipe == SwipeDirection.DOWN)
                {
                    rb.AddForce(new Vector3(0, 0, -1) * Flk);
                }
                if (NowSwipe == SwipeDirection.UP_RIGHT)
                {
                    rb.AddForce(new Vector3(1, 0, 1) * Flk);
                }
                if (NowSwipe == SwipeDirection.UP_LEFT)
                {
                    rb.AddForce(new Vector3(-1, 0, 1) * Flk);
                }
                if (NowSwipe == SwipeDirection.DOWN_RIGHT)
                {
                    rb.AddForce(new Vector3(1, 0, -1) * Flk);
                }
                if (NowSwipe == SwipeDirection.DOWN_LEFT)
                {
                    rb.AddForce(new Vector3(-1, 0, -1) * Flk);
                }

                isGrabbing = false;
            }
        }

        if (Application.isEditor)
        {
            if (Input.mousePosition.x >= 780)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    InputSTART = Input.mousePosition;
                }
                else if (Input.GetMouseButton(0))
                {
                    InputMOVE = Input.mousePosition;
                    SwipeCLC();
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    InputEND = Input.mousePosition;
                    FlickCLC();
                }
                else if (NowFlick != FlickDirection.NONE || NowSwipe != SwipeDirection.NONE)
                {
                    ResetParameter();
                }
            }
        }

        // ------------------------
        Touch[] touches = Input.touches;
        for (int i = 0; i < touches.Length; i++)
        {
            Touch t = touches[i];
            var touch = Input.touches[i];

            if (Input.touchCount > 0 && touch.position.x >= 880)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);

                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    if (hit.collider.tag == "KOMA2")
                    {
                        rb = hit.collider.GetComponent<Rigidbody>();
                        isGrabbing = true;
                        cube = hit.transform;
                    }
                }
            }


            if (isGrabbing && touch.position.x >= 780)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                float rayDistance;
                plane.Raycast(ray, out rayDistance);

                cube.position = ray.GetPoint(rayDistance + 1.3f);
                if (touch.phase == TouchPhase.Ended)
                {
                    bom2 = true;
                    Flk = thrust * GetSwipeRange();
                    if (Flk > 1000)
                    {
                        Flk = 1000;
                    }
                    Debug.Log(GetSwipeRange());
                    if (NowSwipe == SwipeDirection.UP)
                    {
                        rb.AddForce(new Vector3(0, 0, 1) * Flk);
                    }
                    if (NowSwipe == SwipeDirection.RIGHT)
                    {
                        rb.AddForce(new Vector3(1, 0, 0) * Flk);
                    }
                    if (NowSwipe == SwipeDirection.LEFT)
                    {
                        rb.AddForce(new Vector3(-1, 0, 0) * Flk);
                    }
                    if (NowSwipe == SwipeDirection.DOWN)
                    {
                        rb.AddForce(new Vector3(0, 0, -1) * Flk);
                    }
                    if (NowSwipe == SwipeDirection.UP_RIGHT)
                    {
                        rb.AddForce(new Vector3(1, 0, 1) * Flk);
                    }
                    if (NowSwipe == SwipeDirection.UP_LEFT)
                    {
                        rb.AddForce(new Vector3(-1, 0, 1) * Flk);
                    }
                    if (NowSwipe == SwipeDirection.DOWN_RIGHT)
                    {
                        rb.AddForce(new Vector3(1, 0, -1) * Flk);
                    }
                    if (NowSwipe == SwipeDirection.DOWN_LEFT)
                    {
                        rb.AddForce(new Vector3(-1, 0, -1) * Flk);
                    }
                    isGrabbing = false;
                }
            }

            if (Input.touchCount > 0)
            {
                if (touch.position.x >= 780)
                {

                    if (touch.phase == TouchPhase.Began)
                    {
                        InputSTART = touch.position;
                    }
                    else if (touch.phase == TouchPhase.Moved)
                    {
                        InputMOVE = touch.position;
                        SwipeCLC();
                    }
                    else if (touch.phase == TouchPhase.Ended)
                    {
                        InputEND = touch.position;
                        FlickCLC();
                    }
                    else if (NowFlick != FlickDirection.NONE || NowSwipe != SwipeDirection.NONE)
                    {
                        ResetParameter();
                    }
                }
            }
        }
    }
    private void GetInputVector()
    {

        // Unity上での操作取得
        if (Application.isEditor)
        {
            if (Input.GetMouseButtonDown(0))
            {
                InputSTART = Input.mousePosition;
            }
            else if (Input.GetMouseButton(0))
            {
                InputMOVE = Input.mousePosition;
                SwipeCLC();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                InputEND = Input.mousePosition;
                FlickCLC();
            }
            else if (NowFlick != FlickDirection.NONE || NowSwipe != SwipeDirection.NONE)
            {
                ResetParameter();
            }
        }
    }

    // 入力内容からフリック方向を計算
    private void FlickCLC()
    {
        Vector2 _work = new Vector2((new Vector3(InputEND.x, 0, 0) - new Vector3(InputSTART.x, 0, 0)).magnitude, (new Vector3(0, InputEND.y, 0) - new Vector3(0, InputSTART.y, 0)).magnitude);

        if (_work.x <= FlickMinRange.x && _work.y <= FlickMinRange.y)
        {
            NowFlick = FlickDirection.TAP;
        }
        else
        {
            float _angle = Mathf.Atan2(InputEND.y - InputSTART.y, InputEND.x - InputSTART.x) * Mathf.Rad2Deg;

            if (-22.5f <= _angle && _angle < 22.5f) NowFlick = FlickDirection.RIGHT;
            else if (22.5f <= _angle && _angle < 67.5f) NowFlick = FlickDirection.UP_RIGHT;
            else if (67.5f <= _angle && _angle < 112.5f) NowFlick = FlickDirection.UP;
            else if (112.5f <= _angle && _angle < 157.5f) NowFlick = FlickDirection.UP_LEFT;
            else if (157.5f <= _angle || _angle < -157.5f) NowFlick = FlickDirection.LEFT;
            else if (-157.5f <= _angle && _angle < -112.5f) NowFlick = FlickDirection.DOWN_LEFT;
            else if (-112.5f <= _angle && _angle < -67.5f) NowFlick = FlickDirection.DOWN;
            else if (-67.5f <= _angle && _angle < -22.5f) NowFlick = FlickDirection.DOWN_RIGHT;
        }
    }

    // 入力内容からスワイプ方向を計算
    private void SwipeCLC()
    {
        SwipeRange = new Vector2((new Vector3(InputMOVE.x, 0, 0) - new Vector3(InputSTART.x, 0, 0)).magnitude, (new Vector3(0, InputMOVE.y, 0) - new Vector3(0, InputSTART.y, 0)).magnitude);

        if (SwipeRange.x <= SwipeMinRange.x && SwipeRange.y <= SwipeMinRange.y)
        {
            NowSwipe = SwipeDirection.TAP;
        }
        else
        {
            float _angle = Mathf.Atan2(InputMOVE.y - InputSTART.y, InputMOVE.x - InputSTART.x) * Mathf.Rad2Deg;

            if (-22.5f <= _angle && _angle < 22.5f) NowSwipe = SwipeDirection.RIGHT;
            else if (22.5f <= _angle && _angle < 67.5f) NowSwipe = SwipeDirection.UP_RIGHT;
            else if (67.5f <= _angle && _angle < 112.5f) NowSwipe = SwipeDirection.UP;
            else if (112.5f <= _angle && _angle < 157.5f) NowSwipe = SwipeDirection.UP_LEFT;
            else if (157.5f <= _angle || _angle < -157.5f) NowSwipe = SwipeDirection.LEFT;
            else if (-157.5f <= _angle && _angle < -112.5f) NowSwipe = SwipeDirection.DOWN_LEFT;
            else if (-112.5f <= _angle && _angle < -67.5f) NowSwipe = SwipeDirection.DOWN;
            else if (-67.5f <= _angle && _angle < -22.5f) NowSwipe = SwipeDirection.DOWN_RIGHT;
        }
    }

    // NONEにリセット
    private void ResetParameter()
    {
        NoneCountNow++;
        if (NoneCountNow >= NoneCountMax)
        {
            NoneCountNow = 0;
            NowFlick = FlickDirection.NONE;
            NowSwipe = SwipeDirection.NONE;
            SwipeRange = new Vector2(0, 0);
        }
    }

    // フリック方向の取得
    public FlickDirection GetNowFlick()
    {
        return NowFlick;
    }

    // スワイプ方向の取得
    public SwipeDirection GetNowSwipe()
    {
        return NowSwipe;
    }

    // スワイプ量の取得
    public float GetSwipeRange()
    {
        if (SwipeRange.x > SwipeRange.y)
        {
            return SwipeRange.x;
        }
        else
        {
            return SwipeRange.y;
        }
    }

    // スワイプ量の取得
    public Vector2 GetSwipeRangeVec()
    {
        if (NowSwipe != SwipeDirection.NONE)
        {
            return new Vector2(InputMOVE.x - InputSTART.x, InputMOVE.y - InputSTART.y);
        }
        else
        {
            return new Vector2(0, 0);
        }
    }

    public class RayDistanceCompare : IComparer<RaycastHit>
    {
        public int Compare(RaycastHit x, RaycastHit y)
        {
            if (x.distance < y.distance)
            {
                return -1;
            }
            if (x.distance > y.distance)
            {
                return 1;
            }
            return 0;
        }
    }
}
