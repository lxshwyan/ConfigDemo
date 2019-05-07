/************************************************************************
* Copyright (c) 2019 All Rights Reserved.
*命名空间：ConfigDemo
*文件名： CustomerSingleConfig
*创建人： Lxsh
*创建时间：2019/5/7 9:14:51
*描述
*=======================================================================
*修改标记
*修改时间：2019/5/7 9:14:51
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
    /// <summary>
    /// 单级自定义配置节点
    /// </summary>
   public class CustomerSingleConfig:ConfigurationSection
    {


        /// <summary>
        /// 获取配置信息
        /// </summary>
        /// <returns></returns>
        public static CustomerSingleConfig GetConfig()
        {
            return GetConfig("CustomerSingleConfig");
        }
        /// <summary>
        /// 获取配置信息
        /// </summary>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        public static CustomerSingleConfig GetConfig(string sectionName)
        {
            CustomerSingleConfig section = (CustomerSingleConfig)ConfigurationManager.GetSection(sectionName);
            if (section == null)
                throw new ConfigurationErrorsException("Section " + sectionName + " is not found.");
            return section;
        }
           
        /// <summary>
        /// 平台中文名称
        /// </summary>
       [ConfigurationProperty("PlatChName",DefaultValue = "", IsRequired = true, IsKey = false)]
        public string PlatChName 
        {
            get { return (string)this["PlatChName"]; }
            set { this["PlatChName"]=value; }
        }  

        /// <summary>
        /// 平台英文名称
        /// </summary>
       [ConfigurationProperty("PlatEnName",DefaultValue = "", IsRequired = true, IsKey = false)]
        public string PlatEnName
        {
            get { return (string)this["PlatEnName"]; }
            set { this["PlatEnName"] = value; }
        }

    }
}
