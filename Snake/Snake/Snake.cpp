// Snake.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include <Windows.h>
#include <stdio.h>
#include <iostream>
#include <string>
#include <conio.h>
#include <xlocale>
#include <vector>
#include <algorithm>
#include <time.h>
#include <stdlib.h>

/* 无效？？？
#define PRACTICABLE 0 ;
#define UNPRACTICABLE 1 ;
#define FOOD 2 ;
#define HEAD 3 ;

#define Up 0;
#define Down 1;
#define Left 2;
#define  Right 3;
*/

using namespace std;



//function declare
DWORD WINAPI RePaint(LPVOID pvParam);
DWORD WINAPI FrameFunc(PVOID pvParam);
void OutCharByPosition(string s, int x, int y);

//class declare and define
class SnakePoint;
class SnakeVeerPoint;
class SnakeTail;
class SnakePoint
{
public:
	SnakePoint(int x, int y)
	{
		this->x = x;
		this->y = y;
	}
	SnakePoint()
	{
		this->x = 0;
		this->y = 0;
	}
	int x,y;
};
class SnakeVeerPoint
{
public:
	SnakePoint sp;
	int Direction;
	int PassCount;
	SnakeVeerPoint(int x, int y, int direction)
	{
		Direction = direction;
		sp.x = x;
		sp.y = y;
		PassCount = 0;
	}
};

class SnakeTail
{
public:
	SnakePoint sp;
	int Direction;
	SnakeTail(int x, int y)
	{
		Direction = 0;
		sp.x = x;
		sp.y = y;
	}
	SnakeTail()
	{
		sp.x = 0;
		sp.y = 0;
	}
};


//const define
const string strSnakeHead = "O";
const string strSnakeTail = "X";
const string strSnakeVeer = "()";
const string strSnakeFood = "F";
const int array_row = 29;
const int array_col = 50;
const int speed = 500; //运行速度，值越大越慢

//var declare or define
int TailCount = 1; 
int Direction = 0;
int SnakeX = 25;
int SnakeY = 14;
vector<SnakeTail> *bodys = new vector<SnakeTail>(10);
vector<SnakeVeerPoint> *veerPoints = new vector<SnakeVeerPoint>();
vector<SnakePoint> *foodPoints = new vector<SnakePoint>(3);
bool GameOver = false;
HANDLE cHandle;


int _tmain(int argc, _TCHAR* argv[])
{
	system("color 8A");
	system("title 贪吃蛇");
	system("mode con cols=100 lines=30");

	cHandle = GetStdHandle(STD_OUTPUT_HANDLE);

	HANDLE hThread1;
	HANDLE hThread2;

	hThread2 = CreateThread(NULL,0,FrameFunc,NULL,0,NULL);
	hThread1 = CreateThread(NULL,0,RePaint,NULL,0,NULL);
	CloseHandle(hThread1);
	CloseHandle(hThread2);
	char   ch;
	//初始化身体(尾巴);
	for (int i = 0; i != bodys->size(); ++i)
	{
		(*bodys)[i].sp.x = SnakeX;
		(*bodys)[i].sp.y = SnakeY + i + 1;
		(*bodys)[i].Direction = 0;
	}

	//初始化食物
	for (int i = 0; i != foodPoints->size(); ++i)
	{
		srand((unsigned)time(NULL));
		int x = (rand()%(48-2+1)) + 2;
		int y = (rand()%(28-2+1)) + 2;
		(*foodPoints)[i].x = x;
		(*foodPoints)[i].y = y;
		Sleep(100);
	}

	while   (1)     
	{     
		if(kbhit())   
		{   
			ch   =   getch();   
			switch(ch)   
			{   
			case  'w':
				if (Direction != 0 && Direction != 1)
				{
					Direction = 0;
					SnakeVeerPoint svp(SnakeX, SnakeY, Direction);
					veerPoints->push_back(svp);
				}
				break;   
			case  's':
				if (Direction != 1 && Direction != 0)
				{
					Direction = 1;
					SnakeVeerPoint svp(SnakeX, SnakeY, Direction);
					veerPoints->push_back(svp);
				}
				break;   
			case  'a':
				if (Direction != 2 && Direction != 3)
				{
					Direction = 2;
					SnakeVeerPoint svp(SnakeX, SnakeY, Direction);
					veerPoints->push_back(svp);
				}
				break;   
			case  'd':
				if (Direction != 3 && Direction != 2)
				{
					Direction = 3;
					SnakeVeerPoint svp(SnakeX, SnakeY, Direction);
					veerPoints->push_back(svp);
				}
				break;
			default:
				break;
			}
		}
	}
	return   0;  

}

