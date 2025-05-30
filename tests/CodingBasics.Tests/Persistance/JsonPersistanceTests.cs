// Copyright (c) Bodoconsult EDV-Dienstleistungen. All rights reserved.

using System.Diagnostics;
using CodingBasics.Persistance;
using CodingBasics.Persistance.Model;

namespace CodingBasics.Tests.Persistance;

[TestFixture]
public class JsonPersistanceTests
{


    [Test]
    public void SerializeToPlainText()
    {
        // Arrange 
        var accounStatement = new AccountStatement();

        var item = new AccountStatementItem
        {
            Date = DateTime.Now,
            Amount = 100.09,
            Remark = "InvNo R190100/24"
        };

        accounStatement.AccountStatementItems.Add(item);

        item = new AccountStatementItem
        {
            Date = DateTime.Now.AddMonths(-3),
            Amount = 67.09,
            Remark = "Car fuel"
        };

        accounStatement.AccountStatementItems.Add(item);

        item = new AccountStatementItem
        {
            Date = DateTime.Now.AddMonths(5),
            Amount = 100.09,
            Remark = "InvNo R198999/24"
        };

        accounStatement.AccountStatementItems.Add(item);


        // Act  
        var serializedResult = JsonHelper.Serialize(accounStatement);

        // Assert
        Assert.That(serializedResult, Is.Not.Null);

        Debug.Print(serializedResult);

        /*
        
        {
          "AccountStatementItems": [
            {
              "Date": "2024-12-04T14:57:58.1721273+01:00",
              "Amount": 100.09,
              "Remark": "InvNo R190100/24"
            },
            {
              "Date": "2024-09-04T14:57:58.1722888+02:00",
              "Amount": 67.09,
              "Remark": "Car fuel"
            },
            {
              "Date": "2025-05-04T14:57:58.1722983+02:00",
              "Amount": 100.09,
              "Remark": "InvNo R198999/24"
            }
          ]
        }

         */
    }


    [Test]
    public void DeserializeFromPlainText()
    {
        // Arrange 
        var accountStatement = new AccountStatement();

        var item = new AccountStatementItem
        {
            Date = DateTime.Now,
            Amount = 100.09,
            Remark = "InvNo R190100/24"
        };

        accountStatement.AccountStatementItems.Add(item);

        item = new AccountStatementItem
        {
            Date = DateTime.Now.AddMonths(-3),
            Amount = 67.09,
            Remark = "Car fuel"
        };

        accountStatement.AccountStatementItems.Add(item);

        item = new AccountStatementItem
        {
            Date = DateTime.Now.AddMonths(5),
            Amount = 100.09,
            Remark = "InvNo R198999/24"
        };

        accountStatement.AccountStatementItems.Add(item);

        var serializedResult = JsonHelper.Serialize(accountStatement);

        // Act  
        var deserializedResult = JsonHelper.Deserialize<AccountStatement>(serializedResult);

        // Assert
        Assert.That(deserializedResult, Is.Not.Null);

        Assert.That(deserializedResult.AccountStatementItems.Count, Is.EqualTo(accountStatement.AccountStatementItems.Count));

    }

    [Test]
    public void SerializeToAndDeserializeFromPlainTextFile()
    {
        // Arrange 
        var accountStatement = new AccountStatement();

        var item = new AccountStatementItem
        {
            Date = DateTime.Now,
            Amount = 100.09,
            Remark = "InvNo R190100/24"
        };

        accountStatement.AccountStatementItems.Add(item);

        item = new AccountStatementItem
        {
            Date = DateTime.Now.AddMonths(-3),
            Amount = 67.09,
            Remark = "Car fuel"
        };

        accountStatement.AccountStatementItems.Add(item);

        item = new AccountStatementItem
        {
            Date = DateTime.Now.AddMonths(5),
            Amount = 100.09,
            Remark = "InvNo R198999/24"
        };

        accountStatement.AccountStatementItems.Add(item);

        var fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "JsonSample.json");

        JsonHelper.SerializeToFile(accountStatement, fileName);


        // Act  
        var deserializedResult = JsonHelper.DeserializeFromFile<AccountStatement>(fileName);

        // Assert
        Assert.That(deserializedResult, Is.Not.Null);

        Assert.That(deserializedResult.AccountStatementItems.Count, Is.EqualTo(accountStatement.AccountStatementItems.Count));

    }
}