using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;


public class blocoGerador : MonoBehaviour
{
    public GameObject objetoParaGerar;
    public float alturaSpawn = 0.5f;
    [SerializeField] private TileBase tileUsadoS;
    private Tilemap tilemap;
    private static Dictionary<Vector3Int, bool> tilesUsadosGlobal = new Dictionary<Vector3Int, bool>();

    void Awake()
    {
        tilemap = GetComponent<Tilemap>();
    }

    void OnCollisionEnter2D(Collision2D colisao)
    {
        if (colisao.contacts[0].normal.y > 0.5f)
        {
            Vector3Int tilePos = tilemap.WorldToCell(colisao.contacts[0].point);

            if (tilemap.HasTile(tilePos) && !TileFoiUsado(tilePos))
            {
                Vector3 posicaoSpawn = tilemap.GetCellCenterWorld(tilePos) + Vector3.up * alturaSpawn;
                Instantiate(objetoParaGerar, posicaoSpawn, Quaternion.identity);
                if (tileUsadoS != null)
                {
                    tilemap.SetTile(tilePos, tileUsadoS);
                }
                MarcarTileComoUsado(tilePos);
            }
        }
    }

    bool TileFoiUsado(Vector3Int posicao)
    {
        return tilesUsadosGlobal.ContainsKey(posicao);
    }

    void MarcarTileComoUsado(Vector3Int posicao)
    {
        tilesUsadosGlobal[posicao] = true;
    }
}