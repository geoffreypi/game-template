using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void VoidDelegate();
    public delegate void BoolDelegate(bool value);
    public delegate void StringDelegate(string value);
    
    public static event VoidDelegate SpeedBoost;
        public static void OnSpeedBoost()
        {
            if (SpeedBoost != null)
                SpeedBoost();
        }
}
