// 11.USDtoBGN.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include<iostream>
#include<iomanip>

using namespace std;

int main()
{
	double usd = 1.79549;
	double leva;
	cin >> leva;

	cout <<fixed<< setprecision(2) << leva * usd;

    return 0;
}

