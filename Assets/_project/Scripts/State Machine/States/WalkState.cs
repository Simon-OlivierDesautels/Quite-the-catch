using UnityEngine;

[CreateAssetMenu(fileName = "Walk", menuName = "FSM/States/Walk", order = 2)]

public class WalkState : State
{
   public override void OnStart()
   {
      _stateType = StateType.Walk;
   }
   
   public override void OnEntering()
   {
      fsm.HumanP.Animator.Play("Walk");
      if(fsm.HumanP.PlayerRunning) fsm.HumanP.PlayerRunning = false;
   }
   
   public override void UpdateState()
   {
     
   }
}
