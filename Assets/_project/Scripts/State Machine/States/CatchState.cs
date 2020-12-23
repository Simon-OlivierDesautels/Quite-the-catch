using UnityEngine;

[CreateAssetMenu(fileName = "Catch", menuName = "FSM/States/Catch", order = 6)]

public class CatchState : State
{
   public override void OnStart()
   {
      _stateType = StateType.Catch;
   }
   
   public override void OnEntering()
   {
      fsm.HumanP.Animator.Play("Catch");
      fsm.LockState("LockCatch");
   }
   
   public override void UpdateState()
   {
      fsm.HumanP.AgainstWind();
   }
}
