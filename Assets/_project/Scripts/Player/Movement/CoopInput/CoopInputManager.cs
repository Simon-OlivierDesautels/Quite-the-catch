using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CoopInputManager")]
public class CoopInputManager : ScriptableObject
{
    private enum Input
    {
        HorizontalP0,
        HorizontalP1,
        Fire2P0,
        Fire2P1
    }
    
    [SerializeField] private Input _controlHorizontal;
    [SerializeField] private Input _fire2Input;

    private List<String> _inputStringList;

    public List<String> ReturnInputs()
    {
        GroupInputs();
        return _inputStringList;
    }
    
    public void GroupInputs()
    {
        List<Input> inputList = new List<Input>();
        inputList.Add(_controlHorizontal);
        inputList.Add(_fire2Input);
        StringifyInput(inputList);
    }
    
    private void StringifyInput(List<Input> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            string currentInput = list[i].ToString();
            _inputStringList.Add(currentInput);
        }
    }

}
