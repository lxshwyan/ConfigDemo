/************************************************************************
* Copyright (c) 2019 All Rights Reserved.
*命名空间：ConfigDemo
*文件名： TestConfigInfo
*创建人： Lxsh
*创建时间：2019/5/7 16:57:02
*描述
*=======================================================================
*修改标记
*修改时间：2019/5/7 16:57:02
*修改人：Lxsh
*描述：
************************************************************************/
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigDemo
{
    public class TestConfigInfo : ConfigurationSection
    {
        [ConfigurationProperty("trackers", IsDefaultCollection = false)]
        public trackers Trackers { get { return (trackers)base["trackers"]; } }
        /// <summary>
        /// 获取配置信息
        /// </summary>
        /// <returns></returns>
        public static TestConfigInfo GetConfig()
        {
            return GetConfig("TestConfigInfo");
        }
        /// <summary>
        /// 获取配置信息
        /// </summary>
        /// <param name="sectionName">xml节点名称</param>
        /// <returns></returns>
        public static TestConfigInfo GetConfig(string sectionName)
        {
            TestConfigInfo section = (TestConfigInfo)ConfigurationManager.GetSection(sectionName);
            if (section == null)
                throw new ConfigurationErrorsException("Section " + sectionName + " is not found.");
            return section;
        }
        [ConfigurationProperty("TestName", IsRequired = false)]
        public string TestName
        {
            get { return (string)base["TestName"]; }
            set { base["TestName"] = value; }
        }
        [ConfigurationProperty("TestID", IsRequired = false)]
        public string TestID
        {
            get { return (string)base["TestID"]; }
            set { base["TestID"] = value; }
        }
    }

    public class trackers : ConfigurationElementCollection
    {
        [ConfigurationProperty("TrackerName", IsRequired = false)]
        public string TrackerName
        {
            get { return (string)base["TrackerName"]; }
            set { base["TrackerName"] = value; }
        }
        protected override ConfigurationElement CreateNewElement()
        {
            return new tracker();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((tracker)element).Host;
        }
    }
    public class tracker : ConfigurationElement
    {
        #region 配置節設置，設定檔中有不能識別的元素、屬性時，使其不報錯

        protected override bool OnDeserializeUnrecognizedAttribute(string name, string value)
        {
            return base.OnDeserializeUnrecognizedAttribute(name, value);

        }

        protected override bool OnDeserializeUnrecognizedElement(string elementName, System.Xml.XmlReader reader)
        {
            return base.OnDeserializeUnrecognizedElement(elementName, reader);

        }
        #endregion

        [ConfigurationProperty("Host", DefaultValue = "localhost", IsRequired = true)]
        public string Host { get { return this["Host"].ToString(); } }

        [ConfigurationProperty("Port", DefaultValue = "22122", IsRequired = true)]
        public int Port { get { return (int)this["Port"]; } }

    }
}