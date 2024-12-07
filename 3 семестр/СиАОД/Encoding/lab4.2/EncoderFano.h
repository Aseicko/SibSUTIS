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
    void GenerateCodes(int(EncoderFano::*)(int, int));
    void HelperGenerateCodes(int borderLeft, int borderRight, int(EncoderFano::*)(int, int));
    int FindMedian(int borderLeft, int borderRight);
    int FindMedianA2(int borderLeft, int borderRight);

public:
    void Execute(string pathToFile)
    {
        setlocale(0, "");
        ReadFile(pathToFile);
        SortVector(symbolFrequency);

        Support sup;

        GenerateCodes(&EncoderFano::FindMedian);
        Display();
        cout << "\nDefault Find Median Algorithm\n:";
        sup.Execute(symbolFrequency, uniqueLetterCount, codes);

        GenerateCodes(&EncoderFano::FindMedianA2);
        cout << "\nOBS Tree A2 Find Median Algorithm\n:";
        sup.Execute(symbolFrequency, uniqueLetterCount, codes);

    }
    void EncodeText(string pathToFile);

};
