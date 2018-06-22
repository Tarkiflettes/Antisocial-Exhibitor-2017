using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public Text CoinText;
    public Slider LifeSlider;
    public Transform LosePanel;

    private int _life = 10;
    private int _coin = 200;
    private float _zoom = 60;
    private WaveManager _waveManager;
    private AudioSource _audioSource;

    // Use this for initialization
    void Start()
    {
        LifeSlider.value = _life;
        CoinText.text = _coin.ToString();
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_waveManager == null)
            _waveManager = GameObject.Find("WaveManager").GetComponent<WaveManager>();
        _audioSource.pitch = 1 + (float) (((_waveManager.GetRealDifficulty() > 20 ? 20 : _waveManager.GetRealDifficulty()) - 1) / 100.0f);
        var d = Input.GetAxis("Mouse ScrollWheel");
        if (d > 0f)
        {
            _zoom -= Time.deltaTime * 100;
        }
        else if (d < 0f)
        {
            _zoom += Time.deltaTime * 100;
        }
        if (_zoom > 30 && _zoom < 90)
            Camera.main.fieldOfView = _zoom;

        Vector3 position = this.transform.position;
        if (Input.GetKey(KeyCode.UpArrow) && position.z < 20)
            position.z++;
        if (Input.GetKey(KeyCode.DownArrow) && position.z > -30)
            position.z--;
        if (Input.GetKey(KeyCode.RightArrow) && position.x < 20)
            position.x++;
        if (Input.GetKey(KeyCode.LeftArrow) && position.x > -20)
            position.x--;

        this.transform.position = position;
    }

    public int Coin
    {
        set
        {
            _coin = value;
            CoinText.text = _coin.ToString() + " $";
            if (_coin > 999999)
                CoinText.text = "+999999 $";
        }
        get
        {
            return _coin;
        }
    }

    public void VisitorEnterInOurSpace()
    {
        _life--;
        LifeSlider.value = _life;
        if (_life <= 0)
            LosePanel.gameObject.SetActive(true);
    }

}
