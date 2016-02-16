using Microsoft.VisualStudio.TestTools.UnitTesting;
//using mp4box.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mp4box.UtilTests
{
    [TestClass()]
    public class ParameterBuilderTests
    {
        [TestMethod()]
        public void ParameterBuilderTest()
        {
            var builder = new Util.ParameterBuilder();
            string expected = "";
            Assert.AreEqual(expected,builder.Build());
        }

        [TestMethod()]
        public void ParameterBuilderTest1()
        {
            var builder = new Util.ParameterBuilder("ffmpeg.exe");
            string expected = "ffmpeg.exe";
            Assert.AreEqual(expected, builder.Build());
        }

        [TestMethod()]
        public void AddTest()
        {
            var builder = new Util.ParameterBuilder();
            builder.Add(new Util.ParameterBuilder.ParameterItem(""));
            string expected = "";
            Assert.AreEqual(expected, builder.Build());

            builder = new Util.ParameterBuilder();
            builder.Add(new Util.ParameterBuilder.ParameterItem("--nameOnly"));
            expected = "--nameOnly";
            Assert.AreEqual(expected, builder.Build());

            builder = new Util.ParameterBuilder();
            builder.Add(new Util.ParameterBuilder.ParameterItem("-name","value"));
            expected = "-name value";
            Assert.AreEqual(expected, builder.Build());

            builder = new Util.ParameterBuilder();
            builder.Add(new Util.ParameterBuilder.ParameterItem("-name", "value",true));
            expected = "-name \"value\"";
            Assert.AreEqual(expected, builder.Build());
        }

        [TestMethod()]
        public void BuildTest()
        {
            var builder = new Util.ParameterBuilder("ffmpeg.exe");
            //builder.Add(new Util.ParameterBuilder.ParameterItem(""));
            builder.Add(new Util.ParameterBuilder.ParameterItem("--nameOnly"));
            builder.Add(new Util.ParameterBuilder.ParameterItem("-name", "value"));
            builder.Add(new Util.ParameterBuilder.ParameterItem("-name", "value", true));
            string expected = "ffmpeg.exe --nameOnly -name value -name \"value\"";
            Assert.AreEqual(expected, builder.Build());
        }
    }
}