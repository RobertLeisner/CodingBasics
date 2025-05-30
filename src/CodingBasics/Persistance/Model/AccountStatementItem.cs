// Copyright (c) Bodoconsult EDV-Dienstleistungen. All rights reserved.

namespace CodingBasics.Persistance.Model
{
    /// <summary>
    ///  Account statement item
    /// </summary>
    public class AccountStatementItem
    {

        /// <summary>
        /// Date when the account item as received in the bank from account
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Amount
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// Remark
        /// </summary>
        public string Remark { get; set; }

    }
}
