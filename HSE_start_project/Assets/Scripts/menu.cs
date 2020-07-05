using UnityEngine;
using UnityEngine.SceneManagement;
public class menu : MonoBehaviour
{
    public GUIStyle mystyle;
    string score;
    void Start()
    {
        score = Memory.Get_Score().ToString();
    }

    void OnGUI()
    {
        //GUI.Label(new Rect(Screen.width * 0.15f, Screen.height * 0.8f, Screen.width * 0.7f, Screen.height * 0.1f), "MAX SCORE:" + score, mystyle);
        if (GUI.Button(new Rect(Screen.width * 0.15f, Screen.height * 0.25f, Screen.width * 0.7f, Screen.height * 0.1f), "START", mystyle))
        {
            SceneManager.LoadScene(1);
        }
        if (GUI.Button(new Rect(Screen.width * 0.15f, Screen.height * 0.4f, Screen.width * 0.7f, Screen.height * 0.1f), "RULES", mystyle))
        {
            SceneManager.LoadScene(4);
        }
        if (GUI.Button(new Rect(Screen.width * 0.15f, Screen.height * 0.6f, Screen.width * 0.7f, Screen.height * 0.1f), "EXIT", mystyle))
        {
            Application.Quit();
        }
    }
}
