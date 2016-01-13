// Procedural spite creation + assign animation from resourse folder.
//
// Sprite.Create(texture, rect texture region in pixels (x, y, width, height), pivot position in 0..1 range (x,y))
// RuntimeAnimationController is used to add/swap current animation controller of any object.

using UnityEngine;

public class BuildSprite : MonoBehaviour
{
    Texture2D myTexture;
    Sprite mySprite;

    RuntimeAnimatorController myRTimeAnimator;

    void Awake()
    {
        // create empty(transform only) game object in scene with default position (0,0,0)
        GameObject myObj = new GameObject();
        myObj.transform.position = new Vector3(0, 3, 0);
        // add sprite renderer component
        myObj.AddComponent<SpriteRenderer>();

        // create texture from resource file
        myTexture = Resources.Load<Texture2D>("ProceduralSprite/100_px") as Texture2D;

        // A) store sprite > store component > assign spite to component property
        mySprite = Sprite.Create(myTexture, new Rect(25,25,75,75), new Vector2(0f, 0f));
        SpriteRenderer myObjComponent = myObj.GetComponent<SpriteRenderer>();
        myObjComponent.sprite = mySprite;

        // B) direct assign
        // myObj.GetComponent<SpriteRenderer>().sprite = Sprite.Create(myTexture, new Rect(0, 0, myTexture.width, myTexture.height), new Vector2(0.5f, 0f));

        // 1)----
        // load previously created animator controller as runtimeAnimationConroller
        myRTimeAnimator = Resources.Load<RuntimeAnimatorController>("ProceduralSprite/Cube") as RuntimeAnimatorController;
        // add animator component to GO and assign animator controller
        myObj.AddComponent<Animator>();
        myObj.GetComponent<Animator>().runtimeAnimatorController = myRTimeAnimator;

        // 2)----
        // alternative way (direct assing)
        // myObj.AddComponent<Animator>();
        // myObj.GetComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("ProceduralSprite/Cube") as RuntimeAnimatorController;

    }
}
