// 7.2DRectangleArea.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include<iostream>
#include<iomanip>
#include <cmath>

using namespace std;


int main()
{
	double x1, y1, x2, y2;
	cin >> x1 >> y1 >> x2 >> y2;

	double widht = abs(x2 - x1);
	double height = abs(y1 - y2);

	double area = height * widht;
	double perimeter = 2 * (height+widht);

	cout <<area <<  endl;
	cout <<perimeter << endl;
	
    return 0;
}

