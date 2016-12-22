using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerAnimations : NetworkBehaviour
{

    private Animator _anim;
    private PolyNavAgent _agent;
    private Vector2 _lastDir;
    public int animDirection;

    public void Awake()
    {
        _anim = GetComponent<Animator>();
        _agent = GetComponent<PolyNavAgent>();
    }

    [Command]
    private void CmdUpdateAnimations(int direction)
    {
        RpcUpdateAnimations(direction);
    }
    [ClientRpc]
    public void RpcUpdateAnimations(int direction)
    {
        _anim.SetInteger("Direction", direction);
    }

    private void Update() {
        if (!isLocalPlayer) return;
        
        var dir = _agent.movingDirection;
        var x = (int)Mathf.Round(dir.x);
        var y = (int)Mathf.Round(dir.y);

        //y = Mathf.Abs(y) == Mathf.Abs(x) ? 0 : y;

        dir = new Vector2(x,y);

        if (dir == _lastDir) return;

        animDirection = 0;
        if (dir == Vector2.zero) animDirection = 0;
        else if ((int)dir.x == 1) animDirection = 3;
        else if ((int)dir.x == -1) animDirection = 4;
        else if ((int)dir.y == 1) animDirection = 1;
        else if ((int)dir.y == -1) animDirection = 2;
        _lastDir = dir;
        CmdUpdateAnimations(animDirection);
    }

    //public void OnJustDied() {
    //    _anim.SetBool("Death", true);
    //}

    //public void OnRespawned() {
    //    _anim.SetBool("Death", false);
    //}
}
