// 7.Sum Seconds.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <string>

using namespace std;

int main()
{
	int  first, second, third;

	cin >> first >> second >> third;

	int sum_seconds = first + second + third;
	int seconds = sum_seconds % 60;
	int minutes = sum_seconds / 60;
	

	string min_str,sec_str;

	if(seconds<10)
	{
		sec_str = "0" + to_string(seconds);
	}
	
	
	
	printf("%s:%s",min_str, sec_str);
	
    return 0;
}

