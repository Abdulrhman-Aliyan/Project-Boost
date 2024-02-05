using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delayTime = 1f;
    // Start is called before the first frame update
    void OnCollisionEnter(Collision other) 
    {
        var objCol = other.gameObject.tag;
        switch(other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log(objCol);
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    private void StartSuccessSequence(){
        GetComponent<Movement>().enabled = false;
        Invoke("NextLevel",delayTime);
    }

    private void StartCrashSequence(){
        // todo add SFX sound upoun crash
        // todo add particales effect upoun crash
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel",delayTime);
    }

    private void NextLevel()
    {
        int currenScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currenScene + 1;

        if(SceneManager.sceneCountInBuildSettings == nextScene){
            nextScene = 0;
        }

        SceneManager.LoadScene(nextScene);
    }

    private void ReloadLevel()
    {
        int currenScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currenScene);
    }
}
