﻿using System.Linq;
using System.Web.WebPages.Razor;
using System.Web.WebPages.TestUtils;
using Xunit;

namespace Microsoft.Web.Helpers.Test
{
    public class PreApplicationStartCodeTest
    {
        [Fact]
        public void StartTest()
        {
            AppDomainUtils.RunInSeparateAppDomain(() =>
            {
                // Act
                AppDomainUtils.SetPreAppStartStage();
                PreApplicationStartCode.Start();

                // Assert
                var imports = WebPageRazorHost.GetGlobalImports();
                Assert.True(imports.Any(ns => ns.Equals("Microsoft.Web.Helpers")));
            });
        }

        [Fact]
        public void TestPreAppStartClass()
        {
            PreAppStartTestHelper.TestPreAppStartClass(typeof(PreApplicationStartCode));
        }
    }
}