DWORD WINAPI RePaint(PVOID pvParam)
{
	DWORD dwResult = 0;
	while(true)
	{
		system("cls");
		/*
		for (size_t i = 0; i != array_row; ++i)
		{
			for (size_t j = 0; j != array_col; ++j)
			{
				switch(Matrix[i][j])
				{
					case 0:
						OutCharByPosition("　", j, i);
						break;
					case 1:
						OutCharByPosition("D", j, i);
						break;
					case 2:
						OutCharByPosition("食", j, i);
						break;
					case 3:
						OutCharByPosition(SnakeHead, j, i);
						break;
				}
			}
		}
		*/

		OutCharByPosition(strSnakeHead, SnakeX, SnakeY);
		for (vector<SnakeTail>::iterator i = bodys->begin(); i != bodys->end(); ++i)
		{
			OutCharByPosition(strSnakeTail, i->sp.x, i->sp.y);
		}
		for (vector<SnakePoint>::iterator i = foodPoints->begin(); i != foodPoints->end(); ++i)
		{
			OutCharByPosition(strSnakeFood,i->x,i->y);
		}
		Sleep(speed);
	}
	return dwResult;
}

DWORD WINAPI FrameFunc(PVOID pvParam)
{
	DWORD dwResult = 0;
	while(!GameOver)
	{
		Sleep(speed);
		if (foodPoints->size() < 20)
		{
			srand((unsigned)time(NULL));
			int x = rand()%((48-2+1))+2;
			int y = rand()%((28-2+1))+2;
			bool isIncluded = false;
			for (vector<SnakePoint>::iterator i = foodPoints->begin(); i != foodPoints->end();++i) 
			{
				if (i->x == x && i->y == y)
					isIncluded = true;
			}
			if (!isIncluded)
			{
				SnakePoint sp(x, y);
				foodPoints->push_back(sp);
			}
		}
		switch (Direction)
		{
			case 0:
				if (SnakeY <= 2)
				{
					GameOver = true;
					break;
				}
				--SnakeY;
				break;
			case 1:
				if (SnakeY >=array_row - 2)
				{
					GameOver = true;
					break;
				}
				++SnakeY;
				break;
			case 2:
				if (SnakeX <= 2)
				{
					GameOver = true;
					break;
				}
				--SnakeX;
				break;
			case  3:
				if (SnakeX >= array_col -2)
				{
					GameOver = true;
					break;
				}
				++SnakeX;
				break;
			default:
				break;
		}

		for (vector<SnakeTail>::iterator i = bodys->begin(); i != bodys->end(); ++i)
		{
			switch(i->Direction)
			{
			case 0:
				--(i->sp.y);
				break;
			case 1:
				++(i->sp.y);
				break;
			case 2:
				--(i->sp.x);
				break;
			case 3:
				++(i->sp.x);
				break;
			default:
				break;
			}


			for (vector<SnakeVeerPoint>::iterator vi = veerPoints->begin(); vi != veerPoints->end(); ++vi)
			{
				if (vi->sp.x == i->sp.x && vi->sp.y == i->sp.y)
				{
					i->Direction = vi->Direction;
					++(vi->PassCount);
				}
				if (vi->PassCount == bodys->size())
				{
					vi = veerPoints->erase(vi);
					if (vi == veerPoints->end())
						break;
				}
			}
		}
		for (vector<SnakePoint>::iterator i = foodPoints->begin(); i != foodPoints->end();++i) 
		{
			if (i->x == SnakeX && i->y == SnakeY)
			{
				i = foodPoints->erase(i);
				break;
			}
		}
	}
	return dwResult;
}

void OutCharByPosition(string s, int x, int y)
{
	COORD setps;
	setps.X = x * 2;
	setps.Y = y;
	SetConsoleCursorPosition(cHandle, setps);

	cout << s << "";
}
