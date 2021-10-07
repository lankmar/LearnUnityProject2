using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BerserkAdventure
{
    public class GameSettings
    {
        [Range(0, 1)] private float effectVolume;
        [Range(0, 1)] private float musicVolume;
        private Language languageSetting;

        public float EffectVolume { get => effectVolume; set => effectVolume = value; }
        public Language LanguageSetting { get => languageSetting; set => languageSetting = value; }
        public float MusicVolume { get => musicVolume; set => musicVolume = value; }
    }
}