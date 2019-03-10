using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DataFileReader
{
    /// <summary>
    /// A file reader class. Reads a data file that contains one number
    /// on each row. That data is then stored in a list. The class also includes
    /// methods to compute the sum, average, and standard deviation of the numbers 
    /// in the file. Finally, the class contains a method to present the file content
    /// on the screen.
    /// </summary>
    public class FileReader
    {
        private readonly string _filePath;
        private List<double> _inputNums;

        public FileReader(string filePath)
        {
            _filePath = filePath;
        }

        /// <summary>
        /// Reads a file from a file path and returns a list with the lines
        /// of the file
        /// </summary>
        /// <returns>The list of lines as strings, null if an error occured.</returns>
        /// <param name="filePath">File path.</param>
        private string[] GetListNums(string filePath)
        {
            try
            {
                return File.ReadAllLines(@filePath, Encoding.UTF8);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Builds a list of numbers from an array of strings. If one or more of the entries
        /// is invalid, the function returns null.
        /// </summary>
        /// <returns>The list of numbers, null if an error occured.</returns>
        /// <param name="lines">Lines.</param>
        private List<double> BuildListNumbers(string[] lines)
        {
            try
            {
                if (lines == null || lines.Length == 0)
                    return null;

                List<double> listNums = new List<double>();

                foreach (var line in lines)
                {
                    var num = double.Parse(line);
                    listNums.Add(num);
                }
                return listNums;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Sets the list of numbers.  
        /// </summary>
        /// <returns><c>true</c>, if list numbers was set, <c>false</c> otherwise.</returns>
        public bool SetListNumbers()
        {
            try
            {
                var lines = GetListNums(_filePath);
                _inputNums = BuildListNumbers(lines);

                return (_inputNums != null);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Computes the sum of a list of numbers.
        /// </summary>
        /// <returns>The sum.</returns>
        public double Sum()
        {
            return _inputNums.Sum();
        }

        /// <summary>
        /// Computes the average of a list of numbers.
        /// </summary>
        /// <returns>The average.</returns>
        public double Average()
        {
            return _inputNums.Average();
        }

        /// <summary>
        /// Compute the standard deviation of a list of numbers.
        /// </summary>
        /// <returns>The std. dev.</returns>
        public double StdDev()
        {
            double result = 0;
            int count = _inputNums.Count;
            if (count > 1)
            {
                double avg = _inputNums.Average();
                double sum = _inputNums.Sum(d => Math.Pow(d - avg, 2));

                result = Math.Sqrt(sum / (count - 1));
            }
            return result;
        }

        /// <summary>
        /// Shows the file as a string.
        /// </summary>
        /// <returns>The file as a string.</returns>
        public string ShowFile()
        {
            StringBuilder sb = new StringBuilder("Row\tValue\n");

            for (int i = 0; i < _inputNums.Count - 1; i++)
            {
                sb.Append(string.Format("{0}\t{1}\n", i + 1, _inputNums[i]));
            }

            if (_inputNums.Count > 0)
                sb.Append(string.Format("{0}\t{1}", _inputNums.Count, _inputNums[_inputNums.Count - 1]));

            return sb.ToString();
        }
    }
}
