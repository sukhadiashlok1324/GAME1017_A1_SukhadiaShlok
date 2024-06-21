using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.AddSound("Shoot", Resources.Load<AudioClip>("laserShoot"), SoundManager.SoundType.SOUND_SFX);
        SoundManager.AddSound("Hit", Resources.Load<AudioClip>("hitHurt"), SoundManager.SoundType.SOUND_SFX);
        SoundManager.AddSound("Explosion", Resources.Load<AudioClip>("explosion"), SoundManager.SoundType.SOUND_SFX);


        SoundManager.AddSound("Background", Resources.Load<AudioClip>("SoundManagerStart"), SoundManager.SoundType.SOUND_MUSIC);
       

    }

    public void PlaySFX(string soundKey)
    {
        SoundManager.PlaySound(soundKey);
    }

    public void PlayMusic(string soundKey)
    {
        SoundManager.PlayMusic(soundKey);
    }
}
