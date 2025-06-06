﻿//-----------------------------------------------------------------------------
// Filename: TypeExtensionsUnitTest.cs
//
// Description: Unit tests for methods in the TypeExtensions class.
//
// Author(s):
// Aaron Clauson (aaron@sipsorcery.com)
// 
// History:
// ??   Aaron Clauson   Created.
//
// License: 
// BSD 3-Clause "New" or "Revised" License, see included LICENSE.md file.
//-----------------------------------------------------------------------------

using System;
using System.Net;
using System.Text;
using Microsoft.Extensions.Logging;
using Xunit;

namespace SIPSorcery.Sys.UnitTests
{
    [Trait("Category", "unit")]
    public class TypeExtensionsUnitTest
    {
        private Microsoft.Extensions.Logging.ILogger logger = null;

        public TypeExtensionsUnitTest(Xunit.Abstractions.ITestOutputHelper output)
        {
            logger = SIPSorcery.UnitTests.TestLogHelper.InitTestLogger(output);
        }

        [Fact]
        public void TrimTest()
        {
            logger.LogDebug("--> {MethodName}", System.Reflection.MethodBase.GetCurrentMethod().Name);
            logger.BeginScope(System.Reflection.MethodBase.GetCurrentMethod().Name);

            String myString = null;

            Assert.True(myString.IsNullOrBlank(), "String was not correctly detected as blank.");
        }

        [Fact]
        public void ZeroBytesTest()
        {
            logger.LogDebug("--> {MethodName}", System.Reflection.MethodBase.GetCurrentMethod().Name);
            logger.BeginScope(System.Reflection.MethodBase.GetCurrentMethod().Name);

            String myString = Encoding.UTF8.GetString(new byte[] { 0x00, 0x00, 0x00, 0x00 });

            logger.LogDebug("Trimmed length={TrimmedLength}.", myString.Trim().Length);

            Assert.True(myString.IsNullOrBlank(), "String was not correctly detected as blank.");
        }

        [Fact]
        public void HexStrTest()
        {
            logger.LogDebug("--> {MethodName}", System.Reflection.MethodBase.GetCurrentMethod().Name);
            logger.BeginScope(System.Reflection.MethodBase.GetCurrentMethod().Name);

            byte[] buffer = { 0x00, 0x01, 0x02, 0x03 };

            logger.LogDebug("Hex string: {HexString}.", buffer.HexStr());

            Assert.Equal("00010203", buffer.HexStr());
        }

        [Fact]
        public void ToUnixTimeTest()
        {
            logger.LogDebug("--> {MethodName}", System.Reflection.MethodBase.GetCurrentMethod().Name);
            logger.BeginScope(System.Reflection.MethodBase.GetCurrentMethod().Name);

            var dateTime = new DateTime(2025, 2, 12, 23, 39, 0);
            var unixTime = dateTime.ToUnixTime();

            logger.LogDebug("Unix time: {unixTime}.", unixTime);

            Assert.Equal(1739403540L, unixTime);
        }

        [Fact]
        public void ToUnixTimeAfter2038Test()
        {
            logger.LogDebug("--> {MethodName}", System.Reflection.MethodBase.GetCurrentMethod().Name);
            logger.BeginScope(System.Reflection.MethodBase.GetCurrentMethod().Name);

            var dateTime = new DateTime(2060, 2, 13, 22, 54, 54);
            var unixTime = dateTime.ToUnixTime();

            logger.LogDebug("Unix time: {unixTime}.", unixTime);

            Assert.Equal(2843938494L, unixTime);
        }

        [Fact]
        public void ParseHexStrTest()
        {
            logger.LogDebug("--> {MethodName}", System.Reflection.MethodBase.GetCurrentMethod().Name);
            logger.BeginScope(System.Reflection.MethodBase.GetCurrentMethod().Name);

            byte[] buffer = TypeExtensions.ParseHexStr("00010203");

            logger.LogDebug("Hex string: {HexString}.", buffer.HexStr());

            Assert.Equal("00010203", buffer.HexStr());
        }
    }
}
