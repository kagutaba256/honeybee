using UnityEngine;

public class TileGenerator : MonoBehaviour {
    public GameObject hexTilePrefab;
    public int size = 5;
    public float tileXGap = 1.8f;
    public float tileZGap = 1.8f;

    void MakeTile (int x, int z) {
        GameObject tile = Instantiate (hexTilePrefab);
        if (z % 2 == 0) {
            tile.transform.position = new Vector3 (x * tileXGap, 0, z * tileZGap);
        } else {
            tile.transform.position = new Vector3 (x * tileXGap + tileXGap / 2, 0, z * tileZGap);
        }
        tile.transform.parent = transform;
        tile.name = x.ToString () + ", " + z.ToString ();
    }

    void MakeHexGrid () {
        int midRowLength = size * 2 + 1;
        for (int i = 0; i <= size; i++) {
            if ((midRowLength - i) > midRowLength / 2) {
                for (int j = 0; j <= (((midRowLength - 1) - i) / 2); j++) {
                    MakeTile (j, i);
                    MakeTile (j, -i);
                    MakeTile (-j, i);
                    MakeTile (-j, -i);
                }
                if (i % 2 == 1) {
                    MakeTile (-((midRowLength - i) / 2), i);
                    MakeTile (-((midRowLength - i) / 2), -i);
                }
            }
        }
    }
    void Start () {
        MakeHexGrid ();
        Camera cam = Camera.main;
        cam.orthographicSize = size * 1.5f + 1;
    }
}