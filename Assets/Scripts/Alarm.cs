using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private float _speed;

    private WayThief _thief;
    private AudioSource _sound;
    private float _runningTime;

    private void Start()
    {
        _thief = FindObjectOfType<WayThief>();
        _sound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (transform.position.x >= _thief.transform.position.x)
            _runningTime += Time.deltaTime * _speed;
        else
            _runningTime -= Time.deltaTime * _speed;

        SetMaxValue();

        _sound.volume = Mathf.MoveTowards(0, 1, _runningTime);
    }

    private void SetMaxValue()
    {
        if (_runningTime >= 1)
            _runningTime = 1;
        else if (_runningTime <= 0)
            _runningTime = 0;
    }
}
