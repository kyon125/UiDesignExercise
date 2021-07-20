using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Ani_Title : MonoBehaviour
{
    // Start is called before the first frame update
    public Ani_Logo logoShine;
    public Image Power;
    public List<Image> group = new List<Image>();
    public float rotateSpeed ,waitTime  , disapperSpeed,disapperTime, stopTime , shineSpeed;
    bool isshine = true;
    bool isclick = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ButtonShine();
    }
    public void TitleOpen()
    {
        StartCoroutine(TitleOpenSet());
    }
    public void ButtonShine()
    {
        StartCoroutine(ButtonShineSet());
    }
    public IEnumerator ButtonShineSet()
    {
        if (isshine && isclick == false)
        {
            isshine = false;
            Power.DOColor(new Color(0.5f, 0.5f, 0.5f), shineSpeed).SetEase(Ease.InCubic);
            yield return new WaitForSeconds(shineSpeed);
            Power.DOColor(new Color(1, 1, 1), shineSpeed).SetEase(Ease.OutCubic);
            yield return new WaitForSeconds(shineSpeed);
            isshine = true;
            
        }
    }
    public IEnumerator ButtonClickSet()
    {
        if (isclick == false)
        {
            isclick = true;
            Power.transform.DOScale(new Vector3(3, 2.75f, 1), 0.3f).SetEase(Ease.OutCubic);
            yield return new WaitForSeconds(0.3f);
            Power.transform.DOScale(new Vector3(0, 0, 0), 0.3f).SetEase(Ease.InCubic);
            yield return new WaitForSeconds(0.3f);
        }        
    }
    
    IEnumerator TitleOpenSet()
    {
        yield return ButtonClickSet();
        foreach (Image im in group)
        {
            if (group.IndexOf(im) % 2 == 1)
            {
                im.transform.DORotate(new Vector3(0, 0, 360), rotateSpeed);
                yield return new WaitForSeconds(waitTime);
            }
            else
            {
                im.transform.DORotate(new Vector3(0, 0, 0), rotateSpeed);
                yield return new WaitForSeconds(waitTime);
            }            
        }
        yield return new WaitForSeconds(stopTime);
        foreach (Image im in group)
        {
            im.DOFillAmount(0, disapperSpeed);
            yield return new WaitForSeconds(disapperTime);            

        }
        foreach (Image im in group)
        {
            im.transform.gameObject.SetActive(false);

        }
        logoShine.playend = true;
    }
}
