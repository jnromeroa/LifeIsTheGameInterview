using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Reel
{
    public SymbolConfiguration[] SymbolConfigurations;
    public List<Symbol> Symbols;
    public bool isLoaded = false;
    public void LoadReel()
    {
        Symbols = new List<Symbol>();
        foreach (var symbolConf in SymbolConfigurations)
        {
            for (int i = 0; i < symbolConf.amount; i++)
            {
                Symbols.Add(symbolConf.symbol);
            }
        }
        isLoaded = true;
    }
    
}

[System.Serializable]
public class SymbolConfiguration
{
    public Symbol symbol;
    public int amount;
}
