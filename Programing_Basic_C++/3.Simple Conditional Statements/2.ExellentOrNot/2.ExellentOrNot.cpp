#include "stdafx.h"

#include <iostream>

using namespace std;


int main()
{
	int digit;
	cin >> digit;
	if (digit %2==0)
	{
		cout << "even" << endl;
	}
	else
	{
		cout << "odd" << endl;
	}
	return 0;
}