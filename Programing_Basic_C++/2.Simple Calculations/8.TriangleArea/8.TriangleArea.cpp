// 8.TriangleArea.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include<iostream>
#include<iomanip>
#include <cmath>

using namespace std;

int main()
{
	double a;
	double h;

	cin >> a >> h;

	double area = (a*h) / 2;

	cout <<fixed<<setprecision(2)<< area << endl;
    return 0;
}

