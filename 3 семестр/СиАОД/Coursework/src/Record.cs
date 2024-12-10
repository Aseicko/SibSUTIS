using System;
using System.Text;

namespace DatabaseManagementSystem.src
{
    internal class Record
    {
        public int ID { get; }
        public byte[] FullName { get; set; }
        public byte[] StreetName { get; set; }
        public byte[] HouseNumber { get; set; }
        public byte[] ApartmentNumber { get; set; }
        public byte[] SettlementDate { get; set; }

        internal Record(int id)
        {
            ID = id;
            FullName = new byte[32];
            StreetName = new byte[18];
            HouseNumber = new byte[2];
            ApartmentNumber = new byte[2];
            SettlementDate = new byte[10];

        }

        internal void ParseBytes(byte[] dataToParse)
        {
            Array.Copy(dataToParse, 0, this.FullName, 0, 32);
            Array.Copy(dataToParse, 32, this.StreetName, 0, 18);
            Array.Copy(dataToParse, 50, this.HouseNumber, 0, 2);
            Array.Copy(dataToParse, 52, this.ApartmentNumber, 0, 2);
            Array.Copy(dataToParse, 54, this.SettlementDate, 0, 10);

        }

        public string ConvertBytesToString(byte[] dataToConvert)
        {
            return Encoding.GetEncoding(866).GetString(dataToConvert);
        }

        public string StrFullName => ConvertBytesToString(this.FullName);
        public string StrStreetName => ConvertBytesToString(this.StreetName);
        public string StrHouseNumber => BitConverter.ToInt16(this.HouseNumber, 0).ToString();
        public string StrApartmentNumber => BitConverter.ToInt16(this.ApartmentNumber, 0).ToString();
        public string StrSettlementDate => ConvertBytesToString(this.SettlementDate);

    }

}
