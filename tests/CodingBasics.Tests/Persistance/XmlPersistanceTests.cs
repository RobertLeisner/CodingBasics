// Copyright (c) Bodoconsult EDV-Dienstleistungen. All rights reserved.

using System.Diagnostics;
using CodingBasics.Persistance;
using CodingBasics.Persistance.Model;

namespace CodingBasics.Tests.Persistance;

[TestFixture]
public class XmlPersistanceTests
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
        var serializedResult = XmlHelper.Serialize(accounStatement);

        // Assert
        Assert.That(serializedResult, Is.Not.Null);

        Debug.Print(serializedResult);

        /* Prints:

            <?xml version="1.0" encoding="utf-16"?>
            <AccountStatement xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
            <AccountStatementItems>
                <AccountStatementItem>
                <Date>2024-12-04T10:27:26.0817472+01:00</Date>
                <Amount>100.09</Amount>
                <Remark>InvNo R190100/24</Remark>
                </AccountStatementItem>
                <AccountStatementItem>
                <Date>2024-09-04T10:27:26.0818507+02:00</Date>
                <Amount>67.09</Amount>
                <Remark>Car fuel</Remark>
                </AccountStatementItem>
                <AccountStatementItem>
                <Date>2025-05-04T10:27:26.0818628+02:00</Date>
                <Amount>100.09</Amount>
                <Remark>InvNo R198999/24</Remark>
                </AccountStatementItem>
            </AccountStatementItems>
            </AccountStatement>

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

        var serializedResult = XmlHelper.Serialize(accountStatement);

        // Act  
        var deserializedResult = XmlHelper.Deserialize<AccountStatement>(serializedResult);

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

        var fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "XmlSample.xml");

        XmlHelper.SerializeToFile(accountStatement, fileName);


        // Act  
        var deserializedResult = XmlHelper.DeserializeFromFile<AccountStatement>(fileName);

        // Assert
        Assert.That(deserializedResult, Is.Not.Null);

        Assert.That(deserializedResult.AccountStatementItems.Count, Is.EqualTo(accountStatement.AccountStatementItems.Count));

    }
}