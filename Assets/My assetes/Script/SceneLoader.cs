using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour{
    public FadeScript fadeScript;
    [SerializeField] private string nextScene;
    public void LoadScene(){
        StartCoroutine(GoToScene());

    }

    IEnumerator GoToScene(){
        fadeScript.FadeOut();
        yield return new WaitForSeconds(fadeScript.fadeDuration);
        
        SceneManager.LoadScene(nextScene);
    }
}
