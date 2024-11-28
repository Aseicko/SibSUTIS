#pragma once
#include <iostream>
#include <vector>
#include <iomanip>

using namespace std;

class Support
{
public:
	float CalculateEntropy(vector<pair<int, float>> arrData);
	float CalculateAverageLength(vector<pair<int, float>> arrData, int uniqueLetters, vector<string> arrCodes);
	bool CheckKraftInequality(vector<string> arrCodes);

	void Execute(vector<pair<int, float>> arrData, int uniqueLetters, vector<string> arrCodes)
	{
		float entropy = CalculateEntropy(arrData);
		float averageHeight = CalculateAverageLength(arrData, uniqueLetters, arrCodes);
		cout << " +------------------+------------------+------------------+------------------+ \n";
		cout << " | " << setw(16) << "Kraft Inequality"
			<< " | " << setw(16) << "Entropy"
			<< " | " << setw(16) << "Average Height"
			<< " | " << setw(16) << "Redundancy"
			<< " | \n";
		cout << " +------------------+------------------+------------------+------------------+ \n";
		cout << " | " << setw(16) << (CheckKraftInequality(arrCodes) ? "Yes" : "No")
			<< " | " << setw(16) << entropy
			<< " | " << setw(16) << averageHeight
			<< " | " << setw(16) << averageHeight - entropy
			<< " | \n";
		cout << " +------------------+------------------+------------------+------------------+ \n";
	}

};
