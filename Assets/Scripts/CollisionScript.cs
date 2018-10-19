using System;
using UnityEngine;

namespace Rush.Physics
{
    using Rush.Box;
    /// <summary>
    /// RAKOTOASIMBOLA Manasseh
    /// </summary>
    
    public class CollisionScript : MonoBehaviour
    {
        [SerializeField] 
        private Transform spaceShip;

        [SerializeField] 
        private Transform spaceWall;
        
        private Box boxCollider;
        private Box playerBoxCol;
        private float normalX,normalY;
        private bool thereIsCollision;

        public delegate void OnEvent(bool isCollision, float nX,float nY);     // Delegate 
        public static OnEvent SendIsCollision;
 
        private void Start()
        {
            
            normalX = normalY = 0f;
            boxCollider= new Box();
            playerBoxCol= new Box();
        }
    
        private void Update()
        {
            BoxColliderInfo();
            //Debug.Log(VCollision(playerBoxCol.x,playerBoxCol.y,boxCollider));
            
            thereIsCollision=(V2Collision(playerBoxCol, boxCollider));
            if (SendIsCollision != null)
            {
                SendIsCollision(thereIsCollision,normalX,normalY);
            }
        }  
    
        /// <summary>
        /// Return true if there is Collision 
        /// </summary>
        /// <param name="Cx"></param>
        /// <param name="Cy"></param>
        /// <param name="box"></param>
        /// <returns></returns>
        private bool VCollision(float Cx, float Cy, Box box)
        {   
            if (Cx >= box.x && Cx < box.x + box.w && Cy >= box.y && Cy < box.y + box.h)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    
        private bool V2Collision(Box box1, Box box2)
        {      
            if (box2.x >= box1.x + box1.w)
            {
                normalX = 1.0f;
                normalY = 0f;
            }
    
            if (box2.x + box2.w <= box1.x)
            {
                normalX = -1.0f;
                normalY = 0f;
            }
            
            if (box2.y >= box1.y + box1.h)
            {
                normalY = -1.0f;
                normalX = 0f;
            }
            
            if (box2.y + box2.h <= box1.y)
            {
                normalY = 1.0f;
                normalX = 0f;
            }
            
    
            if(   (box2.x >= box1.x + box1.w)     // en dehors de la limite droite
               || (box2.x + box2.w <= box1.x)     // -||- gauche
               || (box2.y >= box1.y + box1.h)     // -||- en bas
               || (box2.y + box2.h <= box1.y))    // -||- en haut
                return false; 
            else
                return true; 
            
            
        }
    
        private void BoxColliderInfo()
        {
            //Box 1
            playerBoxCol.w = spaceShip.localScale.x;
            playerBoxCol.h = spaceShip.localScale.y;
            playerBoxCol.x = spaceShip.position.x - playerBoxCol.w / 2;
            playerBoxCol.y = spaceShip.position.y - playerBoxCol.h / 2;
            playerBoxCol.vX = 1.0f;
            playerBoxCol.vY = 1.0f;
            //Box 2
            boxCollider.w = spaceWall.localScale.x;
            boxCollider.h = spaceWall.localScale.y;
            boxCollider.x = spaceWall.position.x - boxCollider.w / 2;
            boxCollider.y = spaceWall.position.y - boxCollider.h / 2;
            //Debug.Log("w:"+ boxCollider.w +" h:"+ boxCollider.h);
            //Debug.Log("x:"+ boxCollider.x +" y:"+ boxCollider.y);
        }

        public bool ThereIsCollision()
        {
            return thereIsCollision;
        }
    }
}

