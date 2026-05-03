using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_sc : MonoBehaviour
{

    bool isGameOver = false;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && isGameOver)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
    
    public void GameOver()
    {
        isGameOver = true;

    }
}
