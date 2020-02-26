using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Audio;
public class soundManager : MonoBehaviour
{

    public AudioClip tap,fire,powerUp,lazer,destroy;
    private AudioSource source;
    public Sprite[] images;
    public GameObject backCanvas;
    public GameObject[] particles;
    // Start is called before the first frame update
    void Start()
    {
        manageBackGround();
        source = GetComponent<AudioSource>();
        int i = Random.Range(0, particles.Length);
        particles[i].SetActive(true);
    }

    public void tapSound() {
        source.PlayOneShot(tap, 0.5f);
    }
    public void destroyFn()
    {
        source.PlayOneShot(destroy, 0.5f);
    }
    public void fireFn()
    {
        source.PlayOneShot(fire, 0.2f);
    }
    public void powerUpFn()
    {
        source.PlayOneShot(powerUp, 0.5f);
    }
    
    public void laserFn()
    {
        source.PlayOneShot(lazer, 0.1f);
    }
   // public void blackHitFn()
    //{
        //source.PlayOneShot(blackHi, 1f);
    //}
    void manageBackGround() {
        int i = Random.Range(0,images.Length);
        backCanvas.GetComponent <Image>().sprite= images[i];
    }
}
