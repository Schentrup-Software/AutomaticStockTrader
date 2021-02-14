﻿using AutomaticStockTrader.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutomaticStockTrader.Core.Alpaca
{
    public interface IAlpacaClient : IDisposable
    {
        public Task<bool> ConnectStreamApis();
        public void AddPendingMinuteAggSubscription(string stockSymbol, Action<StockInput> action);
        public void SubscribeToMinuteAgg();
        public void SubscribeToTradeUpdates(Action<CompletedOrder> action);
        public Task PlaceOrder(StrategysStock postion, Order order);
        public Task EnsurePostionCleared(StrategysStock postion);
        public Task<decimal> GetTotalEquity();
        public Task<IList<StockInput>> GetStockData(string stockSymbol);
        public Task<DateTimeOffset> GetNextIncludedTimeUtc(DateTimeOffset timeUtc);
        public Task<bool> IsTimeIncluded(DateTimeOffset timeUtc);
    }
}
