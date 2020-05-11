using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsController : MonoBehaviour
{
    public AudioClip[] sounds;
    AudioSource player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<AudioSource>();
        //for(int i = 0; i < )
        //sounds = Resources.Load<AudioClip>[]("Sounds");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayEffect(int id)
    {
        player.clip = sounds[id];
        player.Play();
    }

}

/*Sound Effect List:
 * 0 - Laser
 * 1 - power up
 * 2 - player engine
 * 3 - repair needed alert
 * 4 - radio
 * 5 - Explosion
 * 6 - Enemy spawn
 * 7 - Button press 
 * 8 - meteor hit player
 * */