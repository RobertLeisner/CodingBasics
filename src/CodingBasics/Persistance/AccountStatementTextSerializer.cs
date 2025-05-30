// Copyright (c) Bodoconsult EDV-Dienstleistungen. All rights reserved.

using System.Text;
using CodingBasics.Persistance.Model;

namespace CodingBasics.Persistance
{

    /// <summary>
    /// Class to serialize account statements into CSF files
    /// </summary>
    public class AccountStatementTextSerializer
    {

        public char Delimiter { get; set; } = ',';


        /// <summary>
        /// Serialize an account statement
        /// </summary>
        /// <param name="accountStatement">Account statement to serialize</param>
        /// <returns>Serialized account statement</returns>
        public string Serialize(AccountStatement accountStatement)
        {
            var s = new StringBuilder();

            s.AppendLine($"Date{Delimiter}Amount{Delimiter}Remark"); // Header line

            foreach (var item in accountStatement.AccountStatementItems)
            {
                s.AppendLine($"{item.Date:yyyyMMdd}{Delimiter}{item.Amount:0.00}{Delimiter}{item.Remark}"); // Item line
            }

            return s.ToString();

        }


        /// <summary>
        /// Serialize a account statement into a CSV file
        /// </summary>
        /// <param name="accountStatement">Account statement to serialize</param>
        /// <param name="fileName">Full path to file to persist the account statement in</param>

        public void SerializeToFile(AccountStatement accountStatement, string fileName)
        {

            // No file name
            if (string.IsNullOrEmpty(fileName))
            {
                throw new FileNotFoundException("No valid file name was provided!");
            }

            // If the file already exists delete it
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            // Create the file content now
            var result = Serialize(accountStatement);

            // Save content to file
            File.WriteAllText(fileName, result);

        }


        /// <summary>
        /// Deserialize an object from a JSON file
        /// </summary>
        /// <param name="fileName">Full path to file to persist the account statement in</param>
        /// <returns>Deserialized account statement </returns>

        public AccountStatement DeserializeFromFile(string fileName)
        {

            // Check if the file exists
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException($"File {fileName} NOT found!");
            }

            // Read file
            var content = File.ReadAllText(fileName);

            // Deserialize content
            var accountStatement = Deserialize(content);

            return accountStatement;
        }

        /// <summary>
        /// Deserialize a serialized account statement
        /// </summary>
        /// <param name="content">Serialized account statement</param>
        /// <returns>Account statement</returns>
        /// <exception cref="Exception"></exception>
        public AccountStatement Deserialize(string content)
        {
            // Split file in lines
            var lines = content.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            // 
            var accountStatement = new AccountStatement();

            var lineNumber = 0;
            foreach (var line in lines)
            {
                // Skip the header
                if (lineNumber == 0)
                {
                    lineNumber++;
                    continue;
                }

                lineNumber++;

                // Split the line in items
                var items = line.Split(Delimiter, StringSplitOptions.RemoveEmptyEntries);

                if (items.Length < 3)
                {
                    throw new Exception($"Not enough items for an account statement item: {line}!");
                }

                var year = Convert.ToInt32(items[0].Substring(0, 4));
                var month = Convert.ToInt32(items[0].Substring(4, 2));
                var day = Convert.ToInt32(items[0].Substring(6, 2));

                var accountStatementItem = new AccountStatementItem
                {
                    Date = new DateTime(year, month, day),
                    Amount = Convert.ToSingle(items[1]),
                    Remark = items[2]
                };

                accountStatement.AccountStatementItems.Add(accountStatementItem);
            }

            return accountStatement;
        }
    }
}
