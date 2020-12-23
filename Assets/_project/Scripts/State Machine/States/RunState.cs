using UnityEngine;

[CreateAssetMenu(fileName = "Run", menuName = "FSM/States/Run", order = 3)]

public class RunState : State
{
   public override void OnStart()
   {
      _stateType = StateType.Run;
   }
   
   public override void OnEntering()
   {
      fsm.HumanP.Animator.Play("Run");
      if(!fsm.HumanP.PlayerRunning) fsm.HumanP.PlayerRunning = true;
   }
   
   public override void UpdateState()
   {
     
   }
}
