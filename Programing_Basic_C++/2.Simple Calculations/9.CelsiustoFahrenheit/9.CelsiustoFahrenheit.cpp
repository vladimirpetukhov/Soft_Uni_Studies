// 9.CelsiustoFahrenheit.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include<iostream>
#include<iomanip>


using namespace std;

int main()
{
	double celsius;

	cin >> celsius;

	double fahrenh = celsius * 1.8 + 32;

	cout  << fahrenh;
    return 0;
}

