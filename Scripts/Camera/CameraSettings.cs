using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Camera
{
 [CreateAssetMenu (fileName = "CameraSettings", menuName =("DvGuy/Camera/CameraSettings"))]
 public class CameraSettings : ScriptableObject
 {
    public float CameraSpeed;
    public Vector3 Offset;
 }
}
