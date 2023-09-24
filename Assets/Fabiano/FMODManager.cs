using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore 
{
    public class FMODManager : MonoBehaviour
    {
        public FMODUnity.StudioEventEmitter emitter;

        //LeadPan
        public Transform transformNavicella;
        private ScreenBounds bounds;
        private float horizontalBound;
        private float posizioneNavicellaX;

        [SerializeField] float valorePan;

        //Arp
        public GameObject[] shootModules;
        public GameObject[] followers;
        public GameObject[] shieldModules;

        private int activeModules;
        private bool arpOn;

        // Start is called before the first frame update
        void Start()
        {
            bounds = GameObject.FindGameObjectWithTag("Bounds").GetComponent<ScreenBounds>();
            horizontalBound = bounds.GetHorizontalBounds().y;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            LeadPan();
            Arp();
        }

        public void LVUP()
        {
            StartCoroutine(LVUPCoroutine());
        }

        public IEnumerator LVUPCoroutine()
        {
            emitter.SetParameter("LvUp", 1f);
            yield return new WaitForSeconds(10);
            emitter.SetParameter("LvUp", 0f);
        }

        private void LeadPan()
        {
            posizioneNavicellaX = transformNavicella.position.x + bounds.GetHorizontalBounds().y;
            valorePan = Mathf.Abs(Mathf.FloorToInt((posizioneNavicellaX / (bounds.GetHorizontalBounds().y * 2) * 100) - 100));
            emitter.SetParameter("LeadPan", valorePan);
        }

        private void Arp()
        {
            activeModules = 0;

            foreach (var module in shootModules)
            {
                if (module.activeSelf)
                {
                    activeModules++;
                }
            }
            foreach (var module in followers)
            {
                if (module.activeSelf)
                {
                    activeModules++;
                }
            }
            foreach (var module in shieldModules)
            {
                if (module.activeSelf)
                {
                    activeModules++;
                }
            }

            if (activeModules > 0 &&
                arpOn == false)
            {
                emitter.SetParameter("Arp", 1f);
                arpOn = true;
            }
            else if (activeModules == 0 &&
                    arpOn == true)
            {
                emitter.SetParameter("Arp", 0f);
                arpOn = false;
            }
        }

        public void LowPassOn()
        {
            emitter.SetParameter("LowPass", 0f);
        }

        public void LowPassOff()
        {
            emitter.SetParameter("LowPass", 1f);
        }

        public void PitchBend()
        {
            StartCoroutine(PitchBendCoroutine());
        }

        private IEnumerator PitchBendCoroutine()
        {
            emitter.SetParameter("PitchBend", 0f);
            yield return new WaitForSeconds(1);
            emitter.SetParameter("PitchBend", 1f);
        }
    }
}
