#include "Support.h"

float Support::CalculateEntropy(vector<pair<int, float>> arrData)
{
    float entropy = 0.0f;
    for (const auto& pair : arrData) {
        if (pair.second > 0) {
            entropy -= pair.second * log2(pair.second);
        }
    }
    return entropy;
}

float Support::CalculateAverageLength(vector<pair<int, float>> arrData, int uniqueLetters, vector<string> arrCodes)
{
    float averageLength = 0.0f;
    for (int i = 0; i < uniqueLetters; ++i) {
        averageLength += arrData[i].second * arrCodes[i].length();
    }
    return averageLength;
}

bool Support::CheckKraftInequality(vector<string> arrCodes)
{
    float sum = 0.0f;
    for (const auto& code : arrCodes) {
        sum += pow(2, -static_cast<double>(code.length()));
    }
    return sum <= 1.0f;
}
