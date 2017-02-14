using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LicenseKeyGeneration.BusinessLogic;

namespace LicenseKeyGeneration.ViewModel
{
    class MainViewModel
    {
        public string ProductCode { get; set; }
        public string ExpireDate { get; set; }
        public string ProductCodeExtracted { get; set; }
        public string ExpireDateExtracted { get; set; }

        public ICommand CreateLicenseKey { get; set; }
        public ICommand ExtractLicenseData { get; set; }

        public string LicenseKey { get; set; }


        public MainViewModel()
        {
            CreateLicenseKey = new RelayCommand(LicenseKeyGeneration, CanExcute);
            ExtractLicenseData = new RelayCommand(ExtractDataFromLicense, CanExcute);
        }


        public bool CanExcute(object parameter)
        {
            return true;
        }
        public void LicenseKeyGeneration(object param)
        {
            LicenseKeyGen keyGen = new LicenseKeyGen();
            keyGen.ProductCode = "PRO001";
            keyGen.ExpireDateTimestamp = DateTime.Now.Date.AddDays(30).ToShortDateString();
            LicenseKey= keyGen.GenerateLicenseKey();
        }

        public void ExtractDataFromLicense(object param)
        {
            LicenseKeyGen keyGen = new LicenseKeyGen();
            keyGen.GetLicensedata(LicenseKey);
        }
    }
}
