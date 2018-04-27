// 8.MetricConverter.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <string>
#include <map>
#include <iomanip>



using namespace std;


 float Convertor(float metric, float metric1, int number)
{
	float m = number / metric;
	float convert = m * metric1;

	return convert;
}

int main()
{
	map<string,float> metrics=
	{
	{"mm",1000},
	{"cm",100},
	{"mi",0.000621371192 },
	{"in",39.3700787 },
	{"km",0.001},
	{"ft",3.2808399 },
	{"yd",1.0936133 }
	
	};
	float number;
	float result;
	string firts_metric, second_metric;

	cin >> number >> firts_metric >> second_metric;

	result=Convertor(metrics[firts_metric],metrics[ second_metric], number);
	cout <<fixed<<setprecision(8) <<result << endl;
    return 0;
}

 

