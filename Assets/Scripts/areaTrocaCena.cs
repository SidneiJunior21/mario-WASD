using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]
public class areaTrocaCena : MonoBehaviour
{
    [SerializeField] private string nomeCenaDestino;
    [SerializeField] private LayerMask layerJogador;

    private Collider2D areaTrigger;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (((1 << other.gameObject.layer) & layerJogador) != 0)
        {
            SceneManager.LoadScene(nomeCenaDestino);
        }
    }
}