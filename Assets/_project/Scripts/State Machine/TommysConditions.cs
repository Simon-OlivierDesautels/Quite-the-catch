using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TommysConditions", menuName = "FSM/conditions/Tommy")]
public class TommysConditions : Conditions
{

    [SerializeField] private Human parentClass;
    public override void OnStart()
    {
        fsm.DefineState(StateType.Jump);
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
      
    }
    
    private void VerticalMovement()
    {
      
    }
}
