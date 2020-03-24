using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager dataManager { get; private set; }

    public enum TypeSounds
    {
        button,
        star,
        electricity,
        endLevel
    }

    public bool[] levelUnlocked;
    public int[] starPerLevel;
    public FMOD.Studio.EventInstance[] music;
    public FMOD.Studio.EventInstance[] sounds;

    

    FMOD.Studio.PLAYBACK_STATE playbackState;
    float soundVolume;
    float musicVolume;

    public float SoundVolume
    {
        get
        {
            return soundVolume;
        }

        set
        {
            soundVolume = value;
        }
    }

    public float MusicVolume
    {
        get
        {
            return musicVolume;
        }

        set
        {
            musicVolume = value;
        }
    }

    // Use this for initialization
    void Awake()
    {
        //PlayerPrefs.DeleteAll();
        if (dataManager == null)
        {
            dataManager = this;
            LoadData();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LoadData()
    {
        levelUnlocked[0] = true;
        for (int i = 1; i < levelUnlocked.Length; i++)
        {
            levelUnlocked[i] = PlayerPrefs.GetInt("LevelUnlocked" + i, 0) != 0;
        }
        for (int i = 0; i < starPerLevel.Length; i++)
        {
            starPerLevel[i] = PlayerPrefs.GetInt("StarLevel" + i, 0);
        }
        soundVolume = PlayerPrefs.GetFloat("SoundVolume", 1.0f);
        musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1.0f);
        CreateAllSounds();
    }

    void CreateAllSounds()
    {
        music = new FMOD.Studio.EventInstance[2];
        music[0] = FMODUnity.RuntimeManager.CreateInstance("event:/menuTheme");
        music[1] = FMODUnity.RuntimeManager.CreateInstance("event:/gameTheme");
        music[0].start();
        sounds = new FMOD.Studio.EventInstance[4];
        sounds[(int)TypeSounds.button] = FMODUnity.RuntimeManager.CreateInstance("event:/button");
        sounds[(int)TypeSounds.star] = FMODUnity.RuntimeManager.CreateInstance("event:/piece");
        sounds[(int)TypeSounds.electricity] = FMODUnity.RuntimeManager.CreateInstance("event:/electricity");
        sounds[(int)TypeSounds.endLevel] = FMODUnity.RuntimeManager.CreateInstance("event:/portal");

        for (int i = 0; i < music.Length; i++)
            music[i].setVolume(musicVolume);
        for (int i = 0; i < sounds.Length; i++)
            sounds[i].setVolume(soundVolume);
    }

    public void ChangeMusic(int indexScene)
    {
        if (indexScene > 2)
        {
            music[1].getPlaybackState(out playbackState);

            if (playbackState != FMOD.Studio.PLAYBACK_STATE.PLAYING)
            {
                music[0].stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                music[1].start();
            }
        }
        else
        {
            music[0].getPlaybackState(out playbackState);
            if (playbackState != FMOD.Studio.PLAYBACK_STATE.PLAYING)
            {
                music[1].stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                music[0].start();
            }
        }
    }

    public void StopSounds()
    {
        for(int i =0; i < sounds.Length; i++)
        {
            sounds[i].getPlaybackState(out playbackState);
            if(playbackState == FMOD.Studio.PLAYBACK_STATE.PLAYING)
            {
                sounds[i].stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            }
        }
    }

    public void ChangeMusicVolume(float volume)
    {
        musicVolume = volume;
        for (int i = 0; i < music.Length; i++)
            music[i].setVolume(musicVolume);
    }

    public void ChangeSoundsVolume(float volume)
    {
        soundVolume = volume;
        for (int i = 0; i < sounds.Length; i++)
            sounds[i].setVolume(soundVolume);
    }

    public void SaveSoundData()
    {
        PlayerPrefs.SetFloat("SoundVolume", soundVolume);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        PlayerPrefs.Save();
    }

    public void SaveProgress(int indexLevel, int numberStar)
    {
        if (indexLevel + 1 != levelUnlocked.Length)
        {
            levelUnlocked[indexLevel + 1] = true;
            PlayerPrefs.SetInt("LevelUnlocked" + (indexLevel + 1), levelUnlocked[indexLevel + 1] ? 1 : 0);
        }
        if (numberStar > starPerLevel[indexLevel])
        {
            starPerLevel[indexLevel] = numberStar;
            PlayerPrefs.SetInt("StarLevel" + indexLevel, starPerLevel[indexLevel]);
        }
        PlayerPrefs.Save();
    }
}
