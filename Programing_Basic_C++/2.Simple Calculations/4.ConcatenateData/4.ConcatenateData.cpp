// 4.ConcatenateData.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <string>
#include <stdio.h>
using namespace std;

int main()
{
	string first_name,last_name,town;
	int age;
	cin >> first_name >>last_name >>age >>town;
	printf("You are %s %s, a %d-years old person from %s.", 
		first_name.c_str(),last_name.c_str(),age,town.c_str());

	
	return 0;
}

