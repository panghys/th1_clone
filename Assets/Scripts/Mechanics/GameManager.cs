using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Canvas canva;
    public float pts;
    public bool wasPlayerHit = false;
    [SerializeField] public int hp = 3;
    private Transform ptsText;
    private Transform hpText;
    void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        
    }
    void Start()
    {
        ptsText = canva.transform.Find("Points");
        hpText = canva.transform.Find("HP");
        hpText.gameObject.GetComponent<TextMeshProUGUI>().text = hp.ToString();
    }
    void Update()
    {
        ptsText.gameObject.GetComponent<TextMeshProUGUI>().text = pts.ToString();

    }

    public void AddPoints(int points)
    {
        pts += points;
    }

    public void playerHit(int value)
    {
        hp += value;
        hpText.gameObject.GetComponent<TextMeshProUGUI>().text = hp.ToString();
        if(!wasPlayerHit) wasPlayerHit = true;
        else wasPlayerHit = false;
    }
    public void playerHit()
    {
        if(!wasPlayerHit) wasPlayerHit = true;
        else wasPlayerHit = false;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void nextLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex +1);
    }

}
