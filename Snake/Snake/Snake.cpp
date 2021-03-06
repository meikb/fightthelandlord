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
	SnakeTail(int x, int y, int dir)
	{
		Direction = dir;
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
const string strSnakeHead = "⊙";
const string strSnakeTail = "■";
const string strSnakeVeer = "()";
const string strSnakeFood = "★";
const int array_row = 29;
const int array_col = 50;
const int speed = 100; //运行速度，值越大越慢

//var declare or define
int TailCount = 1; 
int Direction = 0;
int SnakeX = 25;
int SnakeY = 14;
vector<SnakeTail*> *bodys = new vector<SnakeTail*>(10);
vector<SnakeVeerPoint*> *veerPoints = new vector<SnakeVeerPoint*>();
vector<SnakePoint*> *foodPoints = new vector<SnakePoint*>();

bool GameOver = false;
HANDLE cHandle;
HANDLE hMutex;


int _tmain(int argc, _TCHAR* argv[])
{
	system("color 8A");
	system("title 贪吃蛇");
	system("mode con cols=100 lines=30");

	cHandle = GetStdHandle(STD_OUTPUT_HANDLE);

	HANDLE hThread1;
	//HANDLE hThread2;

	//hThread2 = CreateThread(NULL,0,FrameFunc,NULL,0,NULL);
	hThread1 = CreateThread(NULL,0,RePaint,NULL,0,NULL);
	CloseHandle(hThread1);

	hMutex = CreateMutex(NULL, TRUE, L"Snake");
	if (hMutex)
	{
			if (ERROR_ALREADY_EXISTS == GetLastError())
			{
					cout <<"only one instance can run!" << endl;
					return 0;
			}
	}

	//CloseHandle(hThread2);
	char   ch;
	//初始化身体(尾巴);
	for (int i = 0; i != bodys->size(); ++i)
	{
		SnakeTail *st = new SnakeTail(SnakeX, SnakeY + i + 1, 0);
		(*bodys)[i] = st;
	}

	while   (!GameOver)     
	{   
		ReleaseMutex(hMutex);
		WaitForSingleObject(hMutex,INFINITE);
		Sleep(speed);
		if(kbhit())   
		{   
			ch   =   getch();   
			switch(ch)   
			{   
			case  'w':
				if (Direction != 0 && Direction != 1)
				{
					Direction = 0;
					SnakeVeerPoint *svp = new SnakeVeerPoint(SnakeX, SnakeY, Direction);
					veerPoints->push_back(svp);
				}
				break;   
			case  's':
				if (Direction != 1 && Direction != 0)
				{
					Direction = 1;
					SnakeVeerPoint *svp = new SnakeVeerPoint(SnakeX, SnakeY, Direction);
					veerPoints->push_back(svp);
				}
				break;   
			case  'a':
				if (Direction != 2 && Direction != 3)
				{
					Direction = 2;
					SnakeVeerPoint *svp = new SnakeVeerPoint(SnakeX, SnakeY, Direction);
					veerPoints->push_back(svp);
				}
				break;   
			case  'd':
				if (Direction != 3 && Direction != 2)
				{
					Direction = 3;
					SnakeVeerPoint *svp = new SnakeVeerPoint(SnakeX, SnakeY, Direction);
					veerPoints->push_back(svp);
				}
				break;
			default:
				break;
			}

			}
		switch (Direction)
		{
		case 0:
			if (SnakeY <= 0)
			{
				GameOver = true;
				break;
			}
			--SnakeY;
			break;
		case 1:
			if (SnakeY >=array_row)
			{
				GameOver = true;
				break;
			}
			++SnakeY;
			break;
		case 2:
			if (SnakeX <= 0)
			{
				GameOver = true;
				break;
			}
			--SnakeX;
			break;
		case  3:
			if (SnakeX >= array_col)
			{
				GameOver = true;
				break;
			}
			++SnakeX;
			break;
		default:
			break;
		}

		for (vector<SnakeTail*>::iterator i = bodys->begin(); i != bodys->end(); ++i)
		{
			if ((*i)->sp.x == SnakeX && (*i)->sp.y == SnakeY)
			{
				GameOver = true;
				break;
			}
			switch((*i)->Direction)
			{
			case 0:
				--((*i)->sp.y);
				break;
			case 1:
				++((*i)->sp.y);
				break;
			case 2:
				--((*i)->sp.x);
				break;
			case 3:
				++((*i)->sp.x);
				break;
			default:
				break;
			}
			for (vector<SnakeVeerPoint*>::iterator vi = veerPoints->begin(); vi != veerPoints->end(); ++vi)
			{
				if ((*vi)->sp.x == (*i)->sp.x && (*vi)->sp.y == (*i)->sp.y)
				{
					(*i)->Direction = (*vi)->Direction;
					++((*vi)->PassCount);
				}
				if ((*vi)->PassCount == bodys->size())
				{
					SnakeVeerPoint *psvp = *vi;
					vi = veerPoints->erase(vi);
					delete psvp;
					if (vi == veerPoints->end())
						break;
				}
				/* 另一个删除无用转向点的方法(暂时无效)
				SnakeTail *lastTail = (*bodys)[bodys->size()-1];
				if ((*vi)->sp.x == lastTail->sp.x && (*vi)->sp.y == lastTail->sp.y)
				{
					SnakeVeerPoint *svp = *vi;
					vi = veerPoints->erase(vi);
					delete svp;
				}
				*/
			}
		}


		//吃到食物检测
		for (vector<SnakePoint*>::iterator i = foodPoints->begin(); i != foodPoints->end();++i) 
		{
			if ((*i)->x == SnakeX && (*i)->y == SnakeY)
			{
				SnakeTail *st = new SnakeTail();
				SnakeTail *lastBody = 0;
				if (bodys->size() !=0)
				{
					SnakeTail *lastBody = (*bodys)[bodys->size()-1];
					switch(lastBody->Direction)
					{
					case 0:
						st->Direction = 0;
						st->sp.x = lastBody->sp.x;
						st->sp.y = lastBody->sp.y+1;
						break;
					case 1:
						st->Direction = 1;
						st->sp.x = lastBody->sp.x;
						st->sp.y = lastBody->sp.y-1;
						break;
					case 2:
						st->Direction = 2;
						st->sp.x = lastBody->sp.x+1;
						st->sp.y = lastBody->sp.y;
						break;
					case 3:
						st->Direction = 3;
						st->sp.x = lastBody->sp.x-1;
						st->sp.y = lastBody->sp.y;
						break;
					default:
						break;
					}
					bodys->push_back(st);
					SnakePoint *psp = *i;
					i = foodPoints->erase(i);
					delete psp;
					break;
				}
			}
		}
		
		//随机生成食物
		if (foodPoints->size() < 20)
		{
			srand((unsigned)time(NULL));
			int x = rand()%((48-2+1))+2;
			int y = rand()%((28-2+1))+2;
			bool isIncluded = false;
			for (vector<SnakePoint*>::iterator i = foodPoints->begin(); i != foodPoints->end();++i) 
			{
				if ((*i)->x == x && (*i)->y == y)
					isIncluded = true;
			}
			for (vector<SnakeTail*>::iterator i = bodys->begin(); i != bodys->end(); ++i)
			{
				if (!isIncluded && (*i)->sp.x == x && (*i)->sp.y == y)
					isIncluded = true;
			}
			if (!isIncluded)
			{
				SnakePoint *sp = new SnakePoint(x, y);
				foodPoints->push_back(sp);
			}
		}
		ReleaseMutex(hMutex);
	}
	return   0;  

}

void OutCharByPosition(string s, int x, int y)
{
	COORD setps;
	setps.X = x * 2;
	setps.Y = y;
	SetConsoleCursorPosition(cHandle, setps);

	cout << s << "";
}

DWORD WINAPI RePaint(PVOID pvParam)
{
	DWORD dwResult = 0;
	while(true)
	{
		system("cls");

		ReleaseMutex(hMutex);
		WaitForSingleObject(hMutex, INFINITE);

		for (vector<SnakePoint*>::iterator i = foodPoints->begin(); i != foodPoints->end(); ++i)
		{
			OutCharByPosition(strSnakeFood,(*i)->x,(*i)->y);
		}
		for (vector<SnakeTail*>::iterator i = bodys->begin(); i != bodys->end(); ++i)
		{
			OutCharByPosition(strSnakeTail, (*i)->sp.x, (*i)->sp.y);
		}
		OutCharByPosition(strSnakeHead, SnakeX, SnakeY);
		Sleep(speed);
		ReleaseMutex(hMutex);
	}
	return dwResult;
}

