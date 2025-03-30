using UnityEngine;
using UnityEngine.Tilemaps;

public class blocosComuns : MonoBehaviour
{
    public float distanciaSubida = 1f;
    public float tempoSubida = 0.3f;
    public float tempoDescida = 0.9f;

    private Tilemap tilemap;
    private Vector3Int tileAtual;
    private Vector3 posicaoOriginal;
    private bool emMovimento = false;
    private float tempoMovimento;

    void Awake()
    {
        tilemap = GetComponent<Tilemap>();
    }

    void OnCollisionEnter2D(Collision2D colisao)
    {
        if (emMovimento) return;
        if (colisao.contacts[0].normal.y > 0.2f)
        {
            tileAtual = tilemap.WorldToCell(colisao.contacts[0].point);
            
            if (tilemap.HasTile(tileAtual))
            {
                posicaoOriginal = tilemap.CellToWorld(tileAtual);
                emMovimento = true;
                tempoMovimento = Time.time + tempoSubida + tempoDescida;
            }
        }
    }

    void Update()
    {
        if (!emMovimento) return;

        float progresso;
        Vector3 posicaoAlvo;

        if (Time.time < tempoMovimento - tempoDescida)
        {
            progresso = Mathf.Clamp01(
                (Time.time - (tempoMovimento - tempoSubida - tempoDescida)) / 
                tempoSubida
            );
            posicaoAlvo = posicaoOriginal + Vector3.up * distanciaSubida;
        }
        else
        {
            progresso = 1 - ((Time.time - (tempoMovimento - tempoDescida)) / tempoDescida);
            posicaoAlvo = posicaoOriginal;
        }
        Vector3 novaPos = Vector3.Lerp(posicaoOriginal, posicaoAlvo, progresso);
        tilemap.SetTransformMatrix(tileAtual, Matrix4x4.TRS(
            novaPos - tilemap.CellToWorld(tileAtual), 
            Quaternion.identity, 
            Vector3.one
        ));
        if (Time.time >= tempoMovimento)
        {
            tilemap.SetTransformMatrix(tileAtual, Matrix4x4.identity);
            emMovimento = false;
        }
    }
}