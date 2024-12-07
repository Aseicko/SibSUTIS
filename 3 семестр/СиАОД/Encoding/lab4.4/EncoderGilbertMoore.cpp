#include "EncoderGilbertMoore.h"

void EncoderGilbertMoore::ReadFile(string pathToFile)
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

void EncoderGilbertMoore::SortVector(vector<pair<int, float>>& vectorToSort)
{
    sort(vectorToSort.begin(), vectorToSort.end(),
        [](const pair<int, float>& a, const pair<int, float>& b) { return a.second > b.second; }
    );

    clog << "Vector sorting complete!\n";

}

void EncoderGilbertMoore::GenerateCodes()
{
    codes.clear();
    codes.resize(uniqueLetterCount);
    vector<double> Q(uniqueLetterCount);

    double pr = 0.0;
    for (int i = 0; i < uniqueLetterCount; ++i)
    {
        Q[i] = pr + symbolFrequency[i].second / 2.0;
        pr += symbolFrequency[i].second;

        int lengthCodeWords = static_cast<int>(ceil(-log2(symbolFrequency[i].second))) + 1;
        for (int j = 0; j < lengthCodeWords; ++j)
        {
            Q[i] *= 2;
            codes[i] += to_string(static_cast<int>(floor(Q[i])));
            if (Q[i] >= 1)
            {
                Q[i] -= 1;
            }
        }
    }

    clog << "Generating Gilbert-Moore code complete!\n";
}

void EncoderGilbertMoore::Display() const
{
    string temp = " +------------+-------+--------------+------------------+ \n";

    cout << temp
        << " | " << setw(10) << "Symbol"
        << " | " << setw(5) << "Count"
        << " | " << setw(12) << "Frequency"
        << " | " << setw(16) << "Code"
        << " | \n" << temp;

    int i = 0;
    for (const auto& pair : symbolFrequency)
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
        cout << setw(16) << codes[i++] << " | \n";
    }

    cout << temp;
    cout << "Unique letters: " << uniqueLetterCount << endl;
    cout << "Total letters: " << totalLetterCount << endl;
}

void EncoderGilbertMoore::EncodeText(string pathToFile) {
    ifstream reader;
    reader.open(pathToFile);

    if (reader.is_open()) {
        string line = "", fullText = "", encodedText = "";

        while (getline(reader, line)) {
            fullText += line;
        }

        for (char c : fullText) {
            for (int i = 0; i < symbolFrequency.size(); i++) {
                if ((uint8_t)c == symbolFrequency[i].first) {
                    encodedText += codes[i];
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
