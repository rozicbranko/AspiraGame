using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject[] mainMenuObjects;
    [SerializeField] private GameObject aboutGame;
    [SerializeField] private GameObject FakeLoader;
    [SerializeField] private GameObject AreYouSure;
    private bool toggleMainMenuObjects = true;
    private bool toggleAboutGame = false;
    private bool toggleQuitGame = false;

    [Header("Initialize")]
    public Slider _progBar;
    public Text _loadingText;

    [Header("Fake Loading")]
    public bool _fakeLoading = false;
    public float _fakeIncrement = 0f;
    public float _fakeTiming = 0f;

    void Start()
    {
        StartCoroutine(LoadLevelWithFakeProgress());
    }

    IEnumerator LoadLevelWithFakeProgress()
    {
        yield return new WaitForSeconds(1);

        while (_progBar.value != 1f)
        {
            _progBar.value += _fakeIncrement;
            yield return new WaitForSeconds(_fakeTiming);
        }

        while (_progBar.value == 1f)
        {
            _loadingText.text = "Press 'F' to Continue";
            if (Input.GetKeyDown(KeyCode.F))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            yield return null;
        }
    }

    public void NewGame()
    {
        ToggleMainMenuObjects(mainMenuObjects);
        FakeLoader.SetActive(true);
    }

    public void About()
    {
        ToggleMainMenuObjects(mainMenuObjects);
        ToggleAboutGame();
    }

    public void Back()
    {
        ToggleMainMenuObjects(mainMenuObjects);
        ToggleAboutGame();
    }

    public void QuitGame()
    {
        ToggleMainMenuObjects(mainMenuObjects);
        ToggleQuitGame();
    }

    public void Yes()
    {
        Application.Quit();
    }

    public void No()
    {
        ToggleQuitGame();
        ToggleMainMenuObjects(mainMenuObjects);

    }

    private void ToggleMainMenuObjects(GameObject[] gameObjects)
    {
        foreach(GameObject gameObject in gameObjects)
        {
            gameObject.SetActive(!toggleMainMenuObjects);
        }

        toggleMainMenuObjects = !toggleMainMenuObjects;
    }

    private void ToggleAboutGame()
    {

        aboutGame.SetActive(!toggleAboutGame);
        toggleAboutGame = !toggleAboutGame;
    }

    private void ToggleQuitGame()
    {

        AreYouSure.SetActive(!toggleQuitGame);
        toggleQuitGame = !toggleQuitGame;
    }
}
