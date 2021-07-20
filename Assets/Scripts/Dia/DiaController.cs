using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;

public class DiaController : MonoBehaviour , I_DiaToPlay
{
    // Start is called before the first frame update
    public DiaResource diasource;
    //劇本暫存
    public DiaClassList diaClassList = new DiaClassList();
    //指定劇本範圍
    public DiaPlayClassList diaPlayClassList = new DiaPlayClassList();

    bool isStart = false;
    Text diaboxcontent , diaNamecontent;
    private void Awake()
    {

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IntialDia()
    {
        diaboxcontent = GameObject.Find("DiaContent").GetComponent<Text>();
        diaNamecontent = GameObject.Find("DiaNameContent").GetComponent<Text>();
        {
            TextAsset data = Resources.Load<TextAsset>(diasource.sourceName);

            string[] p = data.text.Split(new char[] { '\n' });

            for (int a = 0; a < p.Length - 1; a++)
            {
                string[] row = p[a].Split(new char[] { ',' });

                DiaClass step = new DiaClass();
                step.plotId = row[0];
                step.targetSpeaker = row[1];
                step.Content = row[2];
                step.CharaterEmotion = row[3];
                step.debug = row[4];

                diaClassList.diadataClass.Add(step);
            }
        }
    }
    public void PlayDia()
    {
        if (GameStatusController.gameStatusController.gameStatus != GameStatus.isSpeaking)
        {
            GameStatusController.gameStatusController.gameStatus = GameStatus.isSpeaking;
            IntialDia();
            StartCoroutine(PlayDiaSet());           
        }        
    }
    public void CheakCharaEmotion(int nownum)
    {
        
        GameObject target = GameObject.Find("CharaterSprite");
        for (int i = 0; i < target.transform.childCount; i++)
        {
            if (target.transform.GetChild(i).name == diaClassList.diadataClass[nownum].targetSpeaker)
            {
                switch (diaClassList.diadataClass[nownum].CharaterEmotion)
                {
                    case ("normal"):
                        target.transform.GetChild(i).GetComponent<CharaterDiaAnimation>().emotion = SpeakEmotion.normal;
                        break;
                    case ("prond"):
                        target.transform.GetChild(i).GetComponent<CharaterDiaAnimation>().emotion = SpeakEmotion.prond;
                        break;
                    case ("angry"):
                        target.transform.GetChild(i).GetComponent<CharaterDiaAnimation>().emotion = SpeakEmotion.angry;
                        break;
                    case ("shock"):
                        target.transform.GetChild(i).GetComponent<CharaterDiaAnimation>().emotion = SpeakEmotion.shock;
                        break;
                    case ("happy"):
                        target.transform.GetChild(i).GetComponent<CharaterDiaAnimation>().emotion = SpeakEmotion.happy;
                        break;
                    case ("hurt"):
                        target.transform.GetChild(i).GetComponent<CharaterDiaAnimation>().emotion = SpeakEmotion.hurt;
                        break;
                    default:
                        break;
                }
            }            
           
        }
    }
    //使說話者立繪亮度較高
    public void focusdSpeak(int nownum)
    {
        GameObject target = GameObject.Find("CharaterSprite");
        for (int i = 0; i < target.transform.childCount; i++)
        {
            if (target.transform.GetChild(i).name == diaClassList.diadataClass[nownum].targetSpeaker)
            {
                target.transform.GetChild(i).GetComponent<CharaterDiaAnimation>().image.color = Color.HSVToRGB(0, 0, 1);
            }
            else
            {
                target.transform.GetChild(i).GetComponent<CharaterDiaAnimation>().image.color = Color.HSVToRGB(0, 0, 0.8f);
            }
        }
    }
    //對話播放設定
    public IEnumerator PlayDiaSet()
    {
        //對話框開啟
        DiaboxAnimation.diaboxAnimation.diaboxOpen();
        yield return new WaitUntil(() => { return DiaboxAnimation.diaboxAnimation.playend; });
        //判斷共有幾組對話
        for (int i = 0; i < diaPlayClassList.diaplayClass.Count; i++)
        {
            //List<string> speakchara = new List<string>();
            //List<int> speakcharanum = new List<int>();
            int start = 0, end = 0;
            //尋找對話初始點,結束點
            foreach (DiaClass dia in diaClassList.diadataClass)
            {
                if (dia.plotId == diaPlayClassList.diaplayClass[i].startId)
                {
                    start = diaClassList.diadataClass.IndexOf(dia);
                }
                if (dia.plotId == diaPlayClassList.diaplayClass[i].endId)
                {
                    end = diaClassList.diadataClass.IndexOf(dia);
                }
            }
            //人物立繪
            //for (int a = start; a <= end; a++)
            //{
            //    //建立此次對話會出現之人物清單
            //    if (speakchara.Contains(diaClassList.diadataClass[a].targetSpeaker) == false)
            //    {
            //        speakchara.Add(diaClassList.diadataClass[a].targetSpeaker);
            //        speakcharanum.Add(a);
            //    }      
            //}
            //實作出場人物立繪
            if (isStart == false)
            {
                if (diaPlayClassList.leftChara != null)
                {
                    for (int a = 0; a < diaPlayClassList.leftChara.Count; a++)
                    {
                        CharaterDiaAnimationController.charaterDiaAnimationController.InstantiateCharater(diaPlayClassList.leftChara, CharaPosition.left);
                    }
                }                
                if (diaPlayClassList.rightChara != null)
                {
                    for (int a = 0; a < diaPlayClassList.rightChara.Count; a++)
                    {
                        CharaterDiaAnimationController.charaterDiaAnimationController.InstantiateCharater(diaPlayClassList.rightChara, CharaPosition.right);
                    }
                }                
                //立繪人物進場
                yield return StartCoroutine(CharaterDiaAnimationController.charaterDiaAnimationController.CheakCharaEnterScene());
                isStart = true;
            }
            
            //運用打字機效果撥放文字內容
            for (int a = start; a <= end; a++)
            {
                CheakCharaEmotion(a);
                focusdSpeak(a);
                if (diaClassList.diadataClass[a].targetSpeaker != "我")
                {
                    diaNamecontent.text = diaClassList.diadataClass[a].targetSpeaker;
                    string speaktext = diaClassList.diadataClass[a].Content;
                    //diaboxcontent.DOText(speaktext, 1f);
                    foreach (char letter in speaktext.ToCharArray())
                    {
                        diaboxcontent.text += letter;
                        yield return new WaitForSeconds(0.03f);
                        if (Input.GetMouseButtonDown(0))
                        {
                            break;
                        }
                    }
                    //直到滑鼠點擊開始撥放下一段文字(可能需要重複按兩次滑鼠 要在CHEAK)
                    yield return new WaitUntil(() => { return Input.GetMouseButtonDown(0); });
                }
                else
                {
                    string speaktext = diaClassList.diadataClass[a].Content;
                    //diaboxcontent.DOText(speaktext, 1f);
                    foreach (char letter in speaktext.ToCharArray())
                    {
                        diaboxcontent.text += letter;
                        yield return new WaitForSeconds(0.03f);
                        if (Input.GetMouseButtonDown(0))
                        {
                            break;
                        }
                    }
                    //直到滑鼠點擊開始撥放下一段文字
                    yield return new WaitUntil(() => { return Input.GetMouseButtonDown(0); });
                }
                diaboxcontent.text = "";
                diaNamecontent.text = "";
            }
        }
        diaboxcontent.text = "";
        yield return StartCoroutine(CharaterDiaAnimationController.charaterDiaAnimationController.CheakCharaExitScene());
        isStart = false;
        DiaboxAnimation.diaboxAnimation.diaboxClose();        
    }
}
