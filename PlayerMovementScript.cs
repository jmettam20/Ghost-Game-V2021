using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovementScript : MonoBehaviour
{
   public float maxSpeed; 
   Rigidbody2D myRB; 
   Animator myAnim; 
   bool facingRight; 

  bool grounded = false; 
   float groundCheckRadius = 3f;
   public LayerMask groundLayer; 
   public Transform groundCheck; 
   public float jumpHeight; 

void Start(){
   myRB = GetComponent<Rigidbody2D>();
   myAnim = GetComponent<Animator>();

   facingRight = true; 



}

void Update(){
   melee();

   
   jump();
   walk();


 

   

 }  

 // Update is called once per frame
    
   void FixedUpdate(){
      grounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,groundLayer);

         
        

      
       }

void flip(){

   facingRight=!facingRight;
   Vector3 theScale = transform.localScale; 
   theScale.x *= -1; 
   transform.localScale = theScale; 
}

public void walk(){

   float move = Input.GetAxis("Horizontal");

            myAnim.SetFloat("horizontalSpeed",Mathf.Abs(move)); 

          myRB.velocity = new Vector2(move*maxSpeed,myRB.velocity.y); 

          if(move>0&&!facingRight){

            flip();
         }else if(move<0&&facingRight){

            flip(); 
         }
}    



public void melee(){
  
   if(Input.GetKeyDown("e")){
   myAnim.SetTrigger("Melee"); 
   }
}

public void jump(){
    

    if(grounded && Input.GetKeyDown("w")){
      
      grounded = false; 
    
      myRB.AddForce(new Vector2(0,jumpHeight));
      myAnim.SetTrigger("Jumping"); 
     
   }
}

   


}

 