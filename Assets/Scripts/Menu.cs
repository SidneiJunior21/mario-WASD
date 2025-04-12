using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    void Start(){
        Cursor.visible = true;
    }

    public void LoadScenes(string cena){
        SceneManager.LoadScene(cena);
    }

    public void Sair(){
        Application.Quit();
    }
}