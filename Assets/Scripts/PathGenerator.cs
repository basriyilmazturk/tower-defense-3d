using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Random = UnityEngine.Random;


public class PathGenerator {
    private int _width, _height;
    private List<Vector2Int> _pathCells;

    public PathGenerator(int width, int height) {
        _width = width;
        _height = height;
    }

    public List<Vector2Int> GeneratePath() {
        _pathCells = new List<Vector2Int>();

        // int y = _height / 2;
        // for (int x = 0; x < _width; x++) {
        //     _pathCells.Add(new Vector2(x, y));
        // }


        int y = _height / 2;
        int x = 0;

        while (x < _width) {
            _pathCells.Add(new Vector2Int(x, y));
            bool validMove = false;
            while (!validMove) {
                int move = Random.Range(0, 3);
                if (move == 0 || x % 2 == 0) {
                    x++;
                    validMove = true;
                }
                else if (move == 1 && IsCellFree(x, y + 1)) {
                    y++;
                    validMove = true;
                }
                else if (move == 2 && IsCellFree(x, y - 1)) {
                    y--;
                    validMove = true;
                }
            }
        }

        return _pathCells;
    }

    private bool IsCellFree(int x, int y) {
        return !_pathCells.Contains(new Vector2Int(x, y));
    }
}