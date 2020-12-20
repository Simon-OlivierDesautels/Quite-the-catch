using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : State
{
   public override IEnumerator Start()
   {
      Debug.Log("Jump");
      yield break;
   }
}
