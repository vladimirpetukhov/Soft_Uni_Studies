// 10.Number 100...200.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <string>
using namespace std;

int main()
{
	const string Less_than_100 = "Less than 100";
	const string Between_100_and_200 = "Between 100 and 200";
	const string Greater_than_200 = "Greater than 200";
	string result = "";
	int number;
	cin >> number;
	
	if(number<100)
	{
		result = Less_than_100;
	}
	if(number>=100 && number<=200)
	{
		result = Between_100_and_200;
	}
	if(number>200)
	{
		result = Greater_than_200;
	}

	cout <<result<<endl;
    return 0;
}

