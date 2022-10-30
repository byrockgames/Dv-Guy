using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
 public class PlayerController : MonoBehaviour
 {
   [Header("PlayerSettings")]
   [SerializeField] private PlayerSettings PlayerSettings;
   Rigidbody rigid;    
   void Start()
   {
     rigid = GetComponent<Rigidbody>();
   }

   void Update()
   {
        
   }

   private void FixedUpdate()
   {
     float newX = 0;
     float TouchX = 0;

     if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
      {          
         TouchX = Input.GetTouch(0).deltaPosition.x / Screen.width;
      }   
      else if(Input.GetMouseButton(0))     
      {
        TouchX = Input.GetAxis("Mouse X");
      }

      newX = transform.position.x + PlayerSettings.xSpeed * TouchX * Time.deltaTime;
      newX = Mathf.Clamp(newX, -PlayerSettings.LimitX, PlayerSettings.LimitX);

      Vector3 NewPosition = new Vector3(newX, transform.position.y, transform.position.z);
      transform.position = NewPosition;
      
      transform.Translate(0, 0, PlayerSettings.Speed * Time.deltaTime);
   } 
     

 }
}