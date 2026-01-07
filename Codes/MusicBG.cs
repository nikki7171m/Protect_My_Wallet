using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBG : MonoBehaviour
{
    [SerializeField] public static MusicBG instanceBG;

    void Awake()
    {
        if (instanceBG != null && instanceBG != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instanceBG = this;
        DontDestroyOnLoad(this);
    }
}
