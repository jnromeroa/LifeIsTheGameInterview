using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceHandler : MonoBehaviour
{
    [SerializeField] Animator _characterAnimator;
    private int _animationHash;
    private void Start()
    {
        LoadAnimationHash();
        PlayAnimation(_animationHash);

    }

    public void PlayAnimation(int hash)
    {
        _characterAnimator.SetTrigger(hash);
    }

    private void LoadAnimationHash()
    {
        int hash = PlayerPrefs.GetInt("HASH", -1);
        Debug.Log($"Hash {hash} loaded.");
        _animationHash = hash == -1 ? Animator.StringToHash("House") : hash;
    }
}
