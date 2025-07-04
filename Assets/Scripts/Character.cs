using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace CharacterSystem
{
    [Serializable]
    public class NeedsContainer
    {
        [Range(0f, 100f)]
        public float state = 100f;
        public Needs needType;
        public float decayRate = 0.25f;
        public float satisfactionRate;

        public NeedsContainer(Needs needs)
        {
            needType = needs;
        }

        public void Decay()
        {
            state -= decayRate * Time.deltaTime;
            ClampState();
        }

        public void Satisfaction()
        {
            state += satisfactionRate * Time.deltaTime;
            ClampState();
        }

        public void ClampState()
        {
            state = Mathf.Clamp(state, 0f, 100f);
        }
    }

    public enum Needs
    {
        Hunger,
        Thirst,
        Bladder,
        Hygiene,
        Fun,
        Energy,
        Social,
        Room
    }
    public class Character : MonoBehaviour
    {
        public string Name;

        public List<NeedsContainer> needs;

        private const int CharacterNeedsCount = 8;

        [ContextMenu("Initialize Needs List")]
        public void InitNeeds()
        {
            needs = new List<NeedsContainer>();
            for (int i = 0; i < CharacterNeedsCount; i++)
            {
                needs.Add(new NeedsContainer((Needs)i));
            }
        }

        public void Update()
        {
            ProcessNeeds();
            OnMouseDown();
        }


        private void ProcessNeeds()
        {
            for (int i = 0; i < needs.Count; i++)
            {
                needs[i].Decay();
                needs[i].Satisfaction();
            }
        }

        private void OnMouseDown()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.tag == "StatRefill")
                    {
                        StartCoroutine(hit.transform.GetComponent<StatRefill>().Refill(this));
                        Debug.Log("Corountine Started");
                    }
                }
            }
        }
    }
}
