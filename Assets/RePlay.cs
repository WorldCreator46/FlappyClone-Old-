using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RePlay : MonoBehaviour
{
    public void RePlayGame()
    {
        SceneManager.LoadScene("PlayScene");
    }
    public void Shop()
    {
        SceneManager.LoadScene("ShopScene");
    }
    public void Item()
    {
        SceneManager.LoadScene("ItemScene");
    }
}
