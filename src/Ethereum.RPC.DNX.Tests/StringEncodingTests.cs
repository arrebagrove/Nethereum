using Ethereum.RPC.ABI;
using Ethereum.RPC.Util;
using Xunit;

namespace Ethereum.ABI.Tests.DNX
{
    public class StringEncodingTests
    {
        [Fact]
        public virtual void ShouldEncodeString()
        {
            var monkeyEncoded =
                "00000000000000000000000000000000000000000000000000000000000000064d6f6e6b65790000000000000000000000000000000000000000000000000000";

            //0000000000000000000000000000000000000000000000000000000000000006 is the bytes length
            //4d6f6e6b65790000000000000000000000000000000000000000000000000000 Monkey byte array utf8 encoded
            
            var stringType = new StringType();
            var result = stringType.Encode("Monkey").ToHexString();
            Assert.Equal(monkeyEncoded, result);
        }

        [Fact]
        public virtual void ShouldDecodeString()
        {
            var stringType = new StringType();
            var result = stringType.Encode("MonkeyMediumSizeString");
            Assert.Equal("MonkeyMediumSizeString", stringType.Decode(result));
        }

        [Fact]
        public virtual void ShouldDecodeLongString()
        {
            var stringType = new StringType();
            var longString = "MonkeyVeryLongStringmljalkdjflksjf lkdfjlsfjalkfjlsflskfjlsflsfjasdfjlsjflksfjlskjf fjlskfjlsjfs fkj lakdflsjfsa fafd sa";
            var result = stringType.Encode(longString);
            Assert.Equal(longString, stringType.Decode(result));
        }
    }
}