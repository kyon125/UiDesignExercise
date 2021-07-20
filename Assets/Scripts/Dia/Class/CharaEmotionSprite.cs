using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="emotionsource" , menuName = "Dia/Charater")]
public class CharaEmotionSprite: ScriptableObject
{
    public new string name;
    public SpeakEmotion emotionStatus;
    [Header("人物表情")]
    public Sprite normal, prond, angry, shock, happy, hurt;
}
