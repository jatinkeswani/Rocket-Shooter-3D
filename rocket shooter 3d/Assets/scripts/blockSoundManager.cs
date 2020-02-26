using UnityEngine.Audio;
using UnityEngine;

public class blockSoundManager : MonoBehaviour
{
    public AudioClip block;
    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.pitch = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void tapSound()
    {
        source.PlayOneShot(block, 0.3f);
        source.pitch += 0.03f;
    }
    public void pitchBackToNull() {
        source.pitch = 0.5f;
    }
}
