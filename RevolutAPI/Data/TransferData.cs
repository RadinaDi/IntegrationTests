using RevolutAPI.Models;
using System;

namespace RevolutAPI.Data
{
    public static class TransferData
    {
        public static Transfer NewTransfer()
        {
            return new Transfer()
            {
                RequestId = Guid.NewGuid().ToString(),
            };
        }

        public static Transfer WithSourceAccountId(this Transfer transfer, string sourceAccountId)
        {
            transfer.SourceAccountId = sourceAccountId;
            return transfer;
        }

        public static Transfer WithTargetAccountId(this Transfer transfer, string targetAccountId)
        {
            transfer.TargetAccountId = targetAccountId;
            return transfer;
        }

        public static Transfer WithAmount(this Transfer transfer, int amount)
        {
            transfer.Amount = amount;
            return transfer;
        }
        public static Transfer WithCurrency(this Transfer transfer, string currency)
        {
            transfer.Currency = currency;
            return transfer;
        }
    }
}
