using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioassetsource : MonoBehaviour
{
    public string url;

    public void buka()
    {
        Application.OpenURL(url);
    }
}
