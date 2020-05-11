using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsController : MonoBehaviour
{
    private AudioClip[] sounds;
    AudioSource player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<AudioSource>();
        sounds = Resources.LoadAll<AudioClip>("SoundEffects");

        Resources.UnloadUnusedAssets();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayEffect(string id, bool loop, float volume)
    {
        player.volume = volume;
        for(int i = 0; i < sounds.Length-1; i++)
        {
            if (sounds[i].name == id)
            {
                player.clip = sounds[i];

                if (loop)
                {
                    player.loop = true;
                    player.Play();
                }
                else
                {
                    player.loop = false;
                    player.Play();
                }
                break;
            }
        }

    }

    public void StopEffect(string id)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == id)
            {
                player.clip = sounds[i];
                player.Stop();
                break;
            }
        }
    }

}

/*Sound Effect List:
 * 0 - ButtonPress
 * 1 - EnemySpawn
 * 2 - Explosion
 * 3 - Laser
 * 4 - MeteorHit
 * 5 - PlayerEngine
 * 6 - Power-Ups
 * 7 - Radio
 * 8 - Repairing
 * */