using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter(Collision other) 
    {
        var objCol = other.gameObject.tag;
        switch(other.gameObject.tag)
        {
            case "Fuel":
                Debug.Log(objCol);
                break;
            case "Friendly":
                Debug.Log(objCol);
                break;
            case "Finish":
                Debug.Log(objCol);
                break;
            default:
                SceneManager.LoadScene(0);
                break; 
        }
    }
}
