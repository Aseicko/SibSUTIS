#pragma once
#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include <iomanip>
#include <algorithm>

#include "Support.h"

using namespace std;

class Encoder
{
private:
    int uniqueLetterCount = 0;
    int totalLetterCount = 0;
    vector<pair<int, float>> symbolFrequency;
    vector<string> codes;

    void ReadFile(string pathToFile);
    void Display() const;
    void SortVector(vector<pair<int, float>>& vectorToSort);
    void GenerateShannonCodes();

public:
	void Execute()
	{
		setlocale(0, "");
		ReadFile("input.txt");
        SortVector(symbolFrequency);
        GenerateShannonCodes();
        Display();

        Support sup;
        sup.Execute(symbolFrequency, uniqueLetterCount, codes);

	}
    void EncodeText(string pathToFile);

};
