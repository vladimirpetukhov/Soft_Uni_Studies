// 3.GreetingbyName.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <string>
using namespace std;

int main()
{
	string name;
	
	
	getline(cin, name);
	cout << "Hello, " << name << "!" << endl;
    return 0;
}

