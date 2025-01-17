using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundMgr : G_Singleton<SoundMgr>
{
    public AudioMixer masterMixer;
    public Slider audioSlider;
    public AudioSource mainAudioSource; 
    public AudioClip Main_Sound; 
    public AudioClip Gita_Sound;
    public AudioClip Piano_Sound;

    private float savedValue = 0f;

    protected override void Init()
    {
        base.Init();

        if (audioSlider != null)
            audioSlider.onValueChanged.AddListener(SliderChanged);

        // 저장된 값이 있는지 확인 후 씬을 로드할 때 불러옴
        if (PlayerPrefs.HasKey("AudioSliderValue"))
        {
            savedValue = PlayerPrefs.GetFloat("AudioSliderValue");
            audioSlider.value = savedValue;
        }
        else
        {
            savedValue = audioSlider.value;
        }

        //Main_AudioSource 컴포넌트 설정
        if (mainAudioSource == null)
        {
            mainAudioSource = gameObject.AddComponent<AudioSource>();
            mainAudioSource.outputAudioMixerGroup = masterMixer.FindMatchingGroups("BGM")[0]; // BGM 그룹 선택
            mainAudioSource.playOnAwake = false;
            mainAudioSource.loop = true;
            mainAudioSource.clip = Main_Sound;
        }
        AudioControl(); // 저장된 값에 따라 사운드를 설정
    }

    void Start()
    {
        if (masterMixer != null)
            masterMixer.SetFloat("BGM", audioSlider.value);
    }

    // Update is called once per frame
    void Update()
    {
        //Missing된 슬라이드 오브젝트를 다시 등록
        if (audioSlider == null)
        {
            GameObject a_SObj = GameObject.Find("VolumeSlider");
            if (a_SObj != null)
                audioSlider = a_SObj.GetComponent<Slider>();

            if (audioSlider != null)
                audioSlider.onValueChanged.AddListener(SliderChanged);
        }
    }
    #region AudioCtrl
    public void AudioControl()
    {
        float sound = audioSlider.value;

        if (sound == -40f) masterMixer.SetFloat("BGM", -80);
        else masterMixer.SetFloat("BGM", sound);

        Debug.Log("sound : " + sound);
    }

    public void ToggleAudioVolume()
    {
        AudioListener.volume = AudioListener.volume == 0 ? 0 : 1;
    }
    #endregion

    public void SaveSliderValue()
    {
        savedValue = audioSlider.value;
        PlayerPrefs.SetFloat("AudioSliderValue", savedValue);
        PlayerPrefs.Save();

        Debug.Log("value : " + savedValue);
    }

    void SliderChanged(float value)
    {
        AudioControl();
        ToggleAudioVolume();
        SaveSliderValue();
    }

    public void PlayPainoSound()
    {
        mainAudioSource.Pause();
        mainAudioSource.clip = Piano_Sound;
        mainAudioSource.Play();
    }

    public void PlayGitaSound()
    {
        mainAudioSource.Pause(); // Main_Sound 일시정지
        mainAudioSource.clip = Gita_Sound;
        mainAudioSource.Play();
    }



    public void PlayMainSound()
    {
        mainAudioSource.Pause(); // Gita_Sound 일시정지
        mainAudioSource.clip = Main_Sound;
        mainAudioSource.Play();
    }

    private void OnApplicationQuit()
    {
        audioSlider.value = -10.0f;
    }
}