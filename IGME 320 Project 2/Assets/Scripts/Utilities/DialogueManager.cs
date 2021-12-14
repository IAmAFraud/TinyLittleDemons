using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
	public Text nameText;
	public Text dialogueText;

	public Animator dialogueAnimator;
	public Animator middleManAnimator;
	public Animator transitionAnimator;

	private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
		sentences = new Queue<string>();
    }

	// Sets initial values for the dialogue, then begins typing out dialogue
	public void StartDialogue(Dialogue dialogue)
	{
		nameText.text = dialogue.name;

		sentences.Clear();

		foreach(string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		StartCoroutine(OnAnimationEnd(transitionAnimator));
	}

	// Writes the next sentence in the Queue
	public void DisplayNextSentence()
	{
		if(sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentences.Dequeue()));
	}

	// Types out a sentence character by character
	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";

		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return new WaitForSeconds(0.05f);
		}
	}

	// Waits for animations to end before running subsequent code
	IEnumerator OnAnimationEnd(Animator animator)
	{
		while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
			yield return null;

		if (animator == dialogueAnimator)
		{
			DisplayNextSentence();
		}
		else if (animator == middleManAnimator)
		{
			transitionAnimator.SetBool("TransitionStarted", true);
			StartCoroutine(OnAnimationEnd(transitionAnimator));
		}
		else if (animator == transitionAnimator)
		{
			if (transitionAnimator.GetBool("TransitionStarted") == false)
			{
				StartCoroutine(OnAnimationEnd(dialogueAnimator));
			}
			else
			{
				yield return new WaitForSeconds(3);
				ChangeScene changeScene = gameObject.GetComponent<ChangeScene>();

				if (changeScene.levels.CurrentLevel == changeScene.levels.StoredLevels.Count)
				{
					changeScene.LoadScene("GameWin");
				}
				else
				{
					changeScene.LoadScene("Tangram");
				}
			}
		}

		StopCoroutine(OnAnimationEnd(animator));
	}

	// Ends the dialogue and begins the transition to the puzzle
	void EndDialogue()
	{
		dialogueAnimator.SetBool("IsOpen", false);
		middleManAnimator.SetBool("HasEntered", false);
		StartCoroutine(OnAnimationEnd(middleManAnimator));
	}
}
