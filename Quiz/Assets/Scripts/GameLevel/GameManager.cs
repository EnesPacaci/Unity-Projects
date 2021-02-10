using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Text sorulartext;
    public Sorular[] sorular;
    [SerializeField]
    private Image soruResmi;
    [SerializeField]
    private GameObject sonucPaneli;
    [SerializeField]
    private GameObject puanPaneli;
    [SerializeField]
    private GameObject soruPaneli;
    [SerializeField]
    private GameObject imagePaneli;
    [SerializeField]
    private GameObject butonPaneli;
    [SerializeField]
    AudioSource audioSource;

    public AudioClip DogrubutonSesi;

    [SerializeField]
    AudioSource audioSource2;

    public AudioClip YanlisbutonSesi;


    public bool dogruCevap;
    public int i;

    Puanlama puanlama;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        puanlama = Object.FindObjectOfType<Puanlama>();
        sonucPaneli.GetComponent<RectTransform>().localScale = Vector3.zero;

        i = 0;
        
        soruyuSor();
    }
    public void soruyuSor()
    {
        if (i >=sorular.Length)
        {
            i = 0;
            oyunBitti();
        }

        sorulartext.text = sorular[i].soru;
        soruResmi.sprite = sorular[i].resim;
        dogruCevap = sorular[i].cevap;

        
    }
 
   public void dogruButonaTiklandi()
    {
        audioSource.PlayOneShot(DogrubutonSesi);
        
        if (dogruCevap)
        {
            puanlama.PuaniArtir();
        }
        i++;
        soruyuSor();
        
    }
    public void yanlisButonaTiklandi()
    {
        audioSource.PlayOneShot(YanlisbutonSesi);
        if (!dogruCevap)
        {
            puanlama.PuaniArtir();
        }
        i++;
        soruyuSor();
        
    }
    public void oyunBitti()
    {
        sonucPaneli.GetComponent<RectTransform>().DOScale(1, 0.3f).SetEase(Ease.OutBack);
        soruPaneli.SetActive(false);
        puanPaneli.SetActive(false);
        imagePaneli.SetActive(false);
        butonPaneli.SetActive(false);
    }
    public void GameLevelDon()
    {
        SceneManager.LoadScene("GameLevel");
    }
    public void MenuLevelDon()
    {
        SceneManager.LoadScene("MenuLevel");
    }
}
