using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private float _speed;

    private AudioSource _sound;
    private float _runningTime;
    private bool _isEnterThief;

    public float RunningTime
    {
        get
        {
            return _runningTime;
        }
        private set
        {
            if (value >= 1)
                _runningTime = 1;
            else if (value <= 0)
                _runningTime = 0;
            else
                _runningTime = value;
        }
    }

    private void Start()
    {
        _sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<WayThief>(out WayThief thief))
            _isEnterThief = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<WayThief>(out WayThief thief))
            _isEnterThief = false;
    }

    private void Update()
    {
        if (_isEnterThief)
            RunningTime += Time.deltaTime * _speed;
        else
            RunningTime -= Time.deltaTime * _speed;

        _sound.volume = Mathf.MoveTowards(0, 1, RunningTime);
    }
}
