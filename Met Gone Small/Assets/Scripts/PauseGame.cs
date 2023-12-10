using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public GameObject ReticleUI;
    public GameObject Guns;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
        {
            Time.timeScale = 0f;
            PauseMenuUI.SetActive(true);
            GameIsPaused = true;
            ReticleUI.SetActive(false);
            Guns.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

    public void Resume()
        {
            Time.timeScale = 1f;
            PauseMenuUI.SetActive(false);
            GameIsPaused = false;
            ReticleUI.SetActive(true);
            Guns.SetActive(true);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }   

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene("Menu");

    }

    public void QuitGameMenu()
    {
        Application.Quit();
    }
}
