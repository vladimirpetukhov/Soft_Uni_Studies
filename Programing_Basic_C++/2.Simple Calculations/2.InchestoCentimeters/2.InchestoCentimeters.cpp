// 2.InchestoCentimeters.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>

using namespace std;

int main()
{
	double inches;
	double centimeters;

	cin >> inches;

	centimeters = inches * 2.54;

	cout << centimeters << endl;
	return 0;
}

