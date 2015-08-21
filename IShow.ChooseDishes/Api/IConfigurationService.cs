using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IShow.ChooseDishes.Data;

namespace IShow.ChooseDishes.Api
{
    public interface IConfigurationService
    {
        /// <summary>
        /// 按参数所在模块查询
        /// </summary>
        /// <param name="domain"></param>
        List<Config> QueryByDomain(string domain);
        
        /// <summary>
        /// 更新指定的参数的值
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        void Update(string name,string value);

        /// <summary>
        /// 通过名称和所在模块获取该值
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Config Find(string name);

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="configs"></param>
        void BatchUpdate(Hashtable configs);

        /// <summary>
        /// 分组查询所有参数 hashtable中
        /// </summary>
        /// <returns></returns>
        Hashtable QueryGroupByDomain();



    }
}
