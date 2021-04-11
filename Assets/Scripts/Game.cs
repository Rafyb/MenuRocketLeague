using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class Game : MonoBehaviour
{
    public GameObject erreur;
    public Image fade;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ErreurPop());
        fade.DOFade(0, 0.1f);
    }


    public void OnRetour()
    {
        fade.DOFade(1, 0.1f).OnComplete(OnFade);

    }

    private void OnFade()
    {
        SceneManager.LoadScene("Menu");
    }

    IEnumerator ErreurPop()
    {
        yield return new WaitForSeconds(2f);
        erreur.SetActive(true);
    }
}
