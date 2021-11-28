using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Liminal.SDK.Core;

public class EndExperience : MonoBehaviour
{
    public void OnTriggerEnter(Collider _other)
    {
        if (_other.gameObject)
        {
            ExperienceApp.End();
        }
    }
}
