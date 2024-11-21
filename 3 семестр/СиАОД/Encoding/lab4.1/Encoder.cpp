#include "Encoder.h"

void Encoder::ReadFile(string pathToFile)
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

    clog << "File reading complete!\n";

}

void Encoder::SortVector(vector<pair<int, float>>& vectorToSort)
{
    sort(vectorToSort.begin(), vectorToSort.end(),
        [](const pair<int, float>& a, const pair<int, float>& b) { return a.second > b.second; }
    );

    clog << "Vector sorting complete!\n";

}

void Encoder::GenerateShannonCodes()
{
    vector<int> lengthCodeWords(uniqueLetterCount);
    codes.resize(uniqueLetterCount);

    float temp = 0.0f;

    for (int i = 0; i < uniqueLetterCount; ++i)
    {
        temp += symbolFrequency[i].second;

        lengthCodeWords[i] = static_cast<int>(ceil(-log2(symbolFrequency[i].second)));

        int codeValue = static_cast<int>(floor((temp - symbolFrequency[i].second) * (1 << lengthCodeWords[i])));

        string code;
        for (int j = lengthCodeWords[i] - 1; j >= 0; j--)
        {
            code += (codeValue & (1 << j)) ? '1' : '0';
        }

        codes[i] = code;
    }

    clog << "Generating Shannon code complete!\n";

}

void Encoder::Display() const
{
    string temp = " +---------+--------------+------------------+ \n";

    cout << temp
        << " | " << setw(7) << "Symbol"
        << " | " << setw(12) << "Frequency"
        << " | " << setw(16) << "Code"
        << " | \n" << temp;
    int i = 0;
    for (const auto& pair : symbolFrequency)
    {
        cout << " | " << setw(7);
        if ((unsigned char)(pair.first) == '\15')
        {
            cout << "EndLine";
        }
        else if ((unsigned char)(pair.first) == ' ')
        {
            cout << "Space";
        }
        else
        {
            cout << (unsigned char)(pair.first);
        }
        cout << " | " << fixed << setprecision(8) << setw(12) << pair.second << " | ";
        cout << setw(16) << codes[i++] << " | \n";
    }
    cout << temp;

    cout << "Unique letters: " << uniqueLetterCount << endl;
    cout << "Total  letters: " << totalLetterCount << endl;
}
