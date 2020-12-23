using UnityEngine;

[CreateAssetMenu(fileName = "Land", menuName = "FSM/States/Land", order = 5)]

public class LandState : State
{
   public override void OnStart()
   {
      _stateType = StateType.Land;
   }
   
   public override void OnEntering()
   {
      fsm.HumanP.Animator.Play("Land");
      if(!fsm.HumanP.PlayerRunning) fsm.HumanP.PlayerRunning = true;
      if(!fsm.HumanP.PlayerFalling) fsm.HumanP.PlayerFalling = true;
   }
   
   public override void UpdateState()
   {
      Debug.Log("dda");
      fsm.HumanP.AgainstWind();
   }
}
