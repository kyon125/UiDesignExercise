using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Ani_PlayerAction
{
    // Start is called before the first frame update 
    public void intial();
    public void judgement();

    public void ani_CharaterIdel();

    public void ani_CharaterWalk();
    public void ani_CharaterJump();
}
