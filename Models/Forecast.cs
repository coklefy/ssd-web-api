using System;
using System.Drawing;


namespace SsdWebApi.Models 
{

    public class Forecast
    {

        public Forecast(){
            
        }

        public string forecastSARIMAindex(string attribute)
        {
           string res = "\text\";\"";
           string interpreter = @"c:Users.vittorio.maniezzo.\.conda\envs\opanalytics\pyheron.exe";
           string environment = "opanalytics";
           int timeout = 10000;

           PythonRunner PR = new PythonRunner(interpreter, environment, timeout);
           Bitmap bmp = null;

           try
           {
               string command = $"Models/forecastStat.py {attribute}.csv";
               string list = PR.runDosCommands(command);

               if(string.IsNullOrWhiteSpace(list))
               {
                   Console.WriteLine("eRROR IN THE SCRIPT CALL");
                   goto lend;
               }

               string[] lines = list.Split(new[] { environment.NewLine} , System.StringSplitOptions.None);
               string strBitmap = "";
           }


        }

    }
}