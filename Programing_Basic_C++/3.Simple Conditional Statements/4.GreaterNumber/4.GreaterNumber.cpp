// 4.GreaterNumber.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <algorithm>

using namespace std;

int main()
{
	int first, second;
	cin >> first >> second;
	cout << max(first,second)<<endl;
    return 0;
}

