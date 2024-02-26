using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceHandler : MonoBehaviour
{
    [SerializeField] Animator _characterAnimator;
    private void Start()
    {
        int hash = PlayerPrefs.GetInt("Hash", -1);
        hash = hash == -1 ? Animator.StringToHash("House") : hash;
        PlayAnimation(hash);

    }

    public void PlayAnimation(int hash)
    {
        _characterAnimator.SetTrigger(hash);
    }
}
