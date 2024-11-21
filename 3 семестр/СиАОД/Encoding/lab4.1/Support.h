#pragma once
#include <iostream>
#include <vector>

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

		cout << "\nKraft Inequality: " << (CheckKraftInequality(arrCodes) ? "Yes" : "No");
		cout << "\nEntropy: " << entropy;
		cout << "\nAverage Height: " << averageHeight;
		cout << "\nRedundancy: " << averageHeight - entropy;
		cout << endl;

	}

};
