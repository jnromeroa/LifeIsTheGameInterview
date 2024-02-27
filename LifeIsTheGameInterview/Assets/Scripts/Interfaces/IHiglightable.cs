using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHiglightable
{
    public bool IsHighlighted { get; }
    public void Highlight();
    public void Unhighlight();
}
