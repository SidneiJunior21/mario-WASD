using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class somConfig : MonoBehaviour
{
        [SerializeField] private AudioMixer mixer;
        [SerializeField] private Slider slider;

        private void start()
        {
            Volume();
        }
        public void Volume()
        {
            float volume = slider.value;
            mixer.SetFloat("Music", Mathf.Log10(volume)*20);
        }

}
