using UnityEngine;

[CreateAssetMenu(fileName = "IdleState", menuName = "FSM/States/Idle", order = 1)]

public class IdleState : State
{
   public override void OnStart()
   {
      _stateType = StateType.Idle;
   }
   
   public override void OnEntering()
   {
      fsm.HumanP.Animator.Play("Idle");
      if(fsm.HumanP.PlayerRunning) fsm.HumanP.PlayerRunning = false;
   }
   
   public override void UpdateState()
   {
     
   }
}
