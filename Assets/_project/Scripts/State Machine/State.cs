using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    public virtual IEnumerator Start()
    {
        yield break;
    }

    public virtual IEnumerator Catching()
    {
        yield break;
    }

    public virtual IEnumerator Jumping()
    {
        yield break;
    }
}