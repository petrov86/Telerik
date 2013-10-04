// Console.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <iomanip>
#include <windows.h>
using namespace std;
HANDLE hOut = GetStdHandle(STD_OUTPUT_HANDLE) ;

const int width = 5;

int pow(int x, int y)
{
	int result = x;
	if (y == 0) return 1;

	for (int i=0; i<y; i++)
	{
		result *= x; 
	}
	return result;

}

int Count(int arr[])
{
	int count = sizeof(arr)/sizeof(arr[0]);
	return count;	
}


int *Sort(int arr[], int lenght)
{
	int temp;
	for (int i = 0; i < lenght - 1; i++)
	{
		for (int j = i + 1; j < lenght; j++)
		{
			if (arr[j] < arr[i])
			{
				temp = arr[i];
				arr[i] = arr[j];
				arr[j] = temp;
			}
		}
	}
	return arr;
}

void PrintArray(int arr[], int lenght)
{
	for (int i = 0; i < lenght; i++)
	{
		cout << setw(width) << arr[i];
	}
	cout << endl;
}

int main()
{
	
	int arr[] = {3,2,1,0, -1000, 1000, 255, -255};
	int lenght = sizeof(arr)/sizeof(arr[0]);;
	int *a ;
	PrintArray(arr, lenght);
	a = Sort(arr, lenght);
	cout <<"The sorted array is" << endl;
	PrintArray(arr, lenght);
	

	return 0;
}
