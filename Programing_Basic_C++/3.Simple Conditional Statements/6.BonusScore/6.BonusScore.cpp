// 6.BonusScore.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>

using namespace std;

int main()
{
	int digit;
	double bonus_points=0;

	
	cin >> digit;
	int last = digit % 10;
	if(digit<=100)
	{
		bonus_points += 5;
	}
	if(digit>100 && digit<1000)
	{
		bonus_points += digit * 0.20;
	}
	if(digit>1000)
	{
		bonus_points += digit * 0.10;
	}
	if(digit%2==0)
	{
		bonus_points += 1;
	}
	if(last==5)
	{
		bonus_points += 2;
	}

	cout << bonus_points << endl << bonus_points + digit << endl;
    return 0;
}

