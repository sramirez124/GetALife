using System;
using System.Collections;
using System.Collections.Generic;
using CharacterSystem;
using UnityEngine;

[Serializable]
public class StatRefill : MonoBehaviour
{
    public Needs Needs;
    public float Amount;
    void Start()
    {
        switch (Needs)
        {
            case Needs.Hunger:
                break;
            case Needs.Thirst:
                break;
            case Needs.Bladder:
                break;
            case Needs.Hygiene:
                break;
            case Needs.Fun:
                break;
            case Needs.Energy:
                break;
            case Needs.Social:
                break;
            case Needs.Room:
                break;
        }
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
