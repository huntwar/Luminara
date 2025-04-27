using UnityEngine;

namespace Luminara.SoundManager
{
    public class StartMusic : MonoBehaviour
    {
        void Start()
        {
            SoundManager.PlayMusic(SoundType.BackgroundMusic);
        }
    }
}
