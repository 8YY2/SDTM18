using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerChange : MonoBehaviour
{
    public GameObject[] playerPrefabs;
    int ChracterIndex;
    public CinemachineVirtualCamera VCam;
    // Start is called before the first frame update
    void Awake()
    {
        ChracterIndex= PlayerPrefs.GetInt("SelectedChracter", 0);
       GameObject player= Instantiate(playerPrefabs[ChracterIndex],new Vector2(-9.6f,-2.6f),Quaternion.identity);
       //GameObject player= Instantiate(playerPrefabs[ChracterIndex],new Vector2(60f,-3f),Quaternion.identity);
        VCam.m_Follow = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
