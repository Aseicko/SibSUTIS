#include "EncoderHaffman.h"

void EncoderHaffman::ReadFile(string pathToFile)
{
	symbolFrequency.clear();
	ifstream reader;

	reader.open(pathToFile, ios::binary);

	if (reader.is_open())
	{
		string line;
		while (getline(reader, line))
		{
			for (char c : line)
			{
				auto it = find_if(symbolFrequency.begin(), symbolFrequency.end(),
					[c](const pair<int, float>& p) { return p.first == (unsigned char)c; });

				if (it != symbolFrequency.end()) {
					it->second++;
				}
				else {
					symbolFrequency.emplace_back((unsigned char)c, 1.0f);
					uniqueLetterCount++;
				}
				totalLetterCount++;

			}

		}

	}
	else
	{
		cerr << "Unable to open file!\n";

	}
	reader.close();

	for (auto& pair : symbolFrequency)
	{
		pair.second /= totalLetterCount;

	}

}

void EncoderHaffman::SortVector(vector<pair<int, float>>& vectorToSort)
{
	sort(vectorToSort.begin(), vectorToSort.end(),
		[](const pair<int, float>& a, const pair<int, float>& b) { return a.second > b.second; }
	);

}

void EncoderHaffman::GenerateCodes(int n)
{
	codes.resize(uniqueLetterCount);

	if (n == 2)
	{
		codes[0].push_back(0);
		codes[1].push_back(1);
	}
	else
	{
		float q = symbolFrequency[n - 1].second + symbolFrequency[n - 2].second;
		int j = Up(n, q);
		GenerateCodes(n - 1);
		Down(n, j);
	}

}

int EncoderHaffman::Up(int n, float q)
{
	int j = 0;
	for (int i = n - 1; i > 2; i--)
	{
		if (symbolFrequency[i - 1].second <= q) {
			symbolFrequency[i] = symbolFrequency[i - 1];
		}
		else {
			j = i;
			break;
		}
	}
	symbolFrequency[j].second = q;
	return j;
}

void EncoderHaffman::Down(int n, int j)
{
	vector<int> S = codes[j];

	for (int i = j; i < n - 2; i++) {
		codes[i] = codes[i + 1];
	}

	codes[n - 2] = S;
	codes[n - 1] = S;
	codes[n - 2].push_back(0);
	codes[n - 1].push_back(1);

}

void EncoderHaffman::Display() const
{
	string temp = " +------------+-------+--------------+------------------+ \n";

	cout << temp
		<< " | " << setw(10) << "Symbol"
		<< " | " << setw(5) << "Count"
		<< " | " << setw(12) << "Frequency"
		<< " | " << setw(16) << "Code"
		<< " | \n" << temp;

	int i = 0;
	for (const auto& pair : safeSymbolFrequency)
	{
		cout << " | " << setw(10);
		unsigned char currentChar = static_cast<unsigned char>(pair.first);

		if (currentChar == '\r')
		{
			cout << "Return";
		}
		else if (currentChar == '\n')
		{
			cout << "NewLine";
		}
		else if (currentChar == '\0')
		{
			cout << "EndLine";
		}
		else if (currentChar == '\t')
		{
			cout << "Tab";
		}
		else if (currentChar == ' ')
		{
			cout << "Space";
		}
		else if (currentChar == '\f')
		{
			cout << "FormFeed";
		}
		else if (currentChar == '\a')
		{
			cout << "beep";
		}
		else if (currentChar == '\u200B')
		{
			cout << "ZeroWS";
		}
		else if (currentChar == '\b')
		{
			cout << "DelNext";
		}
		else if (currentChar == '\x1B')
		{
			cout << "Escape";
		}
		else
		{
			cout << currentChar;
		}
		cout << " | " << setw(5) << (int)(ceil)(totalLetterCount * pair.second);
		cout << " | " << fixed << setprecision(8) << setw(12) << pair.second << " | ";
		for (int j = 0; j < codes[i].size(); j++) {
			cout << codes[i][j];
		}
		cout << setw(20 - codes[i].size()) << " | \n";
		i++;
	}

	cout << temp;
	cout << "Unique letters: " << uniqueLetterCount << endl;
	cout << "Total letters: " << totalLetterCount << endl;
}

void EncoderHaffman::EncodeText(string pathToFile)
{
	ifstream reader;
	reader.open(pathToFile);

	if (reader.is_open()) {
		string line = "", fullText = "", encodedText = "";

		while (getline(reader, line)) {
			fullText += line;
		}

		for (char c : fullText) {
			for (int i = 0; i < safeSymbolFrequency.size(); i++) {
				if ((uint8_t)c == safeSymbolFrequency[i].first) {
					encodedText += out[i];
					continue;
				}
			}
		}

		cout << "\nEncoded Text Length: " << encodedText.length() << " bit";
		cout << "\nOrigin  Text Length: " << fullText.length() * 8 << " bit";
		cout << "\nCompression Ratio: " << (float)fullText.length() * 8 / (float)encodedText.length();
		cout << "\nEncoded Text:\n" << encodedText << endl;

	}
	else {
		cerr << "Unable to open file!\n";
	}

	reader.close();
}