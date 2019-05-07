/************************************************************************
* Copyright (c) 2019 All Rights Reserved.
*命名空间：ConfigDemo
*文件名： CustomerElement
*创建人： Lxsh
*创建时间：2019/5/7 10:32:37
*描述
*=======================================================================
*修改标记
*修改时间：2019/5/7 10:32:37
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
   public class CustomerElement:ConfigurationElement
    {
        private const string EnablePropertyName = "enabled";

        private const string ConnectionStringPropery = "connectionString";

        [ConfigurationProperty(EnablePropertyName, IsRequired = true)]
        public bool Enabled
        {
            get { return (bool)base[EnablePropertyName]; }
            set { base[EnablePropertyName] = value; }
        }

        [ConfigurationProperty(ConnectionStringPropery, IsRequired = true)]
        public string ConnectionString
        {
            get { return (string)base[ConnectionStringPropery]; }
            set { base[ConnectionStringPropery] = value; }
        }
    }
}