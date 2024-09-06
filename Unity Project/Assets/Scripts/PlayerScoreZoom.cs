using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoreZoom : MonoBehaviour
{
    Camera camera; 
    // Start is called before the first frame update
    void Start()
    {
        camera = FindFirstObjectByType<Camera>(); //Hij zoekt de object Camera en slaat het op in camera
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BoundLeft" || collision.tag == "BoundRight") //Als de rechter en linker muur wordt aangeraakt dan gebeurt dit
        {
            StartCoroutine(ZoomDelay()); //De delay method wordt opgeroepen
        }
    }

    IEnumerator ZoomDelay() //Een delay method
    {
        for (float i = 1; i < 11; i += 0.25f) //een for loop voor hoe snel het inzoomt
        {
        yield return new WaitForSeconds(0.005f); //Dit is om het smooth te maken.
            camera.orthographicSize -= 0.25f; //The size van de camera wordt verminderd met 0.25f
        }
        yield return new WaitForSeconds(1f); //Tussen het inzoomen en uitzoomen is er wachttijd van 1 seconde
        for (float i = 1; i < 11; i += 0.25f) //The size van de camera wordt meer zodat het weer uitzoomt
        {
            yield return new WaitForSeconds(0.005f); //Maakt het smoother
            camera.orthographicSize += 0.25f; //The size van de camera wordt weer opgeteld
        }
    }
}
