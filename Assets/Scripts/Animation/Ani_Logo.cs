using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class Ani_Logo : MonoBehaviour
{
    // Start is called before the first frame update
    public Image im;
    public float rotateSpeed , transSpeed;
    public bool playend =false;
    float nowrotate;
    void Start()
    {
        nowrotate = transform.rotation.z;
    }

    // Update is called once per frame
    void Update()
    {
        nowrotate += rotateSpeed;
        StartCoroutine(transSize());
    }
    private void FixedUpdate()
    {
        //transform.rotation = Quaternion.Euler(0, 0, nowrotate);
    }
    IEnumerator transSize()
    {
        if (playend)
        {
            playend = false;
            im.DOFade(1 ,transSpeed).SetEase(Ease.OutCubic);
            yield return new WaitForSeconds(transSpeed);
            im.DOFade(0, transSpeed).SetEase(Ease.InCubic);
            yield return new WaitForSeconds(transSpeed);
            playend = true;
        }        
    }
}
