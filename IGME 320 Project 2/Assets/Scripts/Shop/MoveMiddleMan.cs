using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMiddleMan : MonoBehaviour
{
	public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
		StartCoroutine(OnAnimationEnd());
    }

	// Waits for the animation to finish, then begins the dialogue sequence
	IEnumerator OnAnimationEnd()
	{
		while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
			yield return null;

		gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
		StopCoroutine(OnAnimationEnd());
	}
}
