using System;
using System.Collections;
using System.Collections.Generic;
using CharacterSystem;
using Unity.VisualScripting;
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
                Amount = 0.25f;
                break;
            case Needs.Thirst:
                Amount = 0.25f;
                break;
            case Needs.Bladder:
                Amount = 0.25f;
                break;
            case Needs.Hygiene:
                Amount = 0.25f;
                break;
            case Needs.Fun:
                Amount = 0.25f;
                break;
            case Needs.Energy:
                Amount = 0.25f;
                break;
            case Needs.Social:
                Amount = 0.25f;
                break;
            case Needs.Room:
                Amount = 0.25f;
                break;
        }

    }

    public void Refill(Character character)
    {
        character.needs[(int)Needs].state += Amount;
        character.needs[(int)Needs].ClampState();
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




