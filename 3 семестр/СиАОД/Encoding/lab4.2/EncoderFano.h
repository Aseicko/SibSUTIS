#pragma once
#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include <iomanip>
#include <algorithm>

#include "Support.h"

using namespace std;

class EncoderFano
{
private:
    int uniqueLetterCount = 0;
    int totalLetterCount = 0;
    vector<pair<int, float>> symbolFrequency;
    vector<string> codes;

    void ReadFile(string pathToFile);
    void Display() const;
    void SortVector(vector<pair<int, float>>& vectorToSort);
    void GenerateCodes();
    void HelperGenerateCodes(int borderLeft, int borderRight);
    int FindMedian(int borderLeft, int borderRight);

public:
    void Execute(string pathToFile)
    {
        setlocale(0, "");
        ReadFile(pathToFile);
        SortVector(symbolFrequency);
        GenerateCodes();
        Display();

        Support sup;
        sup.Execute(symbolFrequency, uniqueLetterCount, codes);

    }
    void EncodeText(string pathToFile);

};
