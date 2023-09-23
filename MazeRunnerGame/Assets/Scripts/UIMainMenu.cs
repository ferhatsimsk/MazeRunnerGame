using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }

    public void RestartGame()
    {
        // Aktif sahnenin build index'ini al
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Aktif sahneyi tekrar y�kle
        SceneManager.LoadScene(sceneIndex);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    //public void LoadNextLevel()
    //{
    //    int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
    //    int nextLevelIndex = currentLevelIndex + 1;

    //    if (nextLevelIndex < SceneManager.sceneCountInBuildSettings)
    //    {
    //        SceneManager.LoadScene(nextLevelIndex);
    //        StartNextLevel();
    //    }
    //    else
    //    {
    //        Debug.Log("Son seviye. Oyun tamamland�!");
    //    }
    //}

    //private void StartNextLevel()
    //{
    //    // Burada, yeni sahnede yap�lmas� gereken ba�lang�� i�lemlerini ger�ekle�tirebilirsiniz.
    //    // �rne�in, oyuncunun can�n� s�f�rlayabilir, skoru s�f�rlayabilir veya di�er ayarlamalar� yapabilirsiniz.
    //}
}
