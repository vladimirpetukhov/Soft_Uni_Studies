// 6.CircleAreaandPerimeter.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <iomanip>

using namespace std;

int main()
{
	const double pi = 3.14159265359;
	double radius;
	cin >> radius;

	double perimeter = 2 * pi*radius;
	double area = pi * radius*radius;

	cout <<area << endl;
	cout << perimeter << endl;

    return 0;
}

