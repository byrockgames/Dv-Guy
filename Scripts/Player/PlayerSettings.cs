using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
 [CreateAssetMenu (fileName = "PlayerSettings" , menuName = ("DvGuy/Player/PlayerSettings"))]
 public class PlayerSettings : ScriptableObject
 {
    public int Speed;
    public float LimitX;
    public float xSpeed;
 }
}

