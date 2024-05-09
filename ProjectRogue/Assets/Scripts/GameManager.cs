using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance {  get { return instance; } }

    [SerializeField] private GameObject player;
    public GameObject Player { get { return player; } }
    [SerializeField] private UIManager uiManager;
    public UIManager UIManager { get { return uiManager; } }
    
    [SerializeField] private List<GameObject> goToCreateOnSceneLoad = new List<GameObject>();
    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        Initialize();
    }
    private void Initialize()
    {
        if(player == null)
        {
            player = GameObject.Find("Player");
        }
        foreach(var item in goToCreateOnSceneLoad)
        {
            var instantiatedItem = Instantiate(item);
            if(item.GetComponent<UIManager>())
            {
                uiManager = instantiatedItem.GetComponent<UIManager>();
            } else if(item.GetComponent<PlayerStateMachine>())
            {
                player = instantiatedItem;
            }
        }
    }
    public void GameOver()
    {
        Time.timeScale = 0;
    }
}
