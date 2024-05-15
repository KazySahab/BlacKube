using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class responsivebg : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    void Start()
    {
       
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer is not assigned!");
            return;
        }

     
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        float screenAspectRatio = screenWidth / screenHeight;

        int spriteWidth = Mathf.RoundToInt(spriteRenderer.sprite.textureRect.width);
        int spriteHeight = Mathf.RoundToInt(spriteRenderer.sprite.textureRect.height);
        float spriteAspectRatio = spriteWidth / spriteHeight;


        // Calculate the scale to fit the screen while maintaining the aspect ratio
        float scalex = 1f;
        float scaley = 1f;

        // Fit based on height
        
            scaley = screenHeight / spriteHeight;
        
       

        // Fit based on width
        
            scalex = screenWidth / spriteWidth;
        
       
        

        // Set the scale of the sprite
        if(screenWidth>1900)
        {
            transform.localScale = new Vector3(scalex, scaley, 1f);

        }



    }
}
