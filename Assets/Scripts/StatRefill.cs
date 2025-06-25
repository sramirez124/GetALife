using System;
using System.Collections;
using System.Collections.Generic;
using CharacterSystem;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

[Serializable]
public class StatRefill : MonoBehaviour
{
    public Needs Needs;

    [Range(0f, 100f)]
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

    public void Refill(Character character)
    {
        switch (Needs)
        {
            case Needs.Hunger:
                character.needs[0].satisfactionRate += Amount;
                break;
            case Needs.Thirst:
                character.needs[1].satisfactionRate += Amount;
                break;
            case Needs.Bladder:
                character.needs[2].satisfactionRate += Amount;
                break;
            case Needs.Hygiene:
                character.needs[3].satisfactionRate += Amount;
                break;
            case Needs.Fun:
                character.needs[4].satisfactionRate += Amount;
                break;
            case Needs.Energy:
                character.needs[5].satisfactionRate += Amount;
                break;
            case Needs.Social:
                character.needs[6].satisfactionRate += Amount;
                break;
            case Needs.Room:
                character.needs[7].satisfactionRate += Amount;
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




