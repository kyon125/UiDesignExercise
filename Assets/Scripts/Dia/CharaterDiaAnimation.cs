using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class CharaterDiaAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    public CharaEmotionSprite source;
    public int firstShow;
    public CharaPosition charaPosition;
    public Image image;
    public bool isEnter = false;
    public bool isSpeak = false;
    public SpeakEmotion emotion;
    private void Awake()
    {
        image = this.GetComponent<Image>();
        image.sprite = source.normal;
        switch (charaPosition)
        {
            case (CharaPosition.left):
                {
                    transform.GetComponent<RectTransform>().DOAnchorPosX(-1290, 0.01f);
                    break;
                }
            case (CharaPosition.right):
                {
                    transform.GetComponent<RectTransform>().DOAnchorPosX(1290, 0.01f);
                    transform.localScale = new Vector3(1, 1, 1);
                    break;
                }
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheakEmotion();
    }
    void CheakEmotion()
    {
        switch (emotion)
        {
            case SpeakEmotion.normal:
                image.sprite = source.normal;
                break;
            case SpeakEmotion.prond:
                image.sprite = source.prond;
                break;
            case SpeakEmotion.angry:
                image.sprite = source.angry;
                break;
            case SpeakEmotion.shock:
                image.sprite = source.shock;
                break;
            case SpeakEmotion.happy:
                image.sprite = source.happy;
                break;
            case SpeakEmotion.hurt:
                image.sprite = source.hurt;
                break;
            default:
                break;
        }
    }
    public void L_CharaEnterScene()
    {
        transform.GetComponent<RectTransform>().DOAnchorPosX(-640, 0.3f);
    }
    public void R_CharaEnterScene()
    {
        transform.GetComponent<RectTransform>().DOAnchorPosX(640, 0.3f);
    }
    public void L_CharaExitScene()
    {
        transform.GetComponent<RectTransform>().DOAnchorPosX(-1290, 0.3f);
    }
    public void R_CharaExitScene()
    {
        transform.GetComponent<RectTransform>().DOAnchorPosX(1290, 0.3f);
    }
}
public enum CharaPosition
{
    left,
    right
}
