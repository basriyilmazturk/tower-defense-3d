using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour {
    public int gridWidth = 16;
    public int gridHeight = 8;

    public GameObject pathTile;

    private PathGenerator _pathGenerator;

    private void Start() {
        _pathGenerator = new PathGenerator(gridWidth, gridHeight);
        var pathCells = _pathGenerator.GeneratePath();

        StartCoroutine(LayPathCells(pathCells));
    }

    private IEnumerator LayPathCells(List<Vector2Int> pathCells) {
        foreach (var pathCell in pathCells) {
            Instantiate(pathTile, new Vector3(pathCell.x, 0f, pathCell.y), Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
     
        yield return null;
    }
}