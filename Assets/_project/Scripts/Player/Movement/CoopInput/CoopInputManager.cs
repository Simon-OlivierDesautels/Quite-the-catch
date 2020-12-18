using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CoopInputManager")]
public class CoopInputManager : ScriptableObject
{
    List<Input> inputList = new List<Input>();
    private enum Input
    {
        HorizontalP0,
        HorizontalP1,
        Fire1,
        Fire2P0,
        Fire2P1
    }
    
    [SerializeField] private Input _controlHorizontal;
    [SerializeField] private Input _fire1Input;
    [SerializeField] private Input _fire2Input;
    

    [SerializeField] private List<String> _inputStringList = new List<string>();

    

    public void ClearList()
    {
        _inputStringList = new List<string>();
        _inputStringList.Clear();
        Debug.Log(_inputStringList.Count);
    }
    public List<String> ReturnInputs()
    {
        GroupInputs();
        return _inputStringList;
    }
    
    public void GroupInputs()
    {
        inputList.Add(_controlHorizontal);
        inputList.Add(_fire1Input);
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
