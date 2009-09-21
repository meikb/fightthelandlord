using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;

namespace PathFinderSpace
{
    public class PathNote
    {
        public int F; //F = G + H
        public int G;
        public int H;
        public int X;
        public int Y;
        public PathNote parentNote;
    }

    public struct Vector
    {
        public int X;
        public int Y;
        public Vector(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    public class PathFinder
    {
        /// <summary>
        /// 矩阵
        /// </summary>
        private byte[,] matrix;
        /// <summary>
        /// 开始点
        /// </summary>
        private Vector startPoint;
        /// <summary>
        /// 结束点
        /// </summary>
        private Vector endPoint;
        /// <summary>
        /// 开启列表
        /// </summary>
        private List<PathNote> openedList = new List<PathNote>(); //开启列表
        /// <summary>
        /// 关闭列表
        /// </summary>
        private List<PathNote> colsedList = new List<PathNote>(); //关闭列表
        /// <summary>
        /// 是否允许斜线行走
        /// </summary>
        private bool diagonals;
        /// <summary>
        /// 方向
        /// </summary>
        private sbyte[,] direction = new sbyte[8, 2] { { 0, -1 }, { 1, 0 }, { 0, 1 }, { -1, 0 }, { 1, -1 }, { 1, 1 }, { -1, 1 }, { -1, -1 } }; //默认方向
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="matrix">待检测矩阵</param>
        /// <param name="startPoint">开始点</param>
        /// <param name="endPoint">结束点</param>
        public PathFinder(byte[,] matrix, Vector startPoint, Vector endPoint)
        {
            this.matrix = matrix;
            this.startPoint = startPoint;
            this.endPoint = endPoint;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="matrix">矩阵</param>
        /// <param name="startPoint">开始点</param>
        /// <param name="endPoint">结束点</param>
        /// <param name="diagonals">是否允许斜线行走</param>
        public PathFinder(byte[,] matrix, Point startPoint, Point endPoint, bool diagonals)
        {
            this.matrix = matrix;
            this.startPoint = GetVectorByPoint(startPoint);
            this.endPoint = GetVectorByPoint(endPoint);
            this.diagonals = diagonals;
            if (!diagonals)
            {
                direction = new sbyte[4, 2] { { 0, -1 }, { 0, 1 }, { -1, 0 }, { 1, 0 } }; //不允许穿角,4方向
            }
        }
        /// <summary>
        /// 开始寻找路径
        /// </summary>
        /// <returns></returns>
        public List<Point> StartFindPath()
        {
            var found = false;
            var pathNote = new PathNote() { F = 0, G = 0, H = 0, X = (int)startPoint.X, Y = (int)startPoint.Y, parentNote = null };
            List<Point> resultPoints = null;
            while (true)
            {
                for (int i = 0; i < (diagonals ? 8 : 4); i++)  //找到pathNote四方向或八方向周围节点,取F值最小的那个继续此过程
                {
                    var x = pathNote.X + direction[i, 0];
                    var y = pathNote.Y + direction[i, 1];

                    if (x < 0 || y < 0 || x > matrix.GetUpperBound(0) || y > matrix.GetUpperBound(1)) //坐标过界
                        continue;

                    var newPathNote = new PathNote();
                    newPathNote.parentNote = pathNote;
                    newPathNote.X = x;
                    newPathNote.Y = y;

                    bool isClosed = false;
                    bool isOpened = false;
                    PathNote theOpendandSameNote = null;
                    foreach (var closedNote in colsedList)
                    {
                        if (closedNote.X == newPathNote.X && closedNote.Y == newPathNote.Y)
                        {
                            isClosed = true;  //节点已经在关闭列表中
                        }
                    }

                    foreach (var openedNote in openedList)
                    {
                        if (openedNote.X == newPathNote.X && openedNote.Y == newPathNote.Y)
                        {
                            isOpened = true; //节点已经在开启列表中,稍后比较两条路径
                            theOpendandSameNote = openedNote;
                        }
                    }

                    if (matrix[newPathNote.X, newPathNote.Y] != 0 || isClosed) //不能通行或者已经在关闭列表中存在
                        continue;

                    if (Math.Abs(direction[i, 0] + direction[i, 1]) == 2)  //G值
                    {
                        newPathNote.G = newPathNote.parentNote.G + 14;
                    }
                    else
                    {
                        newPathNote.G = newPathNote.parentNote.G + 10;
                    }

                    newPathNote.H = (int)(Math.Abs(endPoint.X - newPathNote.X) + Math.Abs(endPoint.Y - newPathNote.Y)) * 10;  //H值
                    newPathNote.F = newPathNote.G + newPathNote.H;  //F值


                    if (isOpened) //比较已在开启列表中的节点G值和准备创建的节点G值
                    {
                        if (newPathNote.G >= theOpendandSameNote.G)
                        {
                            this.openedList.Remove(pathNote);
                            continue;
                        }
                        else
                        {
                            this.openedList.Remove(theOpendandSameNote);
                            this.openedList.Add(newPathNote);
                            continue;
                        }
                    }

                    this.openedList.Add(newPathNote); //创建节点(添加进开启列表)
                }
                this.colsedList.Add(pathNote); //把当前节点放进关闭列表
                this.openedList.Remove(pathNote); //从开启列表移除当前节点
                foreach (var openedNote in openedList)
                {
                    if (openedNote.X == (int)endPoint.X && openedNote.Y == (int)endPoint.Y) // 到达终点
                    {
                        resultPoints = GetPointListByParent(openedNote, null); //得到以Point构成的路径
                        found = true;
                        break;
                    }
                }

                if (found)
                {
                    break;
                }
                else
                {
                    if (openedList.Count == 0)  //找不到路径
                    {
                        break;
                    }
                    else
                    {
                        PathNote tempNote = null;
                        foreach (var opendedNote in openedList)
                        {
                            if (tempNote == null)
                            {
                                tempNote = opendedNote;
                            }
                            else
                            {
                                if (opendedNote.F < tempNote.F)
                                {
                                    tempNote = opendedNote;
                                }
                            }
                        }
                        //openedList.Sort(Compare);

                        pathNote = tempNote;
                    }
                }
            }
            return resultPoints;
        }

        /// <summary>
        /// 组织传入的PathNote的所有父节点为List
        /// </summary>
        /// <param name="pathNote">PathNote</param>
        /// <param name="pathPoints">列表</param>
        /// <returns>路径</returns>
        private List<Point> GetPointListByParent(PathNote pathNote, List<Vector> pathPoints)
        {
            if (pathPoints == null)
                pathPoints = new List<Vector>();
            if (pathNote.parentNote != null)
            {
                pathPoints.Add(new Vector(pathNote.parentNote.X, pathNote.parentNote.Y));
                GetPointListByParent(pathNote.parentNote, pathPoints);
            }
            var points = new List<Point>();
            foreach (var vector in pathPoints)
            {
                points.Add(GetPointByVector(vector));
            }
            return points;
        }

        private Point GetPointByVector(Vector vector)
        {
            return new Point(vector.X, vector.Y);
        }

        private Vector GetVectorByPoint(Point point)
        {
            return new Vector((int)point.X, (int)point.Y);
        }

        /// <summary>
        /// 比较两个节点的F值
        /// </summary>
        /// <param name="x">第一个节点</param>
        /// <param name="y">第二个节点</param>
        /// <returns></returns>
        private int Compare(PathNote x, PathNote y)
        {
            if (x.F > y.F)
                return 1;
            else if (x.F < y.F)
                return -1;
            return 0;
        }
    }
}