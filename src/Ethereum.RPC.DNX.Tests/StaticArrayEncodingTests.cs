using System;
using System.Collections;
using System.Numerics;
using Ethereum.RPC.ABI;
using Ethereum.RPC.Util;
using Xunit;

namespace Ethereum.ABI.Tests.DNX
{
    public class StaticArrayEncodingTests
    {
        [Fact]
        public virtual void ShouldEncodeStaticIntArray()
        {
            //Given
            var array = new uint[20];
            for (uint i = 0; i < 20; i++)
            {
                array[i] = i + 234567;
            }

            var arrayType = ArrayType.CreateABIType("uint[20]");
            
            //when
            var result = arrayType.Encode(array).ToHexString();
            
            //then
            var expected = "000000000000000000000000000000000000000000000000000000000003944700000000000000000000000000000000000000000000000000000000000394480000000000000000000000000000000000000000000000000000000000039449000000000000000000000000000000000000000000000000000000000003944a000000000000000000000000000000000000000000000000000000000003944b000000000000000000000000000000000000000000000000000000000003944c000000000000000000000000000000000000000000000000000000000003944d000000000000000000000000000000000000000000000000000000000003944e000000000000000000000000000000000000000000000000000000000003944f0000000000000000000000000000000000000000000000000000000000039450000000000000000000000000000000000000000000000000000000000003945100000000000000000000000000000000000000000000000000000000000394520000000000000000000000000000000000000000000000000000000000039453000000000000000000000000000000000000000000000000000000000003945400000000000000000000000000000000000000000000000000000000000394550000000000000000000000000000000000000000000000000000000000039456000000000000000000000000000000000000000000000000000000000003945700000000000000000000000000000000000000000000000000000000000394580000000000000000000000000000000000000000000000000000000000039459000000000000000000000000000000000000000000000000000000000003945a";

            Assert.Equal(expected, result);
        }

        [Fact]
        public virtual void ShouldDecodeStaticIntArray()
        {
            //Given
          
            var given = "000000000000000000000000000000000000000000000000000000000003944700000000000000000000000000000000000000000000000000000000000394480000000000000000000000000000000000000000000000000000000000039449000000000000000000000000000000000000000000000000000000000003944a000000000000000000000000000000000000000000000000000000000003944b000000000000000000000000000000000000000000000000000000000003944c000000000000000000000000000000000000000000000000000000000003944d000000000000000000000000000000000000000000000000000000000003944e000000000000000000000000000000000000000000000000000000000003944f0000000000000000000000000000000000000000000000000000000000039450000000000000000000000000000000000000000000000000000000000003945100000000000000000000000000000000000000000000000000000000000394520000000000000000000000000000000000000000000000000000000000039453000000000000000000000000000000000000000000000000000000000003945400000000000000000000000000000000000000000000000000000000000394550000000000000000000000000000000000000000000000000000000000039456000000000000000000000000000000000000000000000000000000000003945700000000000000000000000000000000000000000000000000000000000394580000000000000000000000000000000000000000000000000000000000039459000000000000000000000000000000000000000000000000000000000003945a";

            var arrayType = ArrayType.CreateABIType("uint[20]");

            //when
            var result = arrayType.DecodeString(given);

            //then
            var list = result as IList;

          
            if (list != null)
            {
                Assert.Equal(20, list.Count);

                for (int i = 0; i < list.Count; i++)
                {
                    Assert.Equal(new BigInteger(i+ 234567), (BigInteger)list[i]);
                }
            }
            else
            {
                throw new Exception("Expected to return IList object when decoding array");
            }
        }

    }
}