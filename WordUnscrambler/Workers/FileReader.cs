using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace WordUnscrambler.Workers
{
    public class FileReader
    {
        public string[] Read(string fName)
        {
            string[] contents;
            try
            {
                contents = File.ReadAllLines(fName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return contents;
        }
    }
}
