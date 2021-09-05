using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    private WayThief _thief;
    private MaxVolumeAlarm _maxVolumeAlarm;
    private AudioSource _sound;

    private void Start()
    {
        _thief = FindObjectOfType<WayThief>();
        _maxVolumeAlarm = FindObjectOfType<MaxVolumeAlarm>();
        _sound = FindObjectOfType<AudioSource>();
    }

    private void Update()
    {
        if (transform.position.x >= _thief.transform.position.x)
        {
            _sound.mute = false;
            _sound.volume = Mathf.MoveTowards(transform.position.x, _maxVolumeAlarm.transform.position.x, ((_thief.transform.position.x - transform.position.x) / (transform.position.x - _maxVolumeAlarm.transform.position.x)) + transform.position.x);
        }
        else
        {
            _sound.mute = true;
        }    
    }
}
