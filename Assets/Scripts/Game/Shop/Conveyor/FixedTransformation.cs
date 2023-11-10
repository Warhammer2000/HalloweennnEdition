using UnityEditor;
using UnityEngine;

public class FixedTransformation : StackableTransformation
{
    [SerializeField] private Stackable _stackable;
    [SerializeField] private Stackable _stackable2;

    public override StackableType Type => _stackable.Type;

    public override Stackable Transform(Stackable removedItem) => 
        _stackable;
    public override Stackable Transform(Stackable removedItem, bool what) => 
        _stackable;
}