using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
public class TagAnimation : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    public float hideX, showX, time;
    Image image;
    private void Awake()
    {
        
    }
    void Start()
    {
        this.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1F;
        GameObject.Find("RimBroad").GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1F;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.GetComponent<RectTransform>().DOAnchorPosX(showX, time);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.GetComponent<RectTransform>().DOAnchorPosX(hideX, time);
    }
}

