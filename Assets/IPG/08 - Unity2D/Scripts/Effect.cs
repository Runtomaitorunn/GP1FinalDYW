using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlanZucconi.IPG.Lecture08
{
    public class Effect : MonoBehaviour
    {
        [Range(0, 10)]
        public float TimeToLive = 5;

        // Start is called before the first frame update
        IEnumerator Start()
        {
            yield return new WaitForSeconds(TimeToLive);
            Destroy(gameObject);
        }
    }
}