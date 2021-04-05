using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneTransition : MonoBehaviour
{
    public Vector2 position;
    public string scene;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameState.SetLastSceneLocation(SceneManager.GetActiveScene().name);
            GameState.PlayerPosition = position;
            SceneManager.LoadScene(scene);
        }
    }

}
