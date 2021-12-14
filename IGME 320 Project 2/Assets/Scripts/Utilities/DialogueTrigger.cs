using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
	public LevelList levelList;
	public Dialogue[] dialogue;

	// Begins a dialogue sequence with the given set of dialogue
	public void TriggerDialogue()
	{
		GameObject.Find("DialogueManager").GetComponent<DialogueManager>().StartDialogue(dialogue[levelList.CurrentLevel]);
	}
}
