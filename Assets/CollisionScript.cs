using System;
using UnityEngine;
using Rush.Box;

public class CollisionScript : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private Transform spaceShip;

    [SerializeField] 
    private Transform staticBox;
    
    private Box spaceCollider;
    private Box staticBoxCollider;
    private float spaceWeight;
    private float spaceHeight;
    
    private void start()
    {
        spaceCollider = new Box();
        staticBoxCollider = new Box();
        
        //position top left of the spaceBox (player)
        spaceCollider.x =spaceShip.position.x-spaceShip.localScale.x/2;
        spaceCollider.x =spaceShip.position.x+spaceShip.localScale.y/2;
        
        // position top left of the staticBox (obstacles)
        staticBoxCollider.x =staticBox.position.x-staticBox.localScale.x/2;
        staticBoxCollider.x =staticBox.position.x+staticBox.localScale.y/2;
        
        // position de la normal
        
    }

    private void Update()
    {
        float normalX, normalY;
        float collisionTime =SweptAABB(spaceCollider, staticBoxCollider, 0f, 0f);
        spaceCollider.x += spaceCollider.vX * collisionTime;
        spaceCollider.y += spaceCollider.vY * collisionTime;
        float remainingTime = 1.0f - collisionTime;
    }

    float SweptAABB(Box b1, Box b2, float normalX, float normalY)
    {
        float xInvEntry, yInvEntry;
        float xInvExit, yInvExit;
        
        float xEntry=1f, yEntry=1f;
        float xExit=1f, yExit=1f;
        
        //trouver la distance entre les objtets 
        if (b1.vX > 0.0f)
        {
            xInvEntry = b2.x - (b1.x + b1.w);
            xInvExit = (b2.x + b2.w) - b1.x;
        }
        else
        {
            xInvEntry = (b2.x + b2.w) - b1.x;
            xInvExit = b2.x - (b1.x + b1.w);
        }
        if (b1.vY > 0.0f)
        {
            yInvEntry = b2.y - (b1.y + b1.h);
            yInvExit = (b2.y + b2.h) - b1.y;
        }
        else
        {
            yInvEntry = (b2.y + b2.h) - b1.y;
            yInvExit = b2.y - (b1.y + b1.h);
        }
        
        //trouver le temps de collision 
        
        if (b1.vX != 0.0f)
        {
            xEntry = xInvEntry / b1.vX;
            xExit = xInvExit / b1.vX;
        }
        if (b1.vY != 0.0f)
        {
            yEntry = yInvEntry / b1.vY;
            yExit = yInvExit / b1.vY;
        }
        
        float entryTime = Math.Max(xEntry, yEntry);
        float exitTime = Math.Max(xExit, yExit);
        
        if (entryTime > exitTime || xEntry < 0.0f && yEntry < 0.0f || xEntry > 1.0f || yEntry > 1.0f)
        {
            normalX = 0.0f;
            normalY = 0.0f;
            return 1.0f;
        }
        else 
            // if there was a collision
        {
            // calculate normal of collided surface
            if (xEntry > yEntry)
            {
                if (xInvEntry < 0.0f)
                {
                    normalX = 1.0f;
                    normalY = 0.0f;
                }
                else
                {
                    normalX = -1.0f;
                    normalY = 0.0f;
                }
            }
            else
            {
                if (yInvEntry < 0.0f)
                {
                    normalX = 0.0f;
                    normalY = 1.0f;
                }
                else
                {
                    normalX = 0.0f;
                    normalY = -1.0f;
                }
            }
// return the time of collision
            return entryTime;
        }
    }
    
    
}
