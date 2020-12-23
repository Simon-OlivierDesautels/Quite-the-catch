using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "TommysConditions", menuName = "FSM/Conditions/Tommy")]
public class TommysConditions : Conditions
{
    
    [SerializeField] private float runSpeed;
    private Human _parentClass;
    
    public override void OnStart()
    {
        fsm.DefineState(StateType.Idle);
        _parentClass = fsm.HumanP;
    }

    public override void UpdateConditions()
    {
        switch (fsm.HumanP.PlayerGrounded)
        {
            case true:
                HorizontalMovement();
                break;
            
            case false:
                VerticalMovement();
                break;
        }
    }

    private void HorizontalMovement()
    {
        float playerAxis = Mathf.Abs(fsm.HumanP.PlayerAxis);

        switch (fsm.HumanP.PlayerCatching)
        {
            case false:
                if(playerAxis == 0) fsm.DefineState(StateType.Idle);
                if(playerAxis > 0 && playerAxis < runSpeed) fsm.DefineState(StateType.Walk);
                if(playerAxis > runSpeed) fsm.DefineState(StateType.Run);
                
                SwitchDirection();
                break;
            
            case true:
                fsm.DefineState(StateType.Catch);
                break;
        }
    
    }
    
    private void VerticalMovement()
    {
        if(fsm.HumanP.Rigidbody2D.velocity.y > 0) fsm.DefineState(StateType.Jump);
        if(fsm.HumanP.Rigidbody2D.velocity.y < 0) fsm.DefineState(StateType.Land);
        
    }
    
    private void SwitchDirection()
    {
        FacingDirection();
        float playerWidth = fsm.HumanP.PlayerWidth;
        Vector3 localScale = fsm.HumanP.transform.localScale;

        switch (fsm.HumanP.CurrentDirection)
        {
            case Human.PlayerFacing.Left:
                fsm.HumanP.transform.localScale = new Vector3(-playerWidth, fsm.HumanP.transform.localScale.y, localScale.z);
                break;
            case Human.PlayerFacing.Right:
                fsm.HumanP.transform.localScale = new Vector3(playerWidth, fsm.HumanP.transform.localScale.y, localScale.z);
                break;
        }
    }
    
    private void FacingDirection()
    {
        if (fsm.HumanP.PlayerAxis > 0) fsm.HumanP.CurrentDirection = Human.PlayerFacing.Right;
        else if (fsm.HumanP.PlayerAxis < 0) fsm.HumanP.CurrentDirection = Human.PlayerFacing.Left;
    }
}
