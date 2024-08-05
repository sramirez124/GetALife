using System;
using System.Collections;
using System.Collections.Generic;
using CharacterSystem;
using UnityEngine;

public class NeedPanel : MonoBehaviour
{
    [SerializeField] List<NeedsUIElement> children;
    Character character;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (character == null) { return; }
        UpdatePanel(character);
    }

    public void SelectCharacter(Character character)
    {
        this.character = character;
    }

    private void UpdatePanel(Character testCharacter)
    {
        for (int i = 0; i < children.Count; i++)
        {
            children[i].SetStatus(testCharacter.needs[i].state);
        }
    }
}
