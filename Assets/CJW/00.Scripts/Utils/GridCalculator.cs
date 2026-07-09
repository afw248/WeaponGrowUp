using System.Collections.Generic;
using UnityEngine;

namespace CJW._00.Scripts.Utils
{
    public static class GridCalculator
    {
        public static List<Vector2> Calculate(int count, Vector2 size, Vector2 space, int column)
        {
            List<Vector2> positions = new();

            int columnCount = column;
            float cellWidth = size.x;
            float cellHeight = size.y;
            float spacingX = space.x;
            float spacingY = space.y;

            int rowCount = Mathf.CeilToInt((float)count / columnCount);

            float totalWidth =
                columnCount * cellWidth +
                (columnCount - 1) * spacingX;

            float totalHeight =
                rowCount * cellHeight +
                (rowCount - 1) * spacingY;

            Vector2 startPos = new Vector2(
                -totalWidth / 2 + cellWidth / 2,
                totalHeight / 2 - cellHeight / 2
            );

            for (int i = 0; i < count; i++)
            {
                int row = i / columnCount; // 세로 몇번째
                int col = i % columnCount; // 가로 몇번째

                float x = startPos.x + col * (cellWidth + spacingX); // 시작 위치에서 row번째까지 x값 증가
                float y = startPos.y - row * (cellHeight + spacingY); // 시작 위치에서 col번째까지 y값 증가

                positions.Add(new Vector2(x, y));
            }

            return positions;
        }
    }
}