// Copyright (c) Bodoconsult EDV-Dienstleistungen. All rights reserved.

namespace CodingBasics.Persistance.Model;

/// <summary>
/// Data for an account statement
/// </summary>
public class AccountStatement
{
    /// <summary>
    /// All items in the current account statement
    /// </summary>
    public List<AccountStatementItem> AccountStatementItems { get; } = new();
}