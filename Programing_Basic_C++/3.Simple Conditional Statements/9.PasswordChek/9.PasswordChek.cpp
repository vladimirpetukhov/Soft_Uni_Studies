// 9.PasswordChek.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <string>

using namespace std;

int main()
{
	const string PASSWORD = "s3cr3t!P@ssw0rd";
	string pasword;
	cin >> pasword;

	if(pasword==PASSWORD)
	{
		cout << "Welcome" << endl;
	}
	else
	{
		cout << "Wrong password!" << endl;
	}
    return 0;
}

