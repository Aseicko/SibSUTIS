#pragma once
#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include <iomanip>
#include <algorithm>
#include <sstream>

#include "Support.h"

using namespace std;

class EncoderHaffman
{
private:
	int uniqueLetterCount = 0;
	int totalLetterCount = 0;
	vector<pair<int, float>> symbolFrequency;
	vector<pair<int, float>> safeSymbolFrequency;
	vector<vector<int>> codes;

	vector<string> out;

	void ReadFile(string pathToFile);
	void Display() const;
	void SortVector(vector<pair<int, float>>& vectorToSort);
	void GenerateCodes(int n);
	int Up(int n, float q);
	void Down(int n, int j);

public:
	void Execute(string file)
	{
		setlocale(0, "");
		ReadFile(file);
		SortVector(symbolFrequency);
		safeSymbolFrequency = symbolFrequency;
		GenerateCodes(uniqueLetterCount);
		clog << "Generating Haffman code complete!\n";
		Display();

		Support sup;

		for (int i = 0; i < codes.size(); i++) {
			stringstream code;
			for (int j = 0; j < codes[i].size(); j++) {
				code << codes[i][j];
			}
			out.push_back(code.str());
		}

		sup.Execute(safeSymbolFrequency, uniqueLetterCount, out);

	}

	void EncodeText(string pathToFile);

};
