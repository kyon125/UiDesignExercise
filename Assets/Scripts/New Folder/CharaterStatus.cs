using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaterStatus : MonoBehaviour 
{
    static public CharaterStatus charater;
    public PlayerStatus playerStatus;
    public PlayerPosStatus playerPosStatus;
    public Animator playerAni;
    public Ani_PlayerAction ani_playeraction;
    public float groundLayerPosY ,groundLayerDistance;
    // Start is called before the first frame update
    private void Awake()
    {
        charater = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheakPlayerPosStatus();
    }
    void CheakPlayerPosStatus()
    {
        LayerMask mask = LayerMask.GetMask("Ground");
        RaycastHit2D ground = Physics2D.Raycast(new Vector2(transform.position.x , transform.position.y+groundLayerPosY), Vector2.down, groundLayerDistance, mask);
        playerPosStatus = ground ? PlayerPosStatus.isGrounded : PlayerPosStatus.onAir;
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y + groundLayerPosY), Vector2.down * groundLayerDistance, ground ? Color.red:Color.green);
    }
}
public enum PlayerPosStatus
{
    isGrounded,
    onAir,
}
public enum PlayerStatus
{
    isIdel,
    isWalk,
    isJump
}
