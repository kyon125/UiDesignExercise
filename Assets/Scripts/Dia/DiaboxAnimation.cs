using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DiaboxAnimation : MonoBehaviour
{
    public static DiaboxAnimation diaboxAnimation;
    // Start is called before the first frame update
    public Color backgroundcolor;
    public GameObject corner;
    public float squarerotate, rotatetime;
    public Image background , nameBackground ,square ,lt, lb, rt, rb;
    [SerializeField]
    public List<moveEvent> moves = new List<moveEvent>();
    public bool playend;

    float nowrotate;
   
    private void Awake()
    {
        diaboxAnimation = this;
    }
    void Start()
    {
        corner.transform.rotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
               
    }
    
    private void FixedUpdate()
    {
        square.transform.rotation = Quaternion.Euler(0, 0, nowrotate);
    }
    public virtual void diaboxOpen()
    {
        StartCoroutine(diaboxopenSet());
    }
    public virtual void diaboxClose()
    {
        StartCoroutine(diaboxcloseSet());
    }
    IEnumerator diaboxopenSet()
    {
        playend = false;
        for (int i = 0; i < moves.Count; i++)
        {
            switch (moves[i].moveaxial)
            {
                case (moveAxial.x):
                    corner.GetComponent<RectTransform>().DOAnchorPosX(moves[i].movevalue, moves[i].movetime).SetEase(moves[i].easetype);
                    square.GetComponent<RectTransform>().DOAnchorPosX(moves[i].movevalue, moves[i].movetime).SetEase(moves[i].easetype);
                    break;
                case (moveAxial.y):
                    corner.GetComponent<RectTransform>().DOAnchorPosY(moves[i].movevalue, moves[i].movetime).SetEase(moves[i].easetype);
                    square.GetComponent<RectTransform>().DOAnchorPosY(moves[i].movevalue, moves[i].movetime).SetEase(moves[i].easetype);
                    break;
                //case (moveAxial.z):
                //    corner.transform.DOMoveZ(moves[i].movevalue, moves[i].movetime).SetEase(moves[i].easetype);
                //    square.transform.DOMoveZ(moves[i].movevalue, moves[i].movetime).SetEase(moves[i].easetype);
                //    break;
            }
            yield return new WaitForSeconds(moves[i].movetime);
        }
        DOTween.To(() => nowrotate, x => nowrotate = x, squarerotate, rotatetime);
        lb.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-912, -72), rotatetime);
        lt.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-912, 45), rotatetime);
        rb.GetComponent<RectTransform>().DOAnchorPos(new Vector2(912, -68), rotatetime);
        rt.GetComponent<RectTransform>().DOAnchorPos(new Vector2(912, 49), rotatetime);
        Tween t1 = square.DOFade(0, rotatetime);
        Tween t2 = background.DOColor(backgroundcolor, rotatetime);
        Tween t3 = background.transform.DOScale(new Vector3(1, 1, 1), rotatetime);
        yield return new WaitForSeconds(rotatetime);
        //©m¶WÆÿ≈„•‹
        yield return nameBackground.transform.DOScale(new Vector3(1, 1, 1), 0.01f);
        Tween t5 = nameBackground.transform.GetComponent<RectTransform>().DOAnchorPosY(-318, 0.15f);
        yield return new WaitForSeconds(0.15f);

        playend = true;
    }
    IEnumerator diaboxcloseSet()
    {
        playend = false;

        Tween t5 = nameBackground.transform.GetComponent<RectTransform>().DOAnchorPosY(-420, 0.15f);
        yield return new WaitForSeconds(0.15f);
        Tween t4 = nameBackground.transform.DOScale(new Vector3(0, 0, 1), 0.01f);        
        DOTween.To(() => nowrotate, x => nowrotate = x, 0, rotatetime);
        lb.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0), rotatetime);
        lt.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0), rotatetime);
        rb.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0), rotatetime);
        rt.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0), rotatetime);
        Tween t1 = square.DOFade(1, rotatetime);
        Tween t2 = background.DOFade(0, rotatetime);
        Tween t3 = background.transform.DOScale(new Vector3(0, 0, 0), rotatetime);
        yield return new WaitForSeconds(rotatetime);
        for (int i = 0; i < moves.Count; i++)
        {
            switch (moves[i].moveaxial)
            {
                case (moveAxial.x):
                    corner.GetComponent<RectTransform>().DOAnchorPosX(-moves[i].movevalue, moves[i].movetime).SetEase(moves[i].easetype);
                    square.GetComponent<RectTransform>().DOAnchorPosX(-moves[i].movevalue, moves[i].movetime).SetEase(moves[i].easetype);
                    break;
                case (moveAxial.y):
                    corner.GetComponent<RectTransform>().DOAnchorPosY(-614, moves[i].movetime).SetEase(moves[i].easetype);
                    square.GetComponent<RectTransform>().DOAnchorPosY(-614, moves[i].movetime).SetEase(moves[i].easetype);
                    break;
                case (moveAxial.z):
                    corner.transform.DOMoveZ(-moves[i].movevalue, moves[i].movetime).SetEase(moves[i].easetype);
                    square.transform.DOMoveZ(-moves[i].movevalue, moves[i].movetime).SetEase(moves[i].easetype);
                    break;
            }
            yield return new WaitForSeconds(moves[i].movetime);
        }
        playend = true;
        GameStatusController.gameStatusController.gameStatus = GameStatus.isGameing;
    }
}


[System.Serializable]
public class moveEvent
{    
    public string name = "move";    
    public moveAxial moveaxial;
    public Ease easetype;
    public float movevalue;
    public float movetime;
}
[System.Serializable]
public enum moveAxial
{
    x,
    y,
    z
}
