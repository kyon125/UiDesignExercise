using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newDiaResource" , menuName = "Dia/Resource")]

public class DiaResource : ScriptableObject
{
    public string sourceName;
}
public interface I_DiaToPlay
{
    public void IntialDia();
    public void PlayDia();
    public IEnumerator PlayDiaSet();
}
[System.Serializable]
public class DiaClassList
{
    public List<DiaClass> diadataClass;
}
[System.Serializable]
public class DiaPlayClassList
{
    public List<CharaEmotionSprite> leftChara;
    public List<CharaEmotionSprite> rightChara;
    public List<DiaPlayClass> diaplayClass;
}
[System.Serializable]
public class DiaClass
{    
    public string plotId;
    public string targetSpeaker;
    public string Content;
    public string CharaterEmotion;
    public string debug;
}
[System.Serializable]
public class DiaPlayClass
{    
    public string startId, endId;
    public bool addNewCharater;
    public bool removeCharater;
}
public enum SpeakEmotion
{ 
    normal,
    prond, 
    angry, 
    shock,
    happy, 
    hurt
}
