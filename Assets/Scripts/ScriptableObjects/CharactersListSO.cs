using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "CharactersListSO", menuName = "ScriptableObjects/CharactersListSO")]
public class CharactersListSO : ScriptableObject
{
    public List<CharacterSO> list;
}
