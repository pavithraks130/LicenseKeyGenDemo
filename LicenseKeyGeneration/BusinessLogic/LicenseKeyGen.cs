using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace LicenseKeyGeneration.BusinessLogic
{
    class LicenseKeyGen
    {
        public string ExpireDateTimestamp { get; set; }
        public string ProductCode { get; set; }

        public string GenerateLicenseKey()
        {
            //string processId = string.Empty, motherBoard = string.Empty, volumeSerial = string.Empty;
            //var mos = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
            //var proDetails = mos.Get();
            //foreach (ManagementObject o in proDetails)
            //    processId = o.Properties["ProcessorId"].Value.ToString();

            //mos = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
            //var moc = mos.Get();
            //foreach (ManagementObject mo in moc)
            //    motherBoard = (string)mo["SerialNumber"];
            //try
            //{
            //    var _id = string.Concat("LicenceModule", processId, motherBoard);
            //    var _byteIds = Encoding.UTF8.GetBytes(_id);

            //    //Use MD5 to get the fixed length checksum of the ID string
            //    var _md5 = new MD5CryptoServiceProvider();
            //    var _checksum = _md5.ComputeHash(_byteIds);

            //    //Convert checksum into 4 ulong parts and use BASE36 to encode both
            //    var _part1Id = Base36.Encode(BitConverter.ToUInt32(_checksum, 0));
            //    var _part2Id = Base36.Encode(BitConverter.ToUInt32(_checksum, 4));
            //    var _part3Id = Base36.Encode(BitConverter.ToUInt32(_checksum, 8));
            //    var _part4Id = Base36.Encode(BitConverter.ToUInt32(_checksum, 12));

            //    //Concat these 4 part into one string
            //    return string.Format("{0}-{1}-{2}-{3}", _part1Id, _part2Id, _part3Id, _part4Id);
            //}
            //catch (Exception ex)
            //{
            //    //ErrorMessage = ex.Message;
            //}
            //return null;
            string licenseDelimiter = "-";

            string data = String.Concat("CalLicense_", ProductCode, "_", ExpireDateTimestamp);
            byte[] convertedData = System.Text.ASCIIEncoding.UTF8.GetBytes(data);

            var _md5 = new MD5CryptoServiceProvider();
            var _checksum = _md5.ComputeHash(convertedData);


            var part1 = Base36.Encode(BitConverter.ToUInt64(_checksum, 0));
            var part2 = Base36.Encode(BitConverter.ToUInt64(_checksum, 8));


            return string.Concat(part1, "-", part2, "-", part3, "-", part4);
        }

        public string GetLicensedata(string licKey)
        {
            string[] licenceSection = licKey.Split('-');
            byte[] byteData = new byte[16];
            foreach (string str in licenceSection)
            {
                var data = BitConverter.GetBytes(Base36.Decode(str));
            }
            return null;
        }
    }
}

