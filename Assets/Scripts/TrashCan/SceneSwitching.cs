using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSwitching : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void ToBattle() 
    {
        Debug.Log("Tobattle");
        SceneManager.LoadScene(2);
        //SceneManager.LoadScene(3);

    }
    public void Character()
    {
        Debug.Log("Character");
        SceneManager.LoadScene(1);

    }
    public void Retry()
    {

        SceneManager.LoadScene(2);

    }
    public void Quit()
    {

        SceneManager.LoadScene(0);

    }
}
