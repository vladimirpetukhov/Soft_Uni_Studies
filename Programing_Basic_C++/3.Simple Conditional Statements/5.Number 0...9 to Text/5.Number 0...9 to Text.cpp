// 5.Number 0...9 to Text.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <map>
#include <string>

using namespace std;

int main()
{
	int digit;
	cin >> digit;
	map<int, string> words = {
		{1,"one"},
		{2,"two"},
		{3,"three"},
		{4,"four"},
		{5,"five"},
		{6,"six"},
		{7,"seven"},
		{8,"eight"},
		{9,"nine"}

	};
	if(digit>9)
	{
		cout << "number too big" << endl;
	}
	else
	{
		cout << words[digit] << endl;
	}
	
	return 0;
}

