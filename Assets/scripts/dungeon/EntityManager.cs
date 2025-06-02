
using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class EntityManager : MonoBehaviour
{
    public static int entities;

    public TMP_Text text;

    private bool won=false;

    private void Start()
    {
        entities = 5;
    }

    private void Update()
    {
      if(entities == 0)
        {
            StartCoroutine(ShowHPTemporarily(3f));
            won = true;
        }   

      if(Input.GetKeyUp(KeyCode.O) && won==true)
        {
            SceneManager.LoadScene("Menu");
        }
        if (Input.GetKeyDown(KeyCode.Escape))   
           {

            SceneManager.LoadScene("Menu");
        }

    }

    IEnumerator ShowHPTemporarily(float duration)
    {
        text.gameObject.SetActive(true); 
        yield return new WaitForSeconds(duration); 
    
    }

}
