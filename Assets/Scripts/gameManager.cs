using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public List<GameObject> PersistableObjects;
    public static GameObject gmInstance;

    [Header("Story Stats")]
    public int wealth;
    public int supply;
    public int reputation;

    public string nextScene;

    // Start is called before the first frame update
    void Awake()
    {
        //Store the first instance of the GM and erase others when changing scenes.
        if (gmInstance == null)
        {
            gmInstance = gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);

        //DontDestroyOnLoad(gameObject);
        if (PersistableObjects.Count > 0)
        {
            for (int i = 0; i < PersistableObjects.Count; i++)
            {
                if (PersistableObjects[i] != null) DontDestroyOnLoad(PersistableObjects[i]);
            }
        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(nextScene);
    }

    //Call on this code to add an object to the PersistableObjects.
    public void AddToPersistableObjects(GameObject objectToAdd)
    {
        PersistableObjects.Add(objectToAdd);
    }
}
