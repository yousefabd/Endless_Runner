using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCharacterAnimator : MonoBehaviour
{
    [SerializeField] private CharacterSO character;
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        ShopSystemUI.Instance.OnSelectCharacter += ShopSystemUI_OnSelectCharacter;
    }
    private void ShopSystemUI_OnSelectCharacter(CharacterSO character)
    {
        if (this.character.Equals(character))
        {
            animator.SetTrigger("Select");
            animator.SetBool("IsSelected", true);
        }
        else
        {
            animator.SetTrigger("Deselect");
            animator.SetBool("IsSelected", false);
        }
    }
}
