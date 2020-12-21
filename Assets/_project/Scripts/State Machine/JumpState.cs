using UnityEngine;

[CreateAssetMenu(fileName = "JumpState", menuName = "FSM/States/Jump", order = 4)]

public class JumpState : State
{
   public override void OnStart()
   {
      _stateType = StateType.Jump;
      fsm.HumanP.Animator.Play("Catch");
   }
   
   public override void OnEntering()
   {
      
   }
   
   public override void UpdateState()
   {
     
   }
}
