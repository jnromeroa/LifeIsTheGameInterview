using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParCalculator : MonoBehaviour
{

    public float Bet = 1f;
    public int TestIterations;
    [SerializeField] private float RTP;
    [SerializeField] private int _totalCombinations;
    [SerializeField] private int _timesWon = 0;
    [SerializeField] private int _timesWonTruly = 0;
    [SerializeField] private float winRate = 0f;
    [SerializeField] private float trueWinrate = 0f;
    [SerializeField] private float totalWon = 0;
    [SerializeField] private float totalBet = 0;
    [SerializeField] private SlotMachine _slotMachine;


    private void Start()
    {
        CalculateCombinations();
        Test();
        totalBet = Bet * TestIterations;
        RTP = (totalWon / totalBet)*100;
        winRate = _timesWon / TestIterations;
        trueWinrate = _timesWonTruly / TestIterations;
    }

    [ContextMenu("Test")]
    public void Test()
    {
        for (int i = 0; i < TestIterations; i++)
        {

            Symbol[] symbols = _slotMachine.Spin();
            float multiplier = _slotMachine.CheckWinningLinesAndAssignMultiplier(symbols);

            Debug.Log($"{symbols[0].name} {symbols[1].name} {symbols[2].name} {symbols[3].name} {symbols[4].name}");
            float won = Bet * multiplier;
            Debug.Log($"Usted apostó {Bet}, y obtuvo {won}");
            if (won>0)
            {
                _timesWon++;
                totalWon += won;
                if (won > Bet)
                {
                    _timesWonTruly++;
                }
            }
        }
        
    }

    private void CalculateCombinations()
    {
        _totalCombinations = 1;
        foreach (var reel in _slotMachine.Reels)
        {
            _totalCombinations *= reel.Symbols.Count;
        }
    }
}
