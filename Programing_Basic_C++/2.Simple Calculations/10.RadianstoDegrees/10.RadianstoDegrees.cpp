// 10.RadianstoDegrees.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include<iostream>
#include<iomanip>
#include <cmath>

using namespace std;

int main()
{
	const double grad = 57.2957;
	double radians;
	cin >> radians;

	cout << radians * grad;

    return 0;
}

