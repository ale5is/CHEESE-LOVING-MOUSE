using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reinicio : MonoBehaviour
{
    public int numScene;
 
    void Update()
    {
       if (numScene == 0)
        {
            if (Input.GetKey(KeyCode.Return))
            {
                SceneManager.LoadScene(1);
                numScene = 1;
            }
        }
            
       
        if (numScene == 1)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                SceneManager.LoadScene(0);
                numScene = 0;
            }
            if (Input.GetKey("r"))
            {
                SceneManager.LoadScene(1);
            }
        }
        
    }
}
