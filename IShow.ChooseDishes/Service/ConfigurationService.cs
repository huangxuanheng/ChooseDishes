using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IShow.ChooseDishes.Api;
using IShow.ChooseDishes.Data;

namespace IShow.ChooseDishes.Service
{
    public class ConfigurationService:IConfigurationService
    {
        /// <summary>
        /// 按参数所在模块查询
        /// </summary>
        /// <param name="domain"></param>
        public List<Config> QueryByDomain(string domain)
        {
            using (ChooseDishesEntities entities = new ChooseDishesEntities()) {
                return entities.Config.Where(c => c.Domain.Equals(domain)).ToList();
            }

        }

        /// <summary>
        /// 更新指定的参数的值
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void Update(string name, string value) {
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                Config config = entities.Config.Single(c => c.Name.Equals(name));
               if (null == config) {
                   throw new NotFoundException("参数名【"+name+"】未找到匹配的项！");
               }
               config.Value = value;
               entities.SaveChanges();
            }

        }
        /// <summary>
        /// 根据指定参数名称修改指定的参数
        /// 
        /// </summary>
        /// <param name="name">值</param>
        /// <param name="value">状态</param>
        public void Update(string name, string value,int status)
        {
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                Config config = entities.Config.Single(c => c.Name.Equals(name));
                if (null == config)
                {
                    throw new NotFoundException("参数名【" + name + "】未找到匹配的项！");
                }
                config.Value = value;
                config.Disabled = status;
                entities.SaveChanges();
            }

        }
        /// <summary>
        /// 通过名称获取该值,该接口未查找到相应的值时，抛出异常
        /// </summary>
        /// <param name="name"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        public Config Find(string name)
        {
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                Config config = entities.Config.Single(c => c.Name.Equals(name));
                if (null == config)
                {
                    throw new NotFoundException("参数名【" + name + "】未找到匹配的项！");
                }
                return config;
            }
        }

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="configs"></param>
        public void BatchUpdate(Hashtable configs) {
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
               ICollection keys= configs.Keys;
                IEnumerator iter = keys.GetEnumerator();
                List<string> list = new List<string>();
               while(iter.MoveNext()){
                    list.Add(iter.Current.ToString());
               }
               List<Config> configList = entities.Config.Where(c => list.Any(m => m == c.Name)).ToList();
               foreach (var c in configList) {
                   c.Value = configs[c.Name].ToString();
               }
               entities.SaveChanges();
            }
        }

        /// <summary>
        /// 分组查询所有参数 hashtable中
        /// </summary>
        /// <returns></returns>
        public Hashtable QueryGroupByDomain() {

            //TODO:按模块分组查询配置参数未实现
            return null;
        }
    }
}
