using UnityEngine;
using UnityEngine.Events;

namespace ClocknestGames.Library.Utils
{
    [System.Serializable]
    public class ParticleEvent : UnityEvent<ParticleEventDispatcher> { }

    public class ParticleEventDispatcher : MonoBehaviour
    {
        public ParticleEvent OnParticleStopped;

        private void OnParticleSystemStopped()
        {
            OnParticleStopped?.Invoke(this);
        }
    }
}