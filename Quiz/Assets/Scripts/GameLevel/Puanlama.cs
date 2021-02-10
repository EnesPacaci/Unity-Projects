using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puanlama : MonoBehaviour
{
    [SerializeField]
    private Text puanText;

    private int toplamPuan;
    void Start()
    {
        puanText.text = toplamPuan.ToString();
    }
    public void PuaniArtir()
    {
        toplamPuan = toplamPuan + 10;
        puanText.text = toplamPuan.ToString();
    }
}
