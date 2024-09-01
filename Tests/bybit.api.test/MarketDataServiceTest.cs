using bybit.net.api.ApiServiceImp;
using bybit.net.api.Models.Market;
using bybit.net.api.Models;
using System.Text.Json;
using Xunit;
using bybit.net.api;

namespace bybit.api.test
{
    public class MarketDataServiceTest
    {
        readonly BybitMarketDataService marketDataService = new(url: BybitConstants.HTTP_TESTNET_URL);
        #region Market Kline
        [Fact]
        public async Task CheckMarketKline_ResponseAsync()
        {
            GeneralResponse<MarketKLineResult>? klineInfoResponse = await marketDataService.GetMarketKline(category: Category.SPOT, symbol: "BTCUSDT", interval: MarketInterval.OneHour, start: 1693785600000, limit: 2);
            Assert.NotNull(klineInfoResponse);
            MarketKLineResult? klineInfo = klineInfoResponse.Result;

            Assert.Equal(0, klineInfoResponse.RetCode);
            Assert.Equal("OK", klineInfoResponse.RetMsg);
            Assert.NotNull(klineInfo?.MarketKlineEntries);
        }
        #endregion

        #region Market Tickers
        [Fact]
        public async Task CheckMarketTcikers_ResponseAsync()
        {
            var tickersInfoString = await marketDataService.GetMarketTickers(category: Category.SPOT);
            if (!string.IsNullOrEmpty(tickersInfoString))
            {
                Console.WriteLine(tickersInfoString);
                var generalResponse = JsonSerializer.Deserialize<GeneralResponse<MarketTickerResult>>(tickersInfoString);
                var tickersInfo = generalResponse?.Result;

                Assert.Equal(0, generalResponse?.RetCode);
                Assert.Equal("OK", generalResponse?.RetMsg);
                Assert.NotNull(tickersInfo?.MarketTickerInfoEntries);
            }
        }
        #endregion

        #region Funding Rate
        [Fact]
        public async Task CheckFundingRate_ResponseAsync()
        {
            var fundingInfoString = await marketDataService.GetMarketFundingHistory(category: Category.LINEAR, symbol: "BTCUSDT");
            if (!string.IsNullOrEmpty(fundingInfoString))
            {
                Console.WriteLine(fundingInfoString);
                var generalResponse = JsonSerializer.Deserialize<GeneralResponse<FundingRateResult>>(fundingInfoString);
                var fundingInfo = generalResponse?.Result;

                Assert.Equal(0, generalResponse?.RetCode);
                Assert.Equal("OK", generalResponse?.RetMsg);
                Assert.NotNull(fundingInfo?.FundingRateEntries);
                Assert.True(fundingInfo?.FundingRateEntries?.Count > 0);
            }
        }
        #endregion
    }
}
