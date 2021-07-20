using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CharaterDiaAnimationController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject CharaSprite;
    public static CharaterDiaAnimationController charaterDiaAnimationController;
    public List<CharaEmotionSprite> charaterData = new List<CharaEmotionSprite>();
    private void Awake()
    {
        charaterDiaAnimationController = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InstantiateCharater(List<CharaEmotionSprite> charagroup ,CharaPosition pos)
    {
        foreach (CharaEmotionSprite chara in charagroup)
        {
            CharaSprite.GetComponent<CharaterDiaAnimation>().source = chara;
            CharaSprite.GetComponent<CharaterDiaAnimation>().charaPosition = pos;
            GameObject C = Instantiate(CharaSprite, this.transform);
            C.name = chara.name;
        }
    }
    public IEnumerator CheakCharaEnterScene()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            CharaterDiaAnimation chara = transform.GetChild(i).GetComponent<CharaterDiaAnimation>();
            switch (chara.charaPosition)
            {
                case (CharaPosition.left):
                    {
                        chara.L_CharaEnterScene();
                        break;
                    }
                case (CharaPosition.right):
                    {
                        chara.R_CharaEnterScene();
                        break;
                    }
            }
        }
        yield return new WaitForSeconds(0.3f);
    }
    public IEnumerator CheakCharaExitScene()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            CharaterDiaAnimation chara = transform.GetChild(i).GetComponent<CharaterDiaAnimation>();
            switch (chara.charaPosition)
            {
                case (CharaPosition.left):
                    {
                        chara.L_CharaExitScene();
                        break;
                    }
                case (CharaPosition.right):
                    {
                        chara.R_CharaExitScene();
                        break;
                    }
            }
        }
        yield return new WaitForSeconds(0.3f);
        for (int i = 0; i < transform.childCount; i++)
        {            
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
