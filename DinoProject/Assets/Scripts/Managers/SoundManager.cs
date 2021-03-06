using UnityEngine;

namespace DinoRunGame.Managers.SoundManager
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance;

        [SerializeField] private AudioSource _musicSource, _effectSource;  
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void PlaySound(AudioClip audioClip)
        {
            _effectSource.PlayOneShot(audioClip);
        }
        
    }
}
