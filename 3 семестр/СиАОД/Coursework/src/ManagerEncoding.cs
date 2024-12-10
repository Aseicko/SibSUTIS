using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

internal class ManagerEncoding
{
    private int UniqueLetterCount = 0;
    private int TotalLetterCount = 0;
    internal readonly Dictionary<int, SymbolInfo> SymbolData = new Dictionary<int, SymbolInfo>();

    internal byte[] textFull;
    internal byte[] textEncoded;

    internal class SymbolInfo
    {
        public int Byte { get; set; }
        public int Count { get; set; }
        public float Frequency { get; set; }
        public string Code { get; set; }
    }

    private static readonly Dictionary<char, string> SpecialChars = new Dictionary<char, string>
    {
        { '\r', "Return" },
        { '\n', "NewLine" },
        { '\0', "EndLine" },
        { '\t', "Tab" },
        { ' ', "Space" },
        { '\f', "FormFeed" },
        { '\a', "beep" },
        { '\b', "DelNext" },
        { '\x1B', "Escape" }
    };

    internal void ReadFromFile(string pathToFile)
    {
        if (!File.Exists(pathToFile))
        {
            MessageBox.Show("File does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        using (FileStream fs = new FileStream(pathToFile, FileMode.Open, FileAccess.Read))
        {
            int byteRead;
            while ((byteRead = fs.ReadByte()) != -1)
            {
                if (SymbolData.ContainsKey(byteRead))
                {
                    SymbolData[byteRead].Count++;
                }
                else
                {
                    SymbolData[byteRead] = new SymbolInfo
                    {
                        Byte = byteRead,
                        Count = 1,
                        Frequency = 0f,
                        Code = ""
                    };
                    UniqueLetterCount++;
                }
                TotalLetterCount++;
            }
        }

        foreach (var symbol in SymbolData.Values)
        {
            symbol.Frequency = (float)symbol.Count / TotalLetterCount;
        }
    }

    internal void GenerateCodes()
    {
        List<SymbolInfo> sortedSymbols = SymbolData.Values.OrderByDescending(s => s.Frequency).ToList();

        List<double> listFrequencys = new List<double>(new double[UniqueLetterCount]);
        double pr = 0.0;

        for (int i = 0; i < UniqueLetterCount; i++)
        {
            listFrequencys[i] = pr + sortedSymbols[i].Frequency / 2.0;
            pr += sortedSymbols[i].Frequency;

            int lengthCodeWords = (int)(Math.Ceiling(-Math.Log(sortedSymbols[i].Frequency, 2)) + 1);
            string code = "";
            int bit;

            for (int j = 0; j < lengthCodeWords; j++)
            {
                listFrequencys[i] *= 2;
                bit = (int)Math.Floor(listFrequencys[i]);
                code += bit.ToString();

                if (listFrequencys[i] >= 1)
                {
                    listFrequencys[i] -= 1;
                }
            }

            sortedSymbols[i].Code = code;
        }

    }

    internal void DisplayToGrid(DataGridView gridToDisplay)
    {
        List<SymbolInfo> sortedSymbols = SymbolData.Values.OrderByDescending(s => s.Frequency).ToList();

        gridToDisplay.Rows.Clear();
        foreach (var item in sortedSymbols)
        {
            gridToDisplay.Rows.Add
            (
                ParseCharacters(new byte[] { (byte)item.Byte }),
                Math.Round(item.Frequency, 5),
                item.Code,
                item.Code.Length
            );
        }

        gridToDisplay.ClearSelection();
    }

    private string ParseCharacters(byte[] dataToConvert)
    {
        string convertedString = Encoding.GetEncoding(866).GetString(dataToConvert);

        string result = string.Empty;

        foreach (char currentChar in convertedString)
        {
            if (SpecialChars.TryGetValue(currentChar, out string replacement))
            {
                result += replacement;
            }
            else
            {
                result += currentChar;
            }
        }

        return result;
    }

    internal double CalculateEntropy()
    {
        double entropy = 0.0;
        foreach (var item in SymbolData)
        {
            entropy -= item.Value.Frequency * Math.Log(item.Value.Frequency, 2);
        }
        return entropy;
    }

    internal double CalculateAverageHeight()
    {
        double averageHeight = 0.0;
        foreach (var item in SymbolData)
        {
            averageHeight += item.Value.Frequency * item.Value.Code.Length;
        }
        return averageHeight;
    }

    internal bool CheckKraftInequality()
    {
        double sum = 0.0;
        foreach (var item in SymbolData)
        {
            sum += Math.Pow(2, -item.Value.Code.Length);
        }
        return sum <= 1.0;
    }

    internal void EncodeText(string pathToFile)
    {
        List<byte> textEncoded = new List<byte>();

        if (!File.Exists(pathToFile))
        {
            MessageBox.Show("File does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        using (FileStream fs = new FileStream(pathToFile, FileMode.Open, FileAccess.Read))
        {
            textFull = new byte[fs.Length];
            fs.Read(textFull, 0, (int)fs.Length);
        }


        foreach (byte b in textFull)
        {
            if (SymbolData.TryGetValue(b, out var symbolInfo))
            {
                foreach (char bit in symbolInfo.Code)
                {
                    textEncoded.Add((byte)(bit == '1' ? 1 : 0));
                }
            }
        }

        this.textEncoded = textEncoded.ToArray();

    }

}
