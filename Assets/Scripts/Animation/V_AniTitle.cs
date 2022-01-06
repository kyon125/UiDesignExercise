using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class V_AniTitle : ViewerClass
{
    // Start is called before the first frame update
    public V_AniLogo logoShine;
    public Image Power;
    public List<Image> group = new List<Image>();
    public List<Image> rimgroup = new List<Image>();
    public List<Image> linegroup = new List<Image>();
    public float rotateSpeed , waitTime, rimwaitTime, disapperSpeed,disapperTime, stopTime , shineSpeed ,fillSpeed,allAniTime;
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
    public override void ClientClick()
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
            Power.transform.DORotate(new Vector3(0, 0, 330), 0.3F).SetEase(Ease.OutCubic);
            Power.transform.DOScale(new Vector3(3, 2.75f, 1), 0.3f).SetEase(Ease.OutCubic);
            yield return new WaitForSeconds(0.3f);
            Power.transform.DORotate(new Vector3(0, 0, 90), 0.3F).SetEase(Ease.InCubic);
            Power.transform.DOScale(new Vector3(0, 0, 0), 0.3f).SetEase(Ease.InCubic);
            yield return new WaitForSeconds(0.3f);
        }        
    }
    
    IEnumerator TitleOpenSet()
    {
        yield return ButtonClickSet();
        //foreach (Image im in group)
        //{
        //if (group.IndexOf(im) % 2 == 1)
        //{
        //    im.transform.DORotate(new Vector3(0, 0, 360), rotateSpeed).SetEase(Ease.InBack);
        //    yield return new WaitForSeconds(waitTime);
        //}
        //else
        //{
        //    im.transform.DORotate(new Vector3(0, 0, 0), rotateSpeed).SetEase(Ease.InBack);
        //    yield return new WaitForSeconds(waitTime);
        //}
        //}
        for (int a = 0; a < rimgroup.Count; a++)
        {
            linegroup[a].DOFillAmount(1, fillSpeed).SetEase(Ease.InQuart);
        }
        yield return new WaitForSeconds(waitTime);
        for (int a = 0; a < rimgroup.Count; a++)
        {
            linegroup[a].fillOrigin = (int)Image.OriginVertical.Bottom;
            linegroup[a].DOFillAmount(0, fillSpeed).SetEase(Ease.InQuart);
        }
        yield return new WaitForSeconds(waitTime);
        for (int a = 0; a < rimgroup.Count; a++)
        {
            rimgroup[a].DOFillAmount(1, fillSpeed).SetEase(Ease.InQuart);
        }
        yield return new WaitForSeconds(waitTime);
        for (int a = 0; a < rimgroup.Count; a++)
        {
            rimgroup[a].rectTransform.localScale = new Vector3(-rimgroup[a].rectTransform.localScale.x, rimgroup[a].rectTransform.localScale.y, rimgroup[a].rectTransform.localScale.z);
            rimgroup[a].DOFillAmount(0, fillSpeed).SetEase(Ease.InQuart);
        }
        yield return new WaitForSeconds(rimwaitTime);
        //for (int i = 0; i < 1; i++)
        //{
        //    linegroup[i].DOFillAmount(1, fillSpeed).SetEase(Ease.InQuart);
        //    yield return new WaitForSeconds(waitTime);
        //    linegroup[i].fillOrigin = (int)Image.OriginVertical.Bottom;
        //    linegroup[i].DOFillAmount(0, fillSpeed).SetEase(Ease.InQuart);
        //    yield return new WaitForSeconds(waitTime);
        //    rimgroup[i].DOFillAmount(1, fillSpeed).SetEase(Ease.InQuart);
        //    yield return new WaitForSeconds(waitTime);
        //    rimgroup[i].rectTransform.localScale =new Vector3(-rimgroup[i].rectTransform.localScale.x, rimgroup[i].rectTransform.localScale.y, rimgroup[i].rectTransform.localScale.z);
        //    rimgroup[i].DOFillAmount(0, fillSpeed).SetEase(Ease.InQuart);
        //    yield return new WaitForSeconds(rimwaitTime);
        //}
        yield return new WaitForSeconds(stopTime);
        foreach (Image im in group)
        {
            print((float)(7 - group.IndexOf(im)) / 7);
            im.DOFillAmount(0, (float)(7 -group.IndexOf(im)) / 7 * allAniTime).SetEase(Ease.InCubic);
            yield return new WaitForSeconds((float)1/7 *allAniTime);
        }
        //foreach (Image im in group)
        //{
        //    im.transform.gameObject.SetActive(false);
        //}        
        yield return new WaitForSeconds(0.333f);
        logoShine.playend = true;
    }
}
