using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "JumpState", menuName = "FSM/States", order = 4)]

public class JumpState : State
{
   private void Start()
   {
      _stateType = StateType.Jump;
   }
   public override void OnEntering()
   {
      
   }
   
   public override void UpdateState()
   {
      Debug.Log("Jump");
   }
}
