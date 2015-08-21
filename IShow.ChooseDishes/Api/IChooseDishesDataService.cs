using IShow.ChooseDishes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace IShow.ChooseDishes.Api
{
   
    public interface IChooseDishesDataService
    {
        [OperationContract]
        bool Login(string name, string password);
        [OperationContract]
        IEnumerable<string> GetAllName();
        #region Observable 区域管理 阙进午
        //查询所有区域
        [OperationContract]
        List<Location> queryByLocation();
        //添加区域
        [OperationContract]
        int addLocation(Location location);
        //修改区域
        [OperationContract]
        int editByLocation(Location location);
        //删除区域
        [OperationContract]
        int delByLocation(Location location);
        #endregion Observable 区域管理 阙进午
        
        #region Observable 方位管理 阙进午
        //查询方位
        [OperationContract]
        List<Bearing> queryByBearing();
        //添加方位
        [OperationContract]
        int addBearing(Bearing bearing);
        //修改方位
        [OperationContract]
        int editByBearing(Bearing bearing);
        //删除方位
        [OperationContract]
        int delByBearing(Bearing bearing);
        #endregion Observable 方位管理 阙进午
        
       #region Observable 套菜管理 阙进午
        [OperationContract]
        List<Dish> queryByDish(Dish dish);

        #endregion Observable 套菜管理 阙进午

        #region Observable 道菜管理 阙进午
        List<DishDao> queryByDishDaoID(DishDao dish);
        int EditByDishDao(DishDao dish);

        int delDishDao(DishDao dishDao);

        #endregion Observable 道菜管理 阙进午

        #region Observable 道菜明细管理 阙进午

        DishDetail queryByDishDetail(int dishDetailID);
        int EditByDishDetail(DishDetail dish);
        int delDishDetail(int Id,int Type);
        Dish queryByDishId(int dishID);
        List<DishDetail> queryByDishDetail(DishDetail detail);

        #endregion Observable 道菜明细管理 阙进午

        #region Observable 收银方式 滕海东
        //加载所有的收银方式  传入收银类型编号
        [OperationContract]
        List<CashType> findCashType(int CashBaseTypeId);
        //添加收银方式 返回添加成功后的收银方式
        [OperationContract]
        CashType addCashType(CashType cashType);
        //修改收银方式  返回修改成功后的方式
        [OperationContract]
        CashType updateCashType(CashType cashType);
        //删除收银方式 返回true 为修改成功
        [OperationContract]
        bool deleteCashType(int Id);

        #endregion Observable 收银方式 滕海东
        #region Observable 菜品管理 滕海东
        //查询菜品
        //[OperationContract]
        List<Dish> FindDishs(int  dishId);
        //查询可作为道菜的菜品
        List<Dish> FindDishPackages(int dishId);
        //根据菜品id 查询菜品对象
        Dish FindDishByDishId(int dishId);

        //新增菜品
        [OperationContract]
        Dish AddDish(Dish dish);
        //修改收银方式  返回修改成功后的方式
        [OperationContract]
        bool updateDish(Dish dish);
        //删除收银方式 返回true 为修改成功
        [OperationContract]
        bool deleteDish(int Id);
        /// <summary>
        /// 查询不是套餐的菜品 如果出错抛出异常
        /// </summary>
        /// <param name="ObjectName">可以是 菜品名称 菜品拼音 菜品编码</param>
        /// <returns></returns>
        List<Dish> FindDishNotTaoCanList(string ObjectName);


        #endregion Observable 菜品管理 滕海东

        
        #region Observable 菜品价格管理 滕海东

        //根据菜品查询菜品
        List<Dish> findAllDishByDishMenusId(int p);

        //加载菜品大类小类
        List<DishType> FindDishTypeByType(int dishTypeId);
        //根据菜品名字模糊查找
        List<Dish> FindDishsByDishName(string value);

        //////////////////////////////////////////////////////////
        ////////////////   修改菜品价格 滕海东 /////////////////////
        //根据一个 菜品id 查找菜品所有的价格 
        List<DishPrice> FindDishPriceByDishId(int DishId);
        //根据 一个 菜品 id 和菜品价格集合 新增 菜品价格 
        bool SaveDishPrice(int DishId, DishPrice[] dishPrices);
        //根据菜品id 和 菜品价格id 删除菜品价格 
        bool DeleteDishPrice(DishPrice dishPrice);
        //根据菜品id 和 菜品价格id 修改菜品价格 
        bool UpdateDishPrice(int DishId, DishPrice[] dishPrices);
        //修改菜品主价格
        bool UpdateDishPriceMain(DishPrice dishPrice);
        ////////////////   修改菜品价格 滕海东 /////////////////////
        //////////////////////////////////////////////////////////
        #endregion Observable 菜品价格管理 滕海东

        #region Observable 特价菜管理 滕海东
        //////////////////////////////////////////////////////////
        ////////////////   特价菜品管理 滕海东 /////////////////////
        //查询 特价菜信息  如果传入date 将根据时间查找
        List<BargainDish> findBargainDishList(DateTime date );
        //查询当前有效的
        List<BargainDish> findBargainDishAll();
        //修改 特价菜信息
        bool UpdateBargainDish(BargainDish BDish);
        //删除特价菜品
        bool DeleteBargainDish(int  id , int DishId);
        //批量删除特价菜品 
        bool BatchDeleteBargainDish(int[] ids);
        //删除所有
        bool BatchDeleteBargainDish();
        //新增特价菜信息 返回新增成功的集合
        List<BargainDish> BatchSaveBargainDish(BargainDish[] DBDishes);
        //加载所有有效的特价菜品
        List<BargainDish> findBargainDishAllAll();
        ////////////////   修改菜品价格 滕海东 /////////////////////
        //////////////////////////////////////////////////////////
        #endregion Observable 特价菜管理 滕海东

        #region Observable 菜品促销管理 滕海东
        
        //菜品促销条目查询
        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="status">状态 -1 表示查询全部  1 为 未审核 2 为审核 3 为作废</param>
        /// <returns></returns>
        List<PromotionsDish> FindPromotionsDishByObject(DateTime? startDate,DateTime? endDate ,int status);
        //删除促销条目
        bool DeletePromotionsDishByPdID(int PromotionsDishId , int DishId);
        //新增促销条目
        PromotionsDish SavePromotionsDish(PromotionsDish PD);
        //审核促销条目
        bool CheckPromotionsDish(int PromotionsDishId, int DishId, int status);
        //停用/启用  促销条目
        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <param name="PromotionsDishId"></param>
        /// <param name="DishId"></param>
        /// <param name="?"></param>
        /// <param name="status"> 0 为启用 1 为停用  </param>
        /// <returns></returns>
        bool StartOrStopPromotionsDish(int PromotionsDishId, int DishId,int status);
        //复制促销条目
        PromotionsDish CopyPromotionsDish(int PromotionsDishId, int DishId);

        bool UpdatePromotionsDish(PromotionsDish PD);



        #endregion Observable 菜品促销管理 滕海东

        #region  Observable 菜品估清管理
        /// <summary>
        /// 查询所有估清菜品
        /// </summary>
        /// <param name="domain"></param>
        List<ClearEstimate> QueryClearEstimateDishesList();
        /// <summary>
        /// 新增估清菜品
        /// </summary>
        ClearEstimate AddClearEstimateDish(ClearEstimate CE);
        /// <summary>
        /// 修改估清菜品
        /// </summary>
        bool UpdataClearEstimateDish(ClearEstimate CE);
        #endregion

    }
}
