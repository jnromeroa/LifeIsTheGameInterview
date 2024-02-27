using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DanceMenuHandler : MonoBehaviour
{
    [SerializeField]
    private string[] _animationStrings = new string[3];
    [SerializeField]
    Animator _characterAnimator;
    private Dictionary<string, int> _animationDictionary = new Dictionary<string, int>();
    private int selectedAnimationHash;
    private void Awake()
    {
        foreach (var animation in _animationStrings)
        {
            int hash = Animator.StringToHash(animation);
            _animationDictionary.Add(animation, hash);
        }
        
    }

    public void SelectAnimation(string name)
    {
        int hash = _animationDictionary[name];
        _characterAnimator.SetTrigger(hash);
        selectedAnimationHash = hash;
    }

    public void SaveSelection()
    {
        PlayerPrefs.SetInt("HASH", selectedAnimationHash);
        Debug.Log($"Hash {selectedAnimationHash} has been saved.");
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(1);
    }
}
