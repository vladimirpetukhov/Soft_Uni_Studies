// 11.Speed Info.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <string>

using namespace std;

int main()
{
	int speed;
	cin >>  speed;
	bool slow_speed = speed <= 10;
	bool average_speed = speed > 10 && speed <= 50;
	bool fast_speed = speed > 50 && speed <= 150;
	bool ultra_speed = speed > 150 && speed <= 1000;
	bool extremaly_speed = speed > 1000;

	string result = "";

	if(slow_speed)
	{
		result = "slow";
	}
	if(average_speed)
	{
		result = "average";
	}
	if(fast_speed)
	{
		result = "fast";
	}
	if(ultra_speed)
	{
		result = "ultra fast";
	}
	if(extremaly_speed)
	{
		result = "extremely fast";
	}

	cout << result << endl;
    return 0;
}

