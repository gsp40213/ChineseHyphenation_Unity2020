using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitOnClick : OnClick
{
    public void onClick()
    {
        Application.Quit();
    }
}
