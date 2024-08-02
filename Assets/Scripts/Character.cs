using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterSystem
{
    [Serializable]
    public class NeedsContainer
    {
        public float state;
        public Needs needType;

        public NeedsContainer(Needs needs)
        {
            needType = needs;
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

        public const int CharacterNeedsCount = 8;

        [ContextMenu("Initialize Needs List")]
        public void InitNeeds()
        {
            needs = new List<NeedsContainer>();
            for (int i = 0; i < CharacterNeedsCount; i++)
            {
                needs.Add(new NeedsContainer((Needs)i));
            }
        }
    }
}
