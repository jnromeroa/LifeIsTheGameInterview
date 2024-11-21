using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Par Template", menuName = "Par/Slot Machine")]
public class SlotMachine : ScriptableObject 
{
    public Reel[] Reels;
    
    public Symbol[] Spin()
    {
        Symbol[] result = new Symbol[Reels.Length];
        for (int i = 0; i < Reels.Length; i++)
        {
            if (!Reels[i].isLoaded)
            {
                Reels[i].LoadReel();
            }
            result[i] = Reels[i].Symbols[Random.Range(0, Reels[i].Symbols.Count)];
        }
        return result;
    }

    public float CheckWinningLinesAndAssignMultiplier(Symbol[] SpinnedResult)
    {
        Symbol mostRepeated = null;
        int counter = 0;
        foreach (var symbol in SpinnedResult)
        {
            if (mostRepeated == null)
            {
                mostRepeated = symbol;
                counter = 1;
                continue;
            }

            if (symbol.Equals(mostRepeated))
            {
                counter++;
                continue;
            }

            if (counter < 3)
            {
                mostRepeated = symbol;
                counter = 1;
            }

        }
        float result = counter == 3 ? 
            mostRepeated.ThreeOfKindMultiplier : counter == 4 ?
            mostRepeated.FourOfKindMultiplier :counter == 5? 
            mostRepeated.FiveOfKindMultiplier : 0 ;
        return result;

    }


}

