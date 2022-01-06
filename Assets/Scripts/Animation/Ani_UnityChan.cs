using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ani_UnityChan : MonoBehaviour, Ani_PlayerAction
{
    CharaterStatus charater;
    // Start is called before the first frame update
    void Start()
    {
        charater = CharaterStatus.charater;
        intial();
    }

    // Update is called once per frame
    void Update()
    {
        judgement();
    }
    public void intial()
    {
        charater.playerAni.SetBool("isIdel", false);
        charater.playerAni.SetBool("isWalk", false);
    }
    public void judgement()
    {
        switch (charater.playerStatus)
        {
            case PlayerStatus.isIdel:
                ani_CharaterIdel();
                break;
            case PlayerStatus.isWalk:
                ani_CharaterWalk();
                break;
            case PlayerStatus.isJump:
                ani_CharaterJump();
                break;
            default:
                break;
        }
    }
    public void ani_CharaterIdel()
    {
        charater.playerAni.SetBool("isWalk", false);
        //charater.playerAni.SetBool("isJump", false);
        charater.playerAni.SetBool("isIdel", true);
    }
    public void ani_CharaterWalk()
    {
        charater.playerAni.SetBool("isIdel", false);
        charater.playerAni.SetBool("isWalk", true);
    }
    public void ani_CharaterJump()
    {
        charater.playerAni.SetBool("isJump", true);
    }
}
