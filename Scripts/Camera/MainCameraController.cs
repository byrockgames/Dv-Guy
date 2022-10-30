using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Camera
{
 public class MainCameraController : MonoBehaviour
 {
  [Header("Camera Settings")]
  [SerializeField] private CameraSettings CameraSettings;

  [Header("Player")]
  [SerializeField] private Transform Target;
  private void LateUpdate() 
  {
    transform.position = Vector3.Lerp(transform.position, Target.position + CameraSettings.Offset, CameraSettings.CameraSpeed * Time.deltaTime);
  }
 }
}