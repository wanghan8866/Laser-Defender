using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
   [SerializeField] float sceneDelay = 2f;
   public void LoadGame(){
      // SceneManager.LoadScene(1);
      ScoreKeeper.GetInstance().ResetScore();
      StartCoroutine(WaitAndLoad(1, sceneDelay));
   }

   public void LoadMenu(){
    
      // SceneManager.LoadScene(0);
      StartCoroutine(WaitAndLoad(0, sceneDelay));

   }

   public void LoadGameOver(){
      StartCoroutine(WaitAndLoad(2, sceneDelay));
   }

   public void QuitGame(){
      Debug.Log("Quitting Game ....");
      Application.Quit();
   }

   IEnumerator WaitAndLoad(int sceneIndex, float delay){
      yield return new WaitForSeconds(delay);
      SceneManager.LoadScene(sceneIndex);
   }
}
