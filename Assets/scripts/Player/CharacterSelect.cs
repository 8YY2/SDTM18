using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{

    public GameObject[] skins;
    public int SelectedChracter;
    // Start is called before the first frame update
    void Start()
    {
        SelectedChracter = PlayerPrefs.GetInt("SelectedChracter",0);
        foreach (GameObject player in skins)
            player.SetActive(false);

        skins[SelectedChracter].SetActive(true);
    }
    public void ChangeNext()
    {

        skins[SelectedChracter].SetActive(false);
        SelectedChracter++;
        if (SelectedChracter == skins.Length)
            SelectedChracter = 0;

        skins[SelectedChracter].SetActive(true);

        PlayerPrefs.SetInt("SelectedChracter", SelectedChracter);
    }


    public void ChangePre()
    {

        skins[SelectedChracter].SetActive(false);
        SelectedChracter--;
        if (SelectedChracter == -1)
            SelectedChracter = skins.Length -1;

        skins[SelectedChracter].SetActive(true);

        PlayerPrefs.SetInt("SelectedChracter", SelectedChracter);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
