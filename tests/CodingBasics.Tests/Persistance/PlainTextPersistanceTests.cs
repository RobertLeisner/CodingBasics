// Copyright (c) Bodoconsult EDV-Dienstleistungen. All rights reserved.

using System.Diagnostics;
using CodingBasics.Persistance;
using CodingBasics.Persistance.Model;

namespace CodingBasics.Tests.Persistance;

[TestFixture]
public class PlainTextPersistanceTests
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

        var serializer = new AccountStatementTextSerializer();


        // Act  
        var serializedResult = serializer.Serialize(accounStatement);

        // Assert
        Assert.That(serializedResult, Is.Not.Null);

        Debug.Print(serializedResult);

        /* Prints:

        Date,Amount,Remark
        20241204,100,09,InvNo R190100/24
        20240904,67,09,Car fuel
        20250504,100,09,InvNo R198999/24

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

        var serializer = new AccountStatementTextSerializer();

        var serializedResult = serializer.Serialize(accountStatement);


        // Act  
        var deserializedResult = serializer.Deserialize(serializedResult);

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

        var fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "PlainTextSample.csv");

        var serializer = new AccountStatementTextSerializer();

        serializer.SerializeToFile(accountStatement, fileName);


        // Act  
        var deserializedResult = serializer.DeserializeFromFile(fileName);

        // Assert
        Assert.That(deserializedResult, Is.Not.Null);

        Assert.That(deserializedResult.AccountStatementItems.Count, Is.EqualTo(accountStatement.AccountStatementItems.Count));

    }
}