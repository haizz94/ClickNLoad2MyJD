using System;
using System.IO;
using System.IO.IsolatedStorage;

namespace ClickNLoad2MyJD
{
    public static class Config
    {
        const string FILE_NAME = "ClickNLoad2MyJD.cfg";
        const string MYJD_MAIL = "MYJD_MAIL";
        const string MYJD_PASS = "MYJD_PASS";

        public static void DeleteConfiguration(){
            using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Domain | IsolatedStorageScope.Assembly, null, null))
            {
                if(isoStore.FileExists(FILE_NAME)){
                    isoStore.DeleteFile(FILE_NAME);
                }
            }
        }

        public static (string Mail, string Password) GetOrAskForMyJdownloaderCredentials()
        {
            (string Mail, string Password) credentials = (string.Empty, string.Empty);
            using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Domain | IsolatedStorageScope.Assembly, null, null))
            {
                if(isoStore.FileExists(FILE_NAME)){
                    Console.WriteLine("Reading MyJDownloader account credentials from configuration...");
                    using (var configFile = isoStore.OpenFile(FILE_NAME, FileMode.Open)){
                        using (StreamReader streamReader = new StreamReader(configFile))
                        {
                            var line = streamReader.ReadLine();
                            while (line != null)
                            {
                                var lineSplit = line.Split('=');
                                if(lineSplit.Length > 1){
                                    if(lineSplit[0].Equals(MYJD_MAIL)){
                                        credentials.Mail = lineSplit[1];
                                    }
                                    else if (lineSplit[0].Equals(MYJD_PASS)){
                                        credentials.Password = lineSplit[1];
                                    }
                                }
                                line = streamReader.ReadLine();
                            }
                        }
                    }
                }
                else{
                    Console.WriteLine("It seems to be the first start of the application. You have to enter your MyJDownloader credentials");
                    Console.WriteLine("Please enter your MyJDownloader account mail address:");
                    credentials.Mail = Console.ReadLine();
                    Console.WriteLine("Please enter your MyJDownloader account password:");
                    credentials.Password = Console.ReadLine();
                    
                    using (var configFile = isoStore.OpenFile(FILE_NAME, FileMode.CreateNew)){
                        using (StreamWriter streamWriter = new StreamWriter(configFile))
                        {
                            string[] lines = { $"{MYJD_MAIL}={credentials.Mail}", $"{MYJD_PASS}={credentials.Password}" };
                            foreach (string line in lines)
                                streamWriter.WriteLine(line);
                        }
                    }
                    Console.WriteLine("Successfully saved MyJDownloader account credentials");
                }
            }
            return credentials;
        }

    }
}