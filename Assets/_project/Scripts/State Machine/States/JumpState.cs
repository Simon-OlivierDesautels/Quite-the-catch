using UnityEngine;

[CreateAssetMenu(fileName = "JumpState", menuName = "FSM/States/Jump", order = 4)]

public class JumpState : State
{
   public override void OnStart()
   {
      _stateType = StateType.Jump;
   }
   
   public override void OnEntering()
   {
      fsm.HumanP.Animator.Play("Jump");
      if(!fsm.HumanP.PlayerRunning) fsm.HumanP.PlayerRunning = true;
   }
   
   public override void UpdateState()
   {
      fsm.HumanP.AgainstWind();
   }
}
