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

    public float Time;

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

    public IEnumerator StatRefillTimer(Character character)
    {
        while (true)
        {
            StartCoroutine(Refill(character));
            Debug.Log("Timer has started");
            yield return new WaitForSeconds(Time + 0.1f);
            Destroy(this.gameObject);
            StopAllCoroutines();
            
        }
    }

    IEnumerator Refill(Character character)
    {
        switch (Needs)
        {
            case Needs.Hunger:
                character.needs[0].satisfactionRate += Amount;
                break;
            case Needs.Thirst:
                character.needs[1].satisfactionRate += Amount;
                character.needs[1].decayRate = 0f;
                yield return new WaitForSeconds(Time);
                character.needs[1].decayRate = 0.25f;
                character.needs[1].satisfactionRate = 0f;
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
        yield return null;
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






